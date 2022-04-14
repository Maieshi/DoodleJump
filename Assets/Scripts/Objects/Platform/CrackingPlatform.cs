using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrackingPlatform : Platform
{
    private Animator _animator;
    // Start is called before the first frame update
    public override void Start()
    {
        _interactionEvent = new UnityEvent();
        _interactionEvent.AddListener(Deactivate);
        _animator = GetComponent<Animator>();
        base.Start();
    }

    // Update is called once per frame


    public void Deactivate()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<PlatformEffector2D>().enabled = false;
        _animator.SetBool("_touched", true);
    }
}
