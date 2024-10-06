using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Economy : MonoBehaviour
{
    public int _gold;
    public int playerHealth;
    public int enemyHealth;
    [SerializeField] private UnityEvent Win;
    [SerializeField] private UnityEvent Lose;

    private void Start()
    {
        AddGold(100);
    }

    public void AddGold(int amount)
    {
        _gold += amount;
    }

    public void SpendGold(int amount)
    {
        _gold -= amount;
    }   
    public void hitEnemy(){
        enemyHealth -= 1;
        if(enemyHealth == 0){
            Win.Invoke();
        }
    }
    public void hitPlayer(){
        playerHealth -= 1;
        if(playerHealth == 0){
            Lose.Invoke();
        }
    }

}
