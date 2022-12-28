using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _gameObject;

    private float recoveryRate = 0.3f;
    private float _currentVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private bool _isPlayerDetected;
    private bool _isAlarmOn = false;

    private void Update()
    {
        _isPlayerDetected = _gameObject.GetComponent<PlayerChecker>().IsPlayerDetected;

        if (_isPlayerDetected)
        {
            if(_isAlarmOn == false)
            {
                _audioSource.Play();
                _isAlarmOn = true;
            }
                
           StartCoroutine(ChangeVolume(_currentVolume, _maxVolume));
        }
        else if(!_isPlayerDetected)
        {
           StartCoroutine(ChangeVolume(_currentVolume, _minVolume));

            if (_currentVolume == _minVolume)
            {
                _audioSource.Stop();
                _isAlarmOn = false;
            }           
        }

        _currentVolume = _audioSource.volume;
    }

    private IEnumerator ChangeVolume(float volume, float targetVolume)
    {
        while (volume != targetVolume)
        {
            volume = Mathf.MoveTowards(volume, targetVolume, recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;
            yield return null;
        }       
    }
}
