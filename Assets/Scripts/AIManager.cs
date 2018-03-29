using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    private static float SCREEN_WIDTH;
    private static float SCREEN_HEIGHT;

    void Start () {
        SCREEN_HEIGHT = Camera.main.orthographicSize;
        SCREEN_WIDTH = SCREEN_HEIGHT * Camera.main.aspect;
        InvokeRepeating("SpawnGreenPlane", 0, 2);
       // SpawnGreenPlane();
    }

    void Update()
    {

    }

    public void SpawnGreenPlane() {
        float startingHeight = SCREEN_HEIGHT;
        GameObject instance = Instantiate(Resources.Load("Greeny", typeof(GameObject)), new Vector3(-SCREEN_WIDTH, startingHeight, -1), Quaternion.identity) as GameObject;
        instance.GetComponent<SnakeMovement>().TravelWidth = SCREEN_WIDTH;
        instance.GetComponent<SnakeMovement>().TravelStartingHeight = startingHeight;
        instance.GetComponent<SnakeMovement>().PlaneHeight = 1;

    }
}
