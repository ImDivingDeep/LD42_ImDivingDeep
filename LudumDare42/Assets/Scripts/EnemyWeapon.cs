using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    bool IsHittingPlayer = false;
    public IntRange damage = new IntRange(5, 15);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage()
    {
        if (IsHittingPlayer)
            GameController.instance._player.GetComponent<SheepController>().Damage(damage.Random);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SheepController>())
            IsHittingPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SheepController>())
            IsHittingPlayer = false;
    }
}
