using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    // 1) Start at top left or top right (flip appropriately)
    // 2) travel across the screen
    // 3) rotate Z angle as approaching the end of the screen from 0 to 90
    // 4) move down a bit
    // repeat 2-4
    // maybe leave at 3/4 down

    [SerializeField] float movementSpeed = 4;
    public float TravelWidth;
    public float TravelStartingHeight;
    public float PlaneHeight; 
    private Rigidbody2D rb;

    private float terminalVelocity;
    private float slowDownFactor = -.1f;
    private float goalHeight;
    private float minVelocity = 0;
    private float slowDownDistance = 3;

    private bool moveInCircle = false;
    enum MovementDir { Right,Left};
    private MovementDir myDir;

    // Circle
    public Vector2 Velocity = new Vector2(4, 0);

    private float TurnSpeed = 5f;
    private float RotateSpeed = 50f;
    public float Radius = 1f;

    private Vector2 center;
    private float angle;
    private float spinAngle;

    void Awake () {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        MoveRight();
        terminalVelocity = movementSpeed; // for resetting after a slowdonw
        goalHeight = TravelStartingHeight;


    }
    private void MoveRight() {
        myDir = MovementDir.Right;
        rb.velocity = new Vector2(movementSpeed, 0);
    }

    private void MoveLeft() {
        myDir = MovementDir.Left;
        rb.velocity = new Vector2(-movementSpeed, 0);
    }

	void HorizontalMovement(int dir) {
        float distanceToEnd = Vector2.Distance(transform.position, new Vector2(dir * TravelWidth, goalHeight));
        if (distanceToEnd < slowDownDistance)
        {
            // rb.AddForce(new Vector2(slowDownFactor, 0));
        }
      //  print(distanceToEnd);
        // End is reached. Turn around
        if (distanceToEnd <= 2f)
        {
            //goalHeight -= PlaneHeight;

            center = new Vector2(transform.position.x, transform.position.y - PlaneHeight);
            goalHeight = transform.position.y - PlaneHeight;
            moveInCircle = true;

           // StartCoroutine(Rotation(transform, new Vector3(0, 0, -dir * 90), 3 / Mathf.Abs(rb.velocity.x)));

        }
    }

    void Update () {
        if (myDir == MovementDir.Right && !moveInCircle)
            HorizontalMovement(1);
        if (myDir == MovementDir.Left && !moveInCircle)
            HorizontalMovement(-1);
        if (moveInCircle) {
            int side = myDir == MovementDir.Right ? 1 : -1;
            if (side == 1)
                angle += TurnSpeed * Time.deltaTime;
            else
                angle -= TurnSpeed * Time.deltaTime;
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
            if (offset.y <= -.99) { // TODO: Get more accurate result
                moveInCircle = false;
                angle = 0;

                if (myDir == MovementDir.Right)
                    MoveLeft();
                else
                    MoveRight();
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, side * 270), Time.time);
            transform.position = center + offset;
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(center, 0.1f);
        Gizmos.DrawLine(center, transform.position);
    }
}
