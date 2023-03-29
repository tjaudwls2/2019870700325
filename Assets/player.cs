using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class player : MonoBehaviour
{



    public int hp=3;
    public int knife;
    public int boom;

    public static player playerthis=null;
    public player Player
    {
        get
        {
            if (playerthis == null)
            {
                return null;
            }
                return playerthis;
        }
    }
    private void Awake()
    {
        if(Player == null)
        {
            playerthis = this;
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
   
        move();
        bulletfirespeed += Time.deltaTime;
        if (bulletfirespeed > 0.5f)
        {
            fire(knife);
            bulletfirespeed = 0;
        }
       
    }
    private void Update()
    {
        if (onedie)
        {
            speed = 0;
            if (GameManager.GameManagerthis.point > GameManager.GameManagerthis.bestpoint)
            {
                PlayerPrefs.SetInt("bestpoint", GameManager.GameManagerthis.point);
                GameManager.GameManagerthis.bestpoint = GameManager.GameManagerthis.point;
            }

            GameManager.GameManagerthis.gameoveron.SetActive(true);
            GameManager.GameManagerthis.gameoverpointui.text = "점수 : "+GameManager.GameManagerthis.point.ToString();
            GameManager.GameManagerthis.gamebestoverpointui.text = "최고점수 : " + GameManager.GameManagerthis.bestpoint.ToString();
        
           onedie = false;
        }

        switch (hp)
        {
            case 3: hpimg[2].sprite = hpon; hpimg[1].sprite = hpon; hpimg[0].sprite = hpon; break;
            case 2: hpimg[2].sprite = hpoff; hpimg[1].sprite = hpon; hpimg[0].sprite = hpon; break;
            case 1: hpimg[2].sprite = hpoff; hpimg[1].sprite = hpoff; hpimg[0].sprite = hpon; break;
            case 0: hpimg[2].sprite = hpoff; hpimg[1].sprite = hpoff; hpimg[0].sprite = hpoff; break;
        }

        boomui.text = "x" + boom.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (boom > 0)
            {
                boom--;
                Instantiate(tone,this.transform.position,this.transform.rotation);
             
            }
        }


    }
    public GameObject tone;


    public Image[] hpimg;
    public Sprite hpon, hpoff;

    public TextMeshProUGUI boomui;

    public float speed = 1;
    public void move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x += Horizontal * Time.deltaTime * speed;
        Position.y += Vertical * Time.deltaTime * speed;

        transform.position = new Vector3(Mathf.Clamp(Position.x, -2.8f, 2.8f), Mathf.Clamp(Position.y, -4.7f, 4.7f), 0);
    }




    public GameObject Bullet, hiteff;
    public float bulletspeed;
    public float bulletfirespeed;
    public void fire(int num)
    {
        if (num >= 5)
        {
            num = 5;
        }

        int[] a = new int[num];
        switch (num)
        {
            case 1: a[0] = 0;            break;
            case 2: a[0] = -3; a[1] = 3; break;
            case 3: a[0] = -4; a[1] = 0; a[2] = 4; break;
            case 4: a[0] = -6; a[1] = -3; a[2] = 3; a[3] = 6; break;
            case 5: a[0] = -7; a[1] = -4; a[2] = 0; a[3] = 4; a[4] = 7; break;

        }
        GameObject[] bullet = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            bullet[i] = Instantiate(Bullet, transform.position, transform.rotation);
            bullet[i].GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(a[i], Vector3.forward) * Vector2.up * bulletspeed);

        }

    }
    public void invoff() { inv = false; }
    public bool onedie;
    bool inv;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob")&&!inv)
        {
            this.GetComponent<Animator>().SetTrigger("hit");
            Instantiate(hiteff, this.transform.position, this.transform.rotation);
            inv = true;
            hp--;
            Invoke("invoff", 1f);
            if(hp<=0)
            onedie = true;
        }
        else if (collision.CompareTag("postion"))
        {
            if (hp < 3)
            {
                hp++;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("boom"))
        {
            boom++;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("knife"))
        {
            knife++;
            Destroy(collision.gameObject);
        }
    }

}
