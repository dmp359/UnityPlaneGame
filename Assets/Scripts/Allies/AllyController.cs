using UnityEngine;
using System.Collections;

public class AllyController : MonoBehaviour
{

    public float TimeBetweenShots = 3f;


    private float xOffset = .25f;
    private float yOffset = .25f;
    private int cannon = -1;
    private float bulletLaunchForce = 200f;
    private float facing = 1;

	void Awake()
	{
        if (transform.position.x > 0)
            facing = -1;
        transform.Rotate(0, 0, -facing * 45);
        InvokeRepeating("Shoot", TimeBetweenShots, TimeBetweenShots);
	}

	void Update()
	{
			
	}

    void Shoot() {
        GameObject instance = Instantiate(Resources.Load("Bullet", typeof(GameObject)), transform.position + new Vector3(cannon * xOffset, yOffset, -1), Quaternion.identity) as GameObject;

        // Shoot at appropriate angle. Note: not really working well on some quadrants
        instance.transform.Rotate(0, 0, -facing * 45);
        instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(facing * Mathf.Cos(transform.eulerAngles.z) * bulletLaunchForce, Mathf.Sin(transform.eulerAngles.z) * bulletLaunchForce));
        Destroy(instance, 6);
    }
}
