using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InnerCollider : MonoBehaviour
{
    public UnityEvent<Collision2D> OnEnter;
    public UnityEvent<Collision2D> OnExit;
    public UnityEvent<Collision2D> OnStay;

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnEnter?.Invoke(other);
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        OnExit?.Invoke(other);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        OnStay?.Invoke(other);
    }

}
