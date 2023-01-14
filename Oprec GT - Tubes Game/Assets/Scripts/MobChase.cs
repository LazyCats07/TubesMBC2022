using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobChase : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float distanceBetween;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("Audio_Roaming").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_combat").GetComponent<AudioSource>().Play();
        }
    }
}
