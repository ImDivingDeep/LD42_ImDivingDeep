using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public IntRange damage = new IntRange(25, 50);
    private bool canDoDamage = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (canDoDamage)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                print(col.gameObject.name);
                if (col.GetComponent<Enemy>())
                {
                    col.GetComponent<Enemy>().DoDamage(damage.Random);
                }
                StartCoroutine(WaitForTransition());
            }
        }
    }

    IEnumerator WaitForTransition()
    {
        canDoDamage = false;
        yield return new WaitUntil(() => GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") == false);
        canDoDamage = true;
    }
}
