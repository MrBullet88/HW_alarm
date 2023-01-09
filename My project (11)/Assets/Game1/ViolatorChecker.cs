using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolatorChecker : MonoBehaviour
{
    [SerializeField] private GameObject _signaling;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _signaling.GetComponent<VolumeChanger>().IncreaseVolume();
        _animator.SetBool("IsAlarmOn", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _signaling.GetComponent<VolumeChanger>().DecreaseVolume();
        _animator.SetBool("IsAlarmOn", false);
    }
}
