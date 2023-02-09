using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRoamAnim : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true, facingLeft = true;
    float velX,Vely,speed=1f;

    public GameObject Battle;
    public GameObject Battle2;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject Cs1;
    //public List<string> items;

    public Text MyCoinText;
    //private int Coins;

    void inisiasi()
    {
        Start();
    }
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Coins = 0;
        // MyCoinText.text = "" + Coins;
        
        
    }

    void Update()
    {
        speed = 2f;
        // if(Input.GetKey(KeyCode.LeftShift))
        //     speed = 10f;
        // else
        //     speed = 2f;
        
        AnimationState();
        MoveRight();
        MoveLeft();
        MoveUp();
        MoveDown();
        MoveDiagonal();

        velX = Input.GetAxisRaw ("Horizontal") * speed;
        Vely = Input.GetAxisRaw ("Vertical") * speed;
    }

    void FixedUpdate ()
    {
        rb.velocity = new Vector2 (velX,Vely);
    }

    void CheckWhereToFace()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        }
        else if (velX<0)
        {
            facingLeft = true;
        }
        if (((facingLeft) && (localScale.x<0)) || (facingRight) && (localScale.x>0))
        {
            localScale.x += 1;
        }

        transform.localScale = localScale;
    }

    void AnimationState()
    {
        if (velX == 0)
        {
            anim.SetBool("IsWalking",false);
            anim.SetBool("MovingLeft",false);
            anim.SetBool("MovingDown",false);
            anim.SetBool("MovingUp",false);
        }
    }

    void MoveRight()
    {
        if (Mathf.Abs(velX)==2 && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsWalking",true);
            anim.SetBool("MovingLeft",false);
            anim.SetBool("MovingDown",false);
            anim.SetBool("MovingUp",false);
            inisiasi();
        }
    }

    void MoveLeft()
    {
        if (Mathf.Abs(velX)== 2 && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("MovingLeft",true);
            anim.SetBool("IsWalking",false);
            anim.SetBool("MovingDown",false);
            anim.SetBool("MovingUp",false);
            inisiasi();
        }
    }

    void MoveDown()
    {
        if (Mathf.Abs(Vely)==2 && Input.GetKey(KeyCode.S))
        {
            anim.SetBool("MovingDown",true);
            anim.SetBool("IsWalking",false);
            anim.SetBool("MovingLeft",false);
            anim.SetBool("MovingUp",false);
            inisiasi();
        }
    }

    void MoveUp()
    {
        if (Mathf.Abs(Vely)==2 && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("MovingUp",true);
            anim.SetBool("IsWalking",false);
            anim.SetBool("MovingLeft",false);
            anim.SetBool("MovingDown",false);
            inisiasi();
        }
    }

    void MoveDiagonal()
    {
        if (Mathf.Abs(Vely)==2 && Mathf.Abs(velX)==2 && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        else if (Mathf.Abs(Vely)==2 && Mathf.Abs(velX)==2 && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        else if (Mathf.Abs(Vely)==2 && Mathf.Abs(velX)==2 && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        else if (Mathf.Abs(Vely)==2 && Mathf.Abs(velX)==2 && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if(collider.tag == "Arrow_To_Area1_1")
        {
            SceneManager.LoadScene("Tutorial_RoamingAwal");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area1_2")
        {
            SceneManager.LoadScene("Tutorial_Roaming");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area2_1")
        {
            SceneManager.LoadScene("Area2_Roaming");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area2_Mid")
        {
            SceneManager.LoadScene("Area2_Mid");
            Time.timeScale = 1f;
            Collectables.instance.load();
            
        }
        if(collider.tag == "Arrow_To_Area2_Beach")
        {
            SceneManager.LoadScene("Area2_Beach");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area2_2")
        {
            SceneManager.LoadScene("Area2_Roaming2");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area3_1")
        {
            SceneManager.LoadScene("Area3_Roaming");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area3_2")
        {
            SceneManager.LoadScene("Area3_Roaming2");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area3_3")
        {
            SceneManager.LoadScene("Area3_Roaming3");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Area4")
        {
            GameObject.Find("Audio_Roaming").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("HuangLong_Cutscene");
            Time.timeScale = 1f;
            Collectables.instance.load();
        }
        if(collider.tag == "Arrow_To_Azatoth")
        {
            Collectables.instance.load();
            if(Collectables.instance.TotalCoins > 14)
            {
                Cs1.SetActive(true);
                Time.timeScale = 1f;
                bg1.SetActive(false);
                Time.timeScale = 0f;
                bg2.SetActive(false);
                Time.timeScale = 0f;
                GameObject.Find("Audio_Roaming").GetComponent<AudioSource>().Stop();
            }
                        
        }
        if(collider.tag == "Mob_area1")
        {
            Battle.SetActive(true);
            Time.timeScale = 1f;
            bg1.SetActive(false);
            Time.timeScale = 0f;
            bg2.SetActive(false);
            Time.timeScale = 0f;
            
        }
        if(collider.tag == "Mob_area2")
        {
            Battle2.SetActive(true);
            Time.timeScale = 1f;
            bg1.SetActive(false);
            Time.timeScale = 0f;
            bg2.SetActive(false);
            Time.timeScale = 0f;
        }
       
        
        if(collider.tag == "Coin")
        {
           
            Destroy(collider.gameObject);
            //GameObject.Find("Player").GetComponent<AudioSource>().Play();
            CoinSoundManager.instance.coins_source.PlayOneShot(CoinSoundManager.instance.coin_sound);
            Collectables.instance.Addcoin();
            // CollectCoin.instance.addC();
            // CollectCoin.instance.save();

            // Coins += 1;
            // string ItemType = collider.gameObject.GetComponent<Collectables>().ItemType;
            // print("Collected a " + ItemType);
            // items.Add(ItemType);
            // print("Inventory Length: " + items.Count);
            // MyCoinText.text = "" + Coins;
        }

        if(collider.tag == "Bahamut")
        {
            Cs1.SetActive(true);
            Time.timeScale = 1f;
            bg1.SetActive(false);
            Time.timeScale = 0f;
            bg2.SetActive(false);
            Time.timeScale = 0f;
            Destroy(collider.gameObject);
            GameObject.Find("Audio_Roaming").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_combatBoss").GetComponent<AudioSource>().Play();
        }

    }

}
