using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstwo : mob
{
    public GameObject beam,bullets,mobmuri;
    float attacktime=5f;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


        if (this.transform.position.y < 2.5f)
        {
            stop = true;


        }
        if (stop)
        {
            attacktime += Time.deltaTime;
            if (attacktime > 6f)
            {
                attacktime = 0;
                GetComponent<Animator>().SetTrigger("attack");
             

               
            }
        }
        if (hp <= 0)
        {
            if (!onedie)
            {
                this.GetComponent<Animator>().SetTrigger("die");
                onedie = true;
            }
            //게임클리어
          
        }
    }

    bool onedie;

    public void thisdie()
    {
        GameManager.GameManagerthis.Gameclear = true;
        Destroy(this.gameObject);
    }
    public void attacks()
    {
        int x = Random.Range(0, 3);
        switch (x)
        {
            case 0: Instantiate(beam, player.playerthis.transform.position, this.transform.rotation); break;
            case 1:
                GameObject bullet = Instantiate(bullets, this.transform.position, this.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce((player.playerthis.transform.position - this.transform.position).normalized * 200);
                break;

            case 2:
                GameObject mobs = Instantiate(mobmuri,GameManager.GameManagerthis.spawnpos.transform.position, GameManager.GameManagerthis.spawnpos.transform.rotation);
                mobs.transform.DetachChildren();
                break;
        }
    }






}
