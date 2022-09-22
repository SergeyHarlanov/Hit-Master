using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameProperty : MonoBehaviour
{
    public static GameProperty Instance;
    
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public float ForceBodyPart { get; private set; }
    [field: SerializeField] public float NextPointDelay { get; private set; }
    [field: SerializeField] public Transform[] Points { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }
}
