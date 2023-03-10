using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Alarm _alarm;
    
    private float _recoveryRate = 0.6f;
    private float _currentVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private bool _isAlarmOn = false;
    private Coroutine _volumeCoroutine;

    public void StartChangeVolume(float targetVolume)
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    public void IncreaseVolume()
    {
        if (_isAlarmOn == false)
        {
            _audioSource.Play();          
            _isAlarmOn = true;
        }

        StartChangeVolume(_maxVolume);      
    }

    public void DecreaseVolume()
    {
        StartChangeVolume(_minVolume);
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            if (_audioSource.volume == _minVolume)
            { 
                _audioSource.Stop();
                _isAlarmOn = false;
            }

            yield return null;
        }
    }

    private void OnEnable()
    {
        _alarm.PlayerChecked.AddListener(IncreaseVolume);
        _alarm.PlayerLost.AddListener(DecreaseVolume);
    }

    private void OnDisable()
    {
        _alarm.PlayerChecked.RemoveListener(IncreaseVolume);
        _alarm.PlayerLost.RemoveListener(DecreaseVolume);
    }
}
