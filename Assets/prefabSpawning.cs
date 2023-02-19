using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class prefabSpawning : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawnlocations;
    [SerializeField] private float frequency;
    
    [SerializeField] private Transform player;

    private GameObject instantiated;
    void Update()
    {
        foreach (Transform location in spawnlocations)
        {
            if (Vector2.Distance(location.position, player.position) < 7f)
            {
                continue;
            }
                
            if (Random.Range(0, 1000) < frequency && Time.timeScale != 0)
            {
                instantiated = Instantiate(prefab, location.position,Quaternion.identity);
                if (prefab.CompareTag("enemy"))
                {
                    instantiated.GetComponent<enemy>().speed = 2f;
                }
            }
        }

    }
}
