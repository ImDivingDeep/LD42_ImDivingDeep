using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour {

    public Sprite brokenTexture;
    public GameObject[] lootTable;
    public int lootChance;

    private bool broken = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!broken)
        {
            if (collision.GetComponent<Weapon>())
            {
                if (collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    broken = true;
                    GetComponent<SpriteRenderer>().sprite = brokenTexture;
                    int number = Random.Range(0, 100);
                    if (number < lootChance)
                        SpawnRandomItem();
                }
            }
        }
    }

    void SpawnRandomItem()
    {
        Instantiate(lootTable[Random.Range(0, lootTable.Length - 1)], transform.position, Quaternion.identity);
    }


}
