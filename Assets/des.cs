using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    public bool desreal;
    public float destimes;
    // Start is called before the first frame update
    void Start()
    {
        if(!desreal)
         Destroy(this.gameObject, destimes);
    }
    public void deson()
    {

        Destroy(this.gameObject);
    }
 
}
