using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 5;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horiz, vert, 0f);

        rb.AddForce(movement * movementSpeed);
	}
}
