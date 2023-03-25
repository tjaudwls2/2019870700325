using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    public float destimes;
    // Start is called before the first frame update
    void Start()
    {
         Destroy(this.gameObject, destimes);
    }

 
}
