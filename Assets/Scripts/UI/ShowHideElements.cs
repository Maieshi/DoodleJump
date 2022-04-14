using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideElements : MonoBehaviour
{
    [SerializeField]
    private bool _isHidden;
    public void ShowHide()
    {
        if (_isHidden)
        {
            gameObject.SetActive(true);
            _isHidden = false;
        }
        else
        {
            gameObject.SetActive(false);
            _isHidden = true;
        }
    }
}
