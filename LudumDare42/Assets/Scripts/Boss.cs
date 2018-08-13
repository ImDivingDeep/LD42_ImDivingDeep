using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Attack1and5,
    Attack2and4,
    Attack13and5,
    AttackAll
}

public class Boss : MonoBehaviour {
    

    public IntRange specialCooldown = new IntRange(2, 5);
    private float currentCooldown;
    public int swordsleft = 5;

    public bool canDamage;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if(swordsleft == 0)
        {
            Destroy(gameObject);
        }

        currentCooldown -= Time.deltaTime;
        Decide();
		
	}

    void Decide()
    {
        if(currentCooldown < 0)
        {
            BossState randomAttack = (BossState)Random.Range(0, 3);
            Attack(randomAttack.ToString());
            currentCooldown = specialCooldown.Random;
        }
    }

    void Attack(string attack)
    {
        GetComponent<Animator>().SetTrigger(attack);
    }

    public void StartDamage()
    {
        canDamage = true;
    }

    public void StopDamage()
    {
        canDamage = false;
    }


}
