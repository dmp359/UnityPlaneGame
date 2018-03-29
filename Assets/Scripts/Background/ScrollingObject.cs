using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] private float speed = -1.5f;
    public bool enableScrolling = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
	}
	
    void Update () {
        if (!enableScrolling)
            rb.velocity = Vector2.zero;
	}
}
