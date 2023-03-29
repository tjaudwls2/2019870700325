using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loads : MonoBehaviour
{
    private void Awake()
    {
        Invoke("ingames", 3f);
    }
    public void ingames()
    {
        SceneManager.LoadScene(2);
    }
}
