using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    // For moving platforms
    private bool _change;
    [SerializeField]
    private float _offset;

    [SerializeField]
    private float _speed;
    Vector3 _screenEdge;

    public override void Start()
    {
        _change = true;
        _offset = Random.Range(0, 2f);
        _speed = Random.Range(0.03f, 0.1f);
        _screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        base.Start();
    }

    void FixedUpdate()
    {

        if (_change) // Move to right
        {
            if (transform.position.x < -_screenEdge.x - _offset)
                transform.position += new Vector3(_speed, 0, 0);
            else
                _change = false;
        }
        else // Move to left
        {
            if (transform.position.x > _screenEdge.x + _offset)
                transform.position -= new Vector3(_speed, 0, 0);
            else
                _change = true;
        }
    }


}
