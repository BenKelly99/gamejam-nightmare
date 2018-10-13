using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    GameObject playerObject;
    public float move_speed, dash_speed, dash_duration, dash_cooldown, jump_force;
    private bool dbl_jump, dashing;
    private float last_dash;
    private Vector2 dir;
	// Use this for initialization
	void Awake () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        dbl_jump = true;
        dashing = false;
        dir = Vector2.right;
        last_dash = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = playerObject.GetComponent<Rigidbody2D>().velocity;
        vel.x = 0;
        if (Input.GetKeyDown(KeyCode.Space) && last_dash + dash_cooldown <= Time.time)
        {
            dashing = true;
            last_dash = Time.time;
        }
        if (!dashing || last_dash + dash_duration <= Time.time)
        {
            dashing = false;
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(jump_force * Vector2.up);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerObject.transform.position = (Vector2)playerObject.transform.position + Time.deltaTime * move_speed * Vector2.right;
                dir = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerObject.transform.position = (Vector2)playerObject.transform.position + Time.deltaTime * move_speed * Vector2.left;
                dir = Vector2.left;
            }
        }
        else
        {
            playerObject.transform.position = (Vector2)playerObject.transform.position + Time.deltaTime * dash_speed * dir;
        }
        print(dashing);
    }
}
