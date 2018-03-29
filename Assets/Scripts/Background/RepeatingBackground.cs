using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D backgroundCollider;
    private float backgroundSize;

    void Start () {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundSize = backgroundCollider.size.y;
	}
	
    void Update () {
        if (transform.position.y < -backgroundSize)
            RepeatBackground();
	}

    void RepeatBackground() {
        Vector2 offset = new Vector2(0, backgroundSize * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
