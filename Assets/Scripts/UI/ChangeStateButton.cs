using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStateButton : MonoBehaviour
{
    [SerializeField]
    private int _statesCount;

    [HideInInspector]
    public int _state;

    [SerializeField]
    private Sprite[] _stateImages;

    private void Start()
    {
        _state = 0;

    }

    public void ChangeState()
    {
        if (_state < _statesCount) _state++;
        else _state = 0;
        if (_stateImages.Length - 1 >= _state) gameObject.GetComponent<Button>().image.sprite = _stateImages[_state];
    }
}
