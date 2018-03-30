using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float hp;

    [Header("Health Bar Fill Image")]
    public Image healthBar; // From child health bar
    private float deathDelay = .2f;

    private Rigidbody2D rb;
	private void Start()
	{
        hp = 100;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Bullet")) {
            
            // TODO: Play bullet impact effect
            hp -= 20; // TODO: Make bullet damage class
            if (hp > 0)
                Destroy(collision.gameObject, 0); // destroy bullet now
            else {
                Destroy(collision.gameObject, deathDelay); // destroy bullet after delay to add force
                OnDeath();
            }
        }

        healthBar.fillAmount = hp / 100f;
	}


    private void OnDeath() {
        if (hp > 0)
            return;
        
        rb.freezeRotation = false;
        this.tag = "Untagged";
        GetComponentInChildren<Canvas>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
        Destroy(this.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); // destroy plane
    }
}
