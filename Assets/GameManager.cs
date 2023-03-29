using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] mob;
    public GameObject[] boss;
    public Transform spawnpos;
    public float spawntime;
    public bool spawnstop;
    public int stage;
    public float stagetime;

    public TextMeshProUGUI pointui,timeui;
    public int point,bestpoint;

    public GameObject gameoveron;
    public TextMeshProUGUI gameoverpointui, gamebestoverpointui;

    public static GameManager GameManagerthis = null;
    public GameManager gameManager
    {
        get
        {
            if (GameManagerthis == null)
            {
                return null;
            }
            return GameManagerthis;
        }
    }
    private void Awake()
    {
        if (gameManager == null)
        {
            GameManagerthis = this;
        }

        bestpoint = PlayerPrefs.GetInt("bestpoint");

    }
    int min;

    public void restart()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public bool Gameclear;
    public GameObject Gameclearui;
    public TextMeshProUGUI gameclearpointui, gameclearbestpointui;


    public Sprite waytwo;
    public GameObject way;

    public void mains()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameclear)
        {
         
            if (point > bestpoint)
            {
                PlayerPrefs.SetInt("bestpoint",point);
                bestpoint = point;
            }
            gameclearpointui.text = "점수 : " + point.ToString();
            gameclearbestpointui.text = "최고점수 : " + bestpoint.ToString();
            Gameclearui.SetActive(true);
            Gameclear = false;
        }

        pointui.text = "점수 : " + point;
        if(stagetime<9.5f)
        timeui.text = "시간 : " + "0" + min + ":" + "0" + stagetime.ToString("F0");
        else
        timeui.text = "시간 : " + "0" + min + ":" + stagetime.ToString("F0");
        if (spawntime > 4f)
        {
            if(!spawnstop)
            spawn();
            spawntime = 0f;
        }
        spawntime += Time.deltaTime;
        if (stagetime < 60f&& !spawnstop)
        { 
            stagetime += Time.deltaTime; 
        }
        else if (stagetime >=60f && !spawnstop)
        {
            spawntime = 3f;
            min++;
            Debug.Log("왜안되");
            stagetime = 0;
            Instantiate(boss[stage - 1],new Vector3( spawnpos.position.x, spawnpos.position.y+5,0), spawnpos.rotation);
            spawnstop = true;
        }
        

    }

    public void spawn()
    {
        int z = 0;
        if (stage == 1)
            z = Random.Range(0, 5);
        else if (stage == 2)
            z = Random.Range(5, 10);

       GameObject mobs =Instantiate(mob[z], spawnpos.position , spawnpos.rotation);
        mobs.transform.DetachChildren();
        Destroy(mobs);
    }


}
