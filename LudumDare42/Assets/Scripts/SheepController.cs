using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rbd;

    private static int _health;

	// Use this for initialization
	void Start () {

        rbd = GetComponent<Rigidbody2D>();

	}

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rbd.AddForce(movement * speed);
        rbd.velocity = new Vector3(moveHorizontal * speed, moveVertical * speed);
    }

    // Update is called once per frame
    void Update () {
		
        if(_health < 0)
        {

        }

	}

    public static void Damage(int damage)
    {
        _health -= damage;
    }
}
