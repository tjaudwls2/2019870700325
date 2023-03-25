using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime *speed);
        if (transform.position.y<-5)
        {
            this.transform.position = new Vector3(0, 6.5f, 0);
        }
    }
}
