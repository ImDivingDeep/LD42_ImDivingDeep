using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : Enemy {

    Boss boss;

    public IntRange damage = new IntRange(10, 20);

	// Use this for initialization
	override public void Start () {

        boss = transform.parent.GetComponent<Boss>();


    }
	
	// Update is called once per frame
	override public void Update () {
		
	}

    public override void Die()
    {
        boss.swordsleft -= 1;
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(boss.canDamage)
        {
            if(collision.GetComponent<SheepController>())
            {
                collision.GetComponent<SheepController>().Damage(damage.Random);
                Destroy(gameObject);
            }
        }
    }
}
