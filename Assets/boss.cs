using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : mob
{

    bool attacks;
    float attacktime=7;
    public GameObject Axe;
    bool onedie;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (this.transform.position.y < 3.5f&&!attacks)
        {
            stop = true;


        }
        if (stop)
        {
            attacktime += Time.deltaTime;
            if (attacktime > 7f)
            {
                int x= Random.Range(0,2);
                switch (x)
                {
                    case 0: goattack(); attacktime = 0; break;
                    case 1: axeattack(0); axeattack(20); axeattack(-20); attacktime = 5; break;

                }
           
            }
        }
        if (hp <= 0)
        {
            if (!onedie)
            {
                GetComponent<Animator>().SetTrigger("die");
                onedie = true;
            }
        }
    }
    public void die()
    {
        Destroy(this.gameObject);
        GameManager.GameManagerthis.stage++;
        GameManager.GameManagerthis.point += 100;
        GameManager.GameManagerthis.spawnstop = false;
        GameManager.GameManagerthis.way.GetComponent<SpriteRenderer>().sprite = GameManager.GameManagerthis.waytwo;
    }
    public void axeattack(int a)
    {
        GameObject bullet = Instantiate(Axe, this.transform.position, this.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(a, Vector3.forward) * Vector2.down * 200);
    }
    public void goattack()
    {
        this.GetComponent<Animator>().SetTrigger("attack");
    }
    public void attack()
    {
        attacks = true;
        this.GetComponent<Rigidbody2D>().AddForce((player.playerthis.transform.position - this.transform.position).normalized * 300);
    }
    public void onewhich()
    {
        this.transform.position = new Vector3(Random.Range(-2,3) ,GameManager.GameManagerthis.spawnpos.position.y,0);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        stop = false;
        attacks = false;
    }


}
