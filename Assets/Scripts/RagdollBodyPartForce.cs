using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBodyPartForce : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _enemy.Dead();
            other.gameObject.SetActive(false);
            _rigidbody.AddForce(Vector3.back * GameProperty.Instance.ForceBodyPart);
        }
        
    }
}
