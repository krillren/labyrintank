using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private GameObject bullet_prefab;
    private bool allow_shoot = true;
    public int ammo = 0;
    public int score = 0;
    private Animator tank_anim;
    private float actual_speed;

    [SerializeField]
    private float bulletSpeed=25f;

    [SerializeField] private Animator canon_anim;
    

    private void Start()
    {
        tank_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && allow_shoot)
        {
            StartCoroutine(shoot());
        }
    }

    private void FixedUpdate()
    {
        //set player orientation toward where he is going
        float offset = 0f;
        actual_speed = 0;
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)){
            transform.position += (Vector3)Vector2.up * speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            offset = -45f;
            actual_speed = 1;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            transform.position += (Vector3)Vector2.down * speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, 180);
            offset = 45f;
            actual_speed = 1;
        }
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)){
            transform.position += (Vector3)Vector2.left * speed * Time.deltaTime;
            
            transform.localEulerAngles = new Vector3(0, 0, 90 + offset );
            actual_speed = 1;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, -90 - offset);
            actual_speed = 1;
        }
        
        tank_anim.SetFloat("speed", actual_speed);
       
        
       
    }

    private IEnumerator shoot()
    {
        if (ammo > 0)
        {
            //towards mouse
            
            GameObject bullet = Instantiate(bullet_prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * bulletSpeed, ForceMode2D.Impulse);
            //ignore collision with player
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
            ammo--;
            allow_shoot = false;
            canon_anim.SetTrigger("shoot");
            yield return new WaitForSeconds(0.2f);
            
            allow_shoot = true;
        }   
    }
    public void addAmmo(int amount)
    {
        ammo += amount;
    }
    public void addScore(int amount)
    {
        score+= amount;
    }
}
