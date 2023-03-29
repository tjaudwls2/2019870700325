using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob3 : mob
{

    public GameObject bullets;
    public float bulletstime;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (this.transform.position.y < 3f)
        {
            stop = true;
            

        }

        if (stop)
        {
            bulletstime += Time.deltaTime;
            if (bulletstime > 2f)
            {
                GameObject bullet = Instantiate(bullets, this.transform.position, this.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce((player.playerthis.transform.position - this.transform.position).normalized * 200);
                bulletstime = 0;
            }
        }




    }
}
