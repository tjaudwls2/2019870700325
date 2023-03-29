using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob2 : mob
{

    protected override  void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (this.transform.position.y < 3f)
        {
            stop = true;
            GetComponent<Animator>().SetTrigger("attack");

        }
    }
    public void attack()
    {

        this.GetComponent<Rigidbody2D>().AddForce((player.playerthis.transform.position - this.transform.position).normalized * 500);



    }
}
