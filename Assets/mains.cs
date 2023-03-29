using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class mains : MonoBehaviour
{
    public void goingames()
    {
        SceneManager.LoadScene(1);


    }


    public GameObject scoreonui;

    public void scoreon()
    {
        if (scoreonui.activeSelf == true)
            scoreonui.SetActive(false);
        else
        {
            scoreonui.SetActive(true);
            scoreonui.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("bestpoint").ToString();
        }
    }


}
