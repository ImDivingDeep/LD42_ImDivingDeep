using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rbd;

    public int maxHealth = 100;
    public int currentHealth = 100;

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

        if (moveHorizontal > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.y);
        else if (moveHorizontal < 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180.0f, transform.rotation.y);

        if (moveHorizontal != 0 || moveVertical != 0)
            GetComponent<Animator>().SetBool("IsWalking", true);
        else
            GetComponent<Animator>().SetBool("IsWalking", false);

        //Use the two store floats to create a new Vector2 variable movement.
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rbd.AddForce(movement * speed);
        rbd.velocity = new Vector3(moveHorizontal * speed, moveVertical * speed);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
            Attack();

        if(currentHealth < 0)
        {

        }

	}

    void Attack()
    {
        if (transform.Find("Weapon").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Idle") && !transform.Find("Weapon").GetComponent<Animator>().IsInTransition(0))
        {
            transform.Find("Weapon").GetComponent<Animator>().SetTrigger("Attack");
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.5f);
            GetComponent<AudioSource>().Play();
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        GameController.instance.UpdateHealthbar();
    }
}
