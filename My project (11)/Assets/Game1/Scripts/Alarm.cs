using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public UnityEvent PlayerChecked;
    public UnityEvent PlayerLost;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerChecked?.Invoke();
        _animator.SetBool(AnimatorAlarmController.Params.IsAlarmOn, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerLost?.Invoke();
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

