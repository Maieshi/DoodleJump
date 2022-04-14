using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Object : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;

    private UnityEvent _interactionEvent;

    private void Start()
    {

    }

    public virtual float GetValue()
    {
        if (_interactionEvent != null) _interactionEvent.Invoke();
        return _jumpForce;
    }
}
