using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{



 
    public static player playerthis=null;
    public player Player
    {
        get
        {
            if (playerthis == null)
            {
                return null;
            }
                return playerthis;
        }
    }
    private void Awake()
    {
        if(Player == null)
        {
            playerthis = this;
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        move();
        bulletfirespeed += Time.deltaTime;
        if (bulletfirespeed > 0.5f)
        {
            fire();
            bulletfirespeed = 0;
        }
       
    }

    public float speed = 1;
    public void move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x += Horizontal * Time.deltaTime * speed;
        Position.y += Vertical * Time.deltaTime * speed;

        transform.position = new Vector3(Mathf.Clamp(Position.x, -2.8f, 2.8f), Mathf.Clamp(Position.y, -4.7f, 4.7f), 0);
    }




    public GameObject Bullet;
    public float bulletspeed;
    public float bulletfirespeed;
    public void fire()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet =  Instantiate(Bullet,transform.position,transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up* bulletspeed);
        }
    }

}
