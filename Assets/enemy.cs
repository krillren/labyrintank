using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] GameManager gameManager;
    public float speed = 5f;
    [SerializeField] LayerMask obstacles;
    private Vector2 lastPos = new Vector2(1000,1000);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(Time.timeScale == 0){return;}
            
        if (!Physics2D.Linecast(transform.position, player.position, obstacles))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            lastPos = player.position;
            transform.localEulerAngles = new Vector3(0, 0, 
                Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
        else
        {
            if (lastPos != new Vector2(1000, 1000))
            {
                transform.position = Vector2.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);
            }
            
        }
        

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            player.GetComponent<playermovment>().addScore(1);
        }

        if (col.gameObject.tag == "Player")
        {
            
            if (SceneManager.GetActiveScene().name == "survival")
            {
                gameManager.loose(col.gameObject.GetComponent<playermovment>().score);
            }
            else
            {
                gameManager.loose();
            }
            Destroy(col.gameObject);   
            
        }
    }
}
