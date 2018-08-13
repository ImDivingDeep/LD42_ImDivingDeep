using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Idle,
    ChasingPlayer,
    Attacking,
    NotMoving
}

public class Enemy : MonoBehaviour {
    
    public int speed;
    public int health;
    public IntRange attackCooldown = new IntRange(1, 5);

    private EnemyState state;
    private int cooldown;
    private float cooldownCurrent;


	// Use this for initialization
	public virtual void Start () {

        state = EnemyState.Idle;
    }
	
	// Update is called once per frame
	public virtual void Update () {

        if (!GameController.paused)
        {
            if (state == EnemyState.ChasingPlayer)
            {
                if (!IsPlayerStillInRange())
                {
                    state = EnemyState.Idle;
                    return;
                }
                cooldownCurrent += Time.deltaTime;
                LookAtPlayer();
                MoveTowardsPlayer();
                DecideToAttack();
            }
            else if (state == EnemyState.Idle)
            {
                if (DetectPlayer())
                {
                    state = EnemyState.ChasingPlayer;
                }
            }
            else if (state == EnemyState.Attacking)
            {
                StartCoroutine(Attack());
            }
            else if (state == EnemyState.NotMoving)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }


    }

    void DecideToAttack()
    {
        if (cooldownCurrent > cooldown)
        {
            if (Vector3.Distance(transform.position, GameController.instance._player.transform.position) < 2)
            {
                state = EnemyState.Attacking;
            }
        }
    }

    IEnumerator Attack()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        state = EnemyState.NotMoving;
        cooldown = attackCooldown.Random;
        cooldownCurrent = 0.0f;
        transform.Find("EnemyWeapon").GetComponent<Animator>().SetTrigger("Attack");
        yield return new WaitUntil(() => transform.Find("EnemyWeapon").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == false);
        state = EnemyState.ChasingPlayer;
    }

    public virtual void DoDamage(int damage)
    {
        health -= damage;

        print("received damage");

        Vector3 direction = GameController.instance._player.transform.position - transform.position;

        if(GetComponent<Rigidbody2D>())
            GetComponent<Rigidbody2D>().AddForce(-direction.normalized * 15, ForceMode2D.Impulse);

        if (health <= 0)
            Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    void LookAtPlayer()
    {
        
        if(GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180.0f, transform.rotation.y);
        else if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.y);
        
    }

    void MoveTowardsPlayer()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GameController.instance._player.transform.position, speed * Time.deltaTime);
        Vector3 direction = GameController.instance._player.transform.position - transform.position;
        //GetComponent<Rigidbody2D>().AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed, ForceMode2D.Force);
    }

    bool DetectPlayer()
    {
        if (Vector3.Distance(transform.position, GameController.instance._player.transform.position) > 15)
            return false;

        return true;

        //Advanced method for detecting player in range
        /*
        Vector3 targetDir = GameController.instance._player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.right);

        if (angle < GameController.instance.EnemyRangeOfSight)
            return true;
        else
            return false;

        */
    }
    


    bool IsPlayerStillInRange()
    {
        if (Vector3.Distance(transform.position, GameController.instance._player.transform.position) > 20)
            return false;

        return true;
    }
    
}
