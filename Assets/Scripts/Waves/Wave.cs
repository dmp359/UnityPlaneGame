using UnityEngine;
using System.Collections;

public class Wave
{
    public ArrayList Enemies = new ArrayList();
    public float TimeBetweenEnemies { get; set; } // in seconds

    public Wave() {
        
    }
    public Wave(ArrayList enemies, float time) {
        Enemies = enemies;
        TimeBetweenEnemies = time;
    }

}
