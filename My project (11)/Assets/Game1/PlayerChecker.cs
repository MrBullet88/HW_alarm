using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    private float _distance = 6.9f;
    public bool IsPlayerDetected { get; private set; }      
    private readonly RaycastHit2D[] results = new RaycastHit2D[1];

    private void Update()
    {      
       var collisionCount =  _rigidbody2D.Cast(Vector2.right, results , _distance);

        if(collisionCount > 0)
        {
            IsPlayerDetected = true;
        }
        else
        {
            IsPlayerDetected = false;
        }      
    }
}
