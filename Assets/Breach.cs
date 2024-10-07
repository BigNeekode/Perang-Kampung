using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breach : MonoBehaviour
{
    [System.Serializable]
 public enum BreachType
 {
     Player,
     Enemy
 }
    public BreachType breachType;

    private void OnTriggerEnter(Collider other) {
        if(breachType == BreachType.Player && other.CompareTag("Enemy")){
            Economy.instance.hitPlayer();
        }
        else if(breachType == BreachType.Enemy && other.CompareTag("Player")){
            Economy.instance.hitEnemy();
        }
    }
}
