using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float yLockTop = -1;
    [SerializeField] private float yLockBottom = -6f;

    [SerializeField] private float xLockLeft = -7.5f;
    [SerializeField] private float xLockRight = 7.5f;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horiz, vert, 0f);

        // Stop the player from going too far up/down/left/right
        if ((transform.position.y >= yLockTop && movement.y > 0) || (transform.position.y <= yLockBottom && movement.y < 0) ||
            (transform.position.x <= xLockLeft && movement.x < 0) || (transform.position.x >= xLockRight && movement.x > 0))
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.AddForce(movement * movementSpeed);

        if (Input.GetKeyDown(KeyCode.F)) {
            GameObject instance = Instantiate(Resources.Load("Helper1", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;

        }
	}
}
