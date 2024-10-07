using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Economy : MonoBehaviour
{
    public int _gold;
    public int playerHealth;
    public int enemyHealth;
    public int goldRegenerationRate;
    [SerializeField] private UnityEvent Win;
    [SerializeField] private UnityEvent Lose;
    [SerializeField] private GameObject pauseCanvas;

    public static Economy instance;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            return;
        } else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            return;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        AddGold(100);
        StartCoroutine(RegenerateGold());
    }

    //couroutine to regenerate gold
    private IEnumerator RegenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddGold(goldRegenerationRate);
        }
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
