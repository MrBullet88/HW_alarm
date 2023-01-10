using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolatorChecker : MonoBehaviour
{
    [SerializeField] private VolumeChanger _volumeChanger;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _volumeChanger.IncreaseVolume();
        _animator.SetBool(AnimatorAlarmController.Params.IsAlarmOn, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _volumeChanger.DecreaseVolume();
        _animator.SetBool(AnimatorAlarmController.Params.IsAlarmOn, false);
    }
}
public static class AnimatorAlarmController
{
    public static class Params
    {
        public const string IsAlarmOn = "IsAlarmOn";
    }
}
