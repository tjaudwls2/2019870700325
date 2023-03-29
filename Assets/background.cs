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
        if (transform.position.y< -4.2f)
        {
            this.transform.position = new Vector3(0, 5.8759f, 0);
        }
    }
}
