using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*Time.deltaTime*3);
    }
}
