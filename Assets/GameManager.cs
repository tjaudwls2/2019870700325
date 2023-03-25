using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject[] mob;
    public GameObject[] boss;
    public Transform spawnpos;
    public float spawntime;
    public bool bossspawn;
    public int stage;
    public float stagetime;

    public TextMeshProUGUI pointui,timeui;
    public int point;

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
    }
    int min;
    // Update is called once per frame
    void Update()
    {
        pointui.text = "점수 : " + point;
        if(stagetime<9.5f)
        timeui.text = "시간 : " + "0" + min + ":" + "0" + stagetime.ToString("F0");
        else
        timeui.text = "시간 : " + "0" + min + ":" + stagetime.ToString("F0");
        if (spawntime > 3f)
        {
            if(!bossspawn)
            spawn();
            spawntime = 0f;
        }
        spawntime += Time.deltaTime;
        if(stagetime < 60f)
        stagetime += Time.deltaTime;
        else if (stagetime > 60f && !bossspawn)
        {
            min++;
            stagetime = 0;
            Instantiate(boss[stage - 1]);
            bossspawn = true;
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
