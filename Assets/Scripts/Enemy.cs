using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Rigidbody[] _ragdollItem;

    private Animator _animator;

    private bool _dead;

 private void Start()
 {
    _animator = GetComponent<Animator>();
 }

 public void Dead()
 {
     if (!_dead)
     {
         _animator.enabled = false;
         foreach (var item in _ragdollItem)
         {
             item.isKinematic = false;
         }

         Attack.Instance.UpdateCountEnemyOnpoint();
         _dead = true;
     }
 }

}
