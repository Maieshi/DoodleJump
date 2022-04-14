using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private Vector3 _idlePosition;

    private void Start()
    {
        _idlePosition = transform.position;
        GameController._singleton._restartEvent.AddListener(Restart);
    }

    private void Restart()
    {
        transform.position = _idlePosition;
    }

    void Update()
    {
        if (_target.position.y > transform.position.y + 2)
        {
            Vector3 _newPosition = new Vector3(transform.position.x, _target.position.y - 2, transform.position.z);
            transform.position = _newPosition;
        }
    }
}
