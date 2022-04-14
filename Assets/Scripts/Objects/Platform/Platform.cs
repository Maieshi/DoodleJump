using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField]
    protected float _jumpForce;

    protected UnityEvent _interactionEvent;

    [SerializeField]
    protected bool _isDestroyable;

    public virtual void Start()
    {
        StartCoroutine(CheckDistance());
    }

    public virtual float GetValue()
    {
        if (_interactionEvent != null) _interactionEvent.Invoke();
        return _jumpForce;
    }

    IEnumerator CheckDistance()
    {

        while (true)
        {
            Vector3 _cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            if (transform.position.y < _cameraPosition.y - 1 && _isDestroyable)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
