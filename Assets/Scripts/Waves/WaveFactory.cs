using UnityEngine;
using System.Collections;

public class WaveFactory
{

    /*
     * Creates a wave and its enemies
     * TODO: Use algorithm/file
     */
    
    public Wave CreateWave(AIManager ai, int numEnemies, float timeBetweenEnemies) {
        ArrayList enemies = new ArrayList();
        Wave w = new Wave();
        w.TimeBetweenEnemies = timeBetweenEnemies;

        for (int i = 0; i < numEnemies; i++) {
            enemies.Add(new Enemy(ai, w));
        }

        w.Enemies = enemies;
        return w;
    }
}
