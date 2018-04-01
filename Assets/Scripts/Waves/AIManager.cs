using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    private static float SCREEN_WIDTH;
    private static float SCREEN_HEIGHT;
    private float timeBetweenWaves = 5;
    private bool waveIsAlive = true;
    private List<Wave> waves;

    private int numPlanesThisRound = 0;
    private int numPlanesKilled = 0;
    private int round = 0;

    void Start () {
        waves = new List<Wave>();
        SCREEN_HEIGHT = Camera.main.orthographicSize;
        SCREEN_WIDTH = SCREEN_HEIGHT * Camera.main.aspect;
        WaveFactory f = new WaveFactory();
        Wave test = f.CreateWave(this, 3, 3); // TODO: Need the AI Manager passed in here?
        Wave test2 = f.CreateWave(this, 5, 3);
        Wave test3 = f.CreateWave(this, 8, 2);
        waves.Add(test);
        waves.Add(test2);
        waves.Add(test3);
        SpawnNextWave();
    }

    void Update()
    {

    }

    private void SpawnNextWave() {
        print("Starting round " + round);
        if (round < waves.Count)
            StartCoroutine(SpawnWaveAfterTime());
        else {
            print("YOU WIN");
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnWaveAfterTime() {
        yield return new WaitForSeconds(timeBetweenWaves);
        SpawnEnemies(waves[round]);
    }

    public void SpawnEnemies(Wave w) {
        StartCoroutine(SpawnWaveLoop(w));
    }

    IEnumerator SpawnWaveLoop(Wave w) {
        foreach (Enemy enemy in w.Enemies) {
            InstantiateEnemy(enemy);
            yield return new WaitForSeconds(w.TimeBetweenEnemies);
        }
    }

    private void InstantiateEnemy(Enemy e) {

        float startingHeight = SCREEN_HEIGHT;
        GameObject instance = Instantiate(Resources.Load("Greeny", typeof(GameObject)), new Vector3(-SCREEN_WIDTH, startingHeight, -1), Quaternion.identity) as GameObject;

        // TODO: Set some more variables of enemy
        instance.GetComponent<EnemyHealth>().AIMan = this;


        instance.GetComponent<SnakeMovement>().TravelWidth = SCREEN_WIDTH;
        instance.GetComponent<SnakeMovement>().TravelStartingHeight = startingHeight;
        instance.GetComponent<SnakeMovement>().PlaneHeight = 1;
    }

    public void OnPlaneDeath() {
        numPlanesKilled++;
        if (numPlanesKilled >= waves[round].Enemies.Count) {
            round++;
            numPlanesKilled = 0;
            SpawnNextWave();
        }
    }

}
