using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item {

    public int healingAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnUse()
    {
        GameController.instance._player.GetComponent<SheepController>().currentHealth += healingAmount;

        if (GameController.instance._player.GetComponent<SheepController>().currentHealth > GameController.instance._player.GetComponent<SheepController>().maxHealth)
            GameController.instance._player.GetComponent<SheepController>().currentHealth = GameController.instance._player.GetComponent<SheepController>().maxHealth;

        GameController.instance.UpdateHealthbar();

        base.OnUse();
    }
}
