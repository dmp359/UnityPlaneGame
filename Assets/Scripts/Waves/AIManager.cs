using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    private static float SCREEN_WIDTH;
    private static float SCREEN_HEIGHT;

    void Start () {
        SCREEN_HEIGHT = Camera.main.orthographicSize;
        SCREEN_WIDTH = SCREEN_HEIGHT * Camera.main.aspect;
        WaveFactory f = new WaveFactory();
        Wave test = f.CreateWave(this, 3, 1);
        SpawnWave(test);
    }

    void Update()
    {

    }

    public void SpawnWave(Wave w) {
        StartCoroutine(SpawnWaveLoop(w));
    }

    IEnumerator SpawnWaveLoop(Wave w) {
        foreach (Enemy enemy in w.Enemies) {
            InstantiateEnemy(enemy);
            yield return new WaitForSeconds(w.TimeBetweenEnemies);
        }
    }

    private void InstantiateEnemy(Enemy e) {
        // TODO: Set some variables of enemy as e

        float startingHeight = SCREEN_HEIGHT;
        GameObject instance = Instantiate(Resources.Load("Greeny", typeof(GameObject)), new Vector3(-SCREEN_WIDTH, startingHeight, -1), Quaternion.identity) as GameObject;
        instance.GetComponent<SnakeMovement>().TravelWidth = SCREEN_WIDTH;
        instance.GetComponent<SnakeMovement>().TravelStartingHeight = startingHeight;
        instance.GetComponent<SnakeMovement>().PlaneHeight = 1;
    }

}
