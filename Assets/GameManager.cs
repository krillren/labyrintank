using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject message;
    public void loose(int score = 0)
    {
        message.SetActive(true);
        if (score != 0)
        {
            message.GetComponentInChildren<TextMeshProUGUI>().text = "Your score is " + score;
            message.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
        else
        {
            message.GetComponentInChildren<TextMeshProUGUI>().text = "You Loose";
            message.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }
        
        Time.timeScale = 0;
    }
    public void win()
    {
        message.SetActive(true);
        message.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";
        message.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        Time.timeScale = 0;
    }
}
