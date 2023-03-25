using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public float hp;
    public float speed;
    public pos Pos;
    bool invincibility=true;
    public enum pos
    {
        앞,
        오른쪽,
        왼쪽
    }
    private void Start()
    {
        Destroy(this.gameObject,5f);
       

    }

    public void invincibilityoff()
    {
        invincibility = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y < 5)
        {
            invincibilityoff();
        }

        switch (Pos)
        {
            case pos.앞:      this.transform.Translate(Vector2.down *speed *Time.deltaTime);            break;
            case pos.오른쪽:  this.transform.Translate(new Vector2(0.1f,-1) * speed * Time.deltaTime); break;
            case pos.왼쪽:    this.transform.Translate(new Vector2(-0.1f, -1) * speed * Time.deltaTime); break;
        }
        if (hp <= 0)
        {
          GameManager.GameManagerthis.point++;
            Destroy(this.gameObject);
        }
    }
    public GameObject hiteff;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet")&& ! invincibility)
        {
            hp--;
            Destroy(collision.gameObject);
            Instantiate(hiteff, this.transform.position, this.transform.rotation);
         
        }

    }
}
