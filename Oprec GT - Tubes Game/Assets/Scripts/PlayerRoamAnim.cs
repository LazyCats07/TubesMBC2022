using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoamAnim : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true, facingLeft = true;
    float velX,Vely,speed=1f;

    void inisiasi()
    {
        Start();
    }
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            speed = 2f;
        else
            speed = 2f;
        
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
}
