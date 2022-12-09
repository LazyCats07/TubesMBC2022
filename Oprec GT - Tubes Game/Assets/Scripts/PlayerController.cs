using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerBullet;
    public GameObject BulletPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     GameObject bullet = (GameObject)Instantiate (PlayerBullet);
        //     bullet.transform.position = BulletPos.transform.position;
        // }
        
        float horizontal = Input.GetAxis ("Horizontal"); 
        if (horizontal != 0f)
        if (horizontal > 0f)
             transform.Translate (5f * Time.deltaTime, 0f, 0f);
         else
            transform.Translate (-5f * Time.deltaTime, 0f, 0f);
 
        float vertical = Input.GetAxis ("Vertical"); 
        if (vertical != 0f)
        if (vertical > 0f)
            transform.Translate (0f, 5f * Time.deltaTime, 0f);
        else
            transform.Translate (0f, -5f * Time.deltaTime, 0f);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.53f, 8.53f),
            Mathf.Clamp(transform.position.y, -4f, 4.88f), transform.position.z);
    }

}
