using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum States // used by all logic
{
    None,
    Idle,
    Walk,
    Jump,
    Dead,
};

public class PlayerScript : MonoBehaviour
{
    States state;

    float timer = 0f;
    Rigidbody rb;
    bool grounded;
    public static int playerHealth;
    public GameObject bullet;
    public GameObject cannon;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody>();
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }

    void FixedUpdate()
    {
        grounded=false;
    }


    void DoLogic()
    {
        if( state == States.Idle )
        {
            PlayerIdle();
        }

        if( state == States.Jump )
        {
            PlayerJumping();
        }

        if( state == States.Walk )
        {
            PlayerWalk();
        }
        if ( state == States.Dead )
        {
            PlayerDead();
        }
    }


    void PlayerIdle()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3( 0,10,0);
        }

        if( Input.GetKey("left"))
        {
            transform.Rotate( 0, -0.5f, 0, Space.Self );

        }
        if( Input.GetKey("right"))
        {
            transform.Rotate( 0,0.5f, 0, Space.Self );
        }

        if( Input.GetKey("up"))
        {
            state = States.Walk;
        }
        Shooting();
    }

    void PlayerJumping()
    {
        // player is jumping, check for hitting the ground
        if( grounded == true )
        {
            //player has landed on floor
            state = States.Idle;
        }
        Shooting();
    }

    void PlayerWalk()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5f);

        //magnitude = the player's speed
        float magnitude = rb.velocity.magnitude;

       if (Input.GetKey("up"))
       {
            rb.AddForce(transform.forward * 5f);
       }
        
       else if (magnitude < 0.1f)
       {
            state = States.Idle;
       }
       Shooting();
       PlayerJumping();
       PlayerIdle();
    }
    void PlayerDead()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            rb.freezeRotation = false;
            Quaternion.Euler(45, 0, 0);
            state = States.Idle;
            transform.rotation = Quaternion.identity;
        }
    }


    void OnCollisionEnter( Collision col )
    {
        if( col.gameObject.tag == "Floor")
        {
            grounded=true;
            print("landed!");
        }
        if (col.gameObject.tag == "Enemy")
        {
            playerHealth--;
            print("Player Health = " + playerHealth);
        }
        if (PlayerScript.playerHealth < 1)
        {
            state=States.Dead;
            timer = 2;
            transform.position = new Vector3 (8,1,-3);
            state = States.Idle;
            playerHealth=5;
        }
       
        
    }
    void Shooting()
    {
        int moveDirection = 1;
        if (Input.GetKeyDown("a"))
        {
            GameObject clone;
            clone = Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 15;
            rb.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnGUI()
    {
        //debug text
        string text = "Left/Right arrows = Rotate\nSpace = Jump\nUp Arrow = Forward\nCurrent state=" + state;

        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();
    }
}
