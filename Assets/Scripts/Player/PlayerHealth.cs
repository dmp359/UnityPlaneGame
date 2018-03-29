using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    private float deathDelay = 0.2f;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            GetComponent<Animator>().SetBool("isDead", true);
            Destroy(collision.gameObject, deathDelay); // destroy enemy plane
            Destroy(this.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); // destroy plane
        }
    }

}
