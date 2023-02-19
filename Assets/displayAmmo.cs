using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayAmmo : MonoBehaviour
{
    [SerializeField] private playermovment player;
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = "Ammo: " + player.ammo;
    }
}
