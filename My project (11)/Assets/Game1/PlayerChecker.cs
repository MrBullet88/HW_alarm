using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private AudioSource _audioSource;

    private  float recoveryRate = 0.2f;
    private float _currentVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private float _distance = 6.9f;
       
    private readonly RaycastHit2D[] results = new RaycastHit2D[1];


    private void FixedUpdate()
    {      
       var collisionCount =  _rigidbody2D.Cast(Vector2.right, results , _distance);

        if(collisionCount>0 && _currentVolume == 0)
        {
            _audioSource.Play();
        }

        if(collisionCount > 0)
        {           
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            
        }
        else if (collisionCount == 0 && _currentVolume > 0)
        {          
            _currentVolume = Mathf.MoveTowards(_currentVolume, _minVolume, recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }

        if (collisionCount == 0 && _currentVolume == 0)
        {
            _audioSource.Stop();
        }
        
    }
}
