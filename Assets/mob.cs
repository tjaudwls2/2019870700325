using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public float hp;
    public float speed;
    public pos Pos;
    bool invincibility=true;
    public bool stop;
    public bool notdie;
    public float destime;
    public enum pos
    {
        앞,
        오른쪽,
        왼쪽
    }
    protected virtual void Start()
    {
        if(!notdie)
        Destroy(this.gameObject, destime);
       

    }

    public void invincibilityoff()
    {
        invincibility = false;
    }


    // Update is called once per frame
    protected virtual void Update()
    {

        if (this.transform.position.y < 5)
        {
            invincibilityoff();
        }
        if (!stop)
        {
            switch (Pos)
            {
                case pos.앞: this.transform.Translate(Vector2.down * speed * Time.deltaTime); break;
                case pos.오른쪽: this.transform.Translate(new Vector2(0.1f, -1) * speed * Time.deltaTime); break;
                case pos.왼쪽: this.transform.Translate(new Vector2(-0.1f, -1) * speed * Time.deltaTime); break;
            }
        }
        if (hp <= 0)
        {
            if (!thisboss)
            {
                float itemper = Random.value;
                if (itemper >= 0.9f)
                {
                    GameObject item = Instantiate(items[Random.Range(0, 3)], this.transform.position, this.transform.rotation);
                    item.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
                }
                GameManager.GameManagerthis.point++;
                Destroy(this.gameObject);
            }
        }
    }
    public GameObject[] items;
    public GameObject hiteff;
    public bool thisboss;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet")&& ! invincibility)
        {
            hp--;
            Destroy(collision.gameObject);
            if(!thisboss)
            Instantiate(hiteff,  this.transform.position, this.transform.rotation);
            else
            Instantiate(hiteff, collision.transform.position, this.transform.rotation);
        }
        if (collision.CompareTag("tone") && !invincibility)
        {
            hp-=2;




        }
    }
}
