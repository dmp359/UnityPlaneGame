using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    private float hp;
    private float deathDelay = .2f;
	void Start()
	{

	}

	void Update()
	{
			
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Bullet")) {
            GetComponent<Animator>().SetBool("isDead", true);
            Destroy(collision.gameObject, deathDelay); // destroy bullet
            Destroy (this.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); // destroy plane

        }
	}
}
