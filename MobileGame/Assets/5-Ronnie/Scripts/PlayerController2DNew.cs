using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DNew : MonoBehaviour {
    Rigidbody2D rb;
    private float speed;
    public bool isFlat = true;
    //determine if player is touching ground, do not want double jumps
    bool isGround;
    //Vector Coordinates for Acceleration of Android Device
    Vector3 androidFacingme = new Vector3(0.0f, 0.0f, -1);
    Vector3 phoneFlatOnTable = new Vector3(0.0f, -1, 0.0f);
    Vector3 sprint = new Vector3(0.6f, -0.75f, -0.13f);
    Vector3 slowDown = new Vector3(-0.3f, -1, -0.07f);
    Vector3 reverse = new Vector3(-1f, -1, -0.07f);

    [SerializeField] Transform groundCheck;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    private void FixedUpdate() {
        Vector3 tilt = Input.acceleration;
        float tiltx = Input.acceleration.x;
        float tilty = Input.acceleration.y;
        float tiltz = Input.acceleration.z;
        Debug.Log("x: " + tiltx + "-- y: " + tilty + "-- z: " + tiltz);

        

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) {
            isGround = true;
        }
        else {
            isGround = false;
        }

        if (tiltx >= 0.4)
        { //Go super fast
            rb.velocity = new Vector2(1.5f * speed, rb.velocity.y);
        }
        else if (tiltx >= 0.3)
        { //Go forward
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (tiltx >= 1.0){ //Go forward slowly
            rb.velocity = new Vector2(1 * speed/2, rb.velocity.y);
        }
        else if (tiltx <= -0.3) { //Go backwards
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if(Input.GetKey("up") && rb.position.x >= 91.5 && rb.position.x <= 92.5) {
            //temp respawn to beginning of level, will add more.
            transform.position = new Vector2(-8, -1);
        }
        else if (tiltz >= 0.2 && isGround) { //jump if screen is facing down towards you
            rb.velocity = new Vector2(rb.velocity.x, 9.5f);
        }

        if(rb.position.y < -3f) {
            transform.position = new Vector2(-8, -1);
        }
    }



    public void PlayerJump()
    {

    
            if (isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 9.5f);
            }
        
    }
}
