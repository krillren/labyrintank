using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonDirection : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = player.position;
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.localEulerAngles = new Vector3(0, 0, 
            Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}
