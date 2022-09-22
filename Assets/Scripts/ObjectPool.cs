using System;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject _bullet;
    
    private List<GameObject> _pooling = new List<GameObject>();
    private int poolAmount = 20;
    private void Awake()
    { 
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            _pooling.Add(Instantiate(_bullet));
            _pooling[i].gameObject.SetActive(false);
            _pooling[i].transform.SetParent(transform);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!_pooling[i].activeSelf)
            {
                _pooling[i].SetActive(true);
                return _pooling[i];
            }
        }

        return null;
    }
}
