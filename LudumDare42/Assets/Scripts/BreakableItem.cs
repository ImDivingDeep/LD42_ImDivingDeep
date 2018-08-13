using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour {

    public Sprite brokenTexture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Weapon>())
        {
            if (collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                GetComponent<SpriteRenderer>().sprite = brokenTexture;
            }
        }
    }
}
