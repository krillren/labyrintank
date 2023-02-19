using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class giveammo : MonoBehaviour
{
    private playermovment player;
    [SerializeField] private int ammo;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<playermovment>();
        if (ammo == 0)
        {
            ammo = (int)Random.Range(1, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.addAmmo(2); 
            Destroy(gameObject);
        }
       
    }


}
