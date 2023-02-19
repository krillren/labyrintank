using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    private playermovment player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<playermovment>();
    }

    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = "Score: " + player.score;
    }
}
