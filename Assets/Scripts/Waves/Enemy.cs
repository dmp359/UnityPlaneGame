using UnityEngine;
using System.Collections;

public class Enemy {
    /*
     * AIManager create Enemys
     */

    public string Name { get; set; } // like green plane. can move to base classes later for types
    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    
    private AIManager aiManRef;
    private Wave currentWave;

    public Enemy(AIManager reference, Wave w) {
        aiManRef = reference;
        currentWave = w;
    }



}
