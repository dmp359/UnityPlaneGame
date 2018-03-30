using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    private float xOffset = .25f;
    private float yOffset = .25f;
    private int cannon = -1;
    [SerializeField] private float bulletLaunchForce = 50;

    void Start()
	{

	}

    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject instance = Instantiate(Resources.Load("Bullet", typeof(GameObject)), transform.position + new Vector3(cannon * xOffset, yOffset, -1), Quaternion.identity) as GameObject;

            // Shoot at appropriate angle. Note: not really working well on some quadrants
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sin(transform.eulerAngles.z) * bulletLaunchForce, Mathf.Cos(transform.eulerAngles.z) * bulletLaunchForce));
            cannon *= -1; // alternate shooting
            Destroy(instance, 6);
        }
	}


}
