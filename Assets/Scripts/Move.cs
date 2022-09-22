using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : StateMachine
{
    
    private Player _player;
    private Animator _animator;
    
    public override void StartState()
    {
        _player.Move = true;
        Debug.Log("Move true");
        _animator.SetBool("Move", true);
    }
    public override void EndState()
    {
        _player.Move = false;
        Debug.Log("Move false");
        _animator.SetBool("Move", false);
    }
    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TriggerPoint>(out  TriggerPoint triggerPoint))
        {
            EndState();
        }
    }
}
