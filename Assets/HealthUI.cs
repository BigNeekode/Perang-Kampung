using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private Economy _economy;
    int playerHealth;
    int enemyHealth;
    [SerializeField]private GameObject[] hearthIcon;

    // Update is called once per frame
    private void Start() {
        _economy = GameObject.FindGameObjectWithTag("Economy").GetComponent<Economy>();
    }
    void Update()
    {
        playerHealth = _economy.playerHealth;
        enemyHealth = _economy.enemyHealth;

        if (playerHealth == 3)
        {
            hearthIcon[0].SetActive(true);
            hearthIcon[1].SetActive(true);
            hearthIcon[2].SetActive(true);
        }
        else if (playerHealth == 2)
        {
            hearthIcon[0].SetActive(true);
            hearthIcon[1].SetActive(true);
            hearthIcon[2].SetActive(false);
        }
        else if (playerHealth == 1)
        {
            hearthIcon[0].SetActive(true);
            hearthIcon[1].SetActive(false);
            hearthIcon[2].SetActive(false);
        }
        else if (playerHealth == 0)
        {
            hearthIcon[0].SetActive(false);
            hearthIcon[1].SetActive(false);
            hearthIcon[2].SetActive(false);
        }

        if (enemyHealth == 3)
        {
            hearthIcon[3].SetActive(true);
            hearthIcon[4].SetActive(true);
            hearthIcon[5].SetActive(true);
        }
        else if (enemyHealth == 2)
        {
            hearthIcon[3].SetActive(true);
            hearthIcon[4].SetActive(true);
            hearthIcon[5].SetActive(false);
        }
        else if (enemyHealth == 1)
        {
            hearthIcon[3].SetActive(true);
            hearthIcon[4].SetActive(false);
            hearthIcon[5].SetActive(false);
        }
        else if (enemyHealth == 0)
        {
            hearthIcon[3].SetActive(false);
            hearthIcon[4].SetActive(false);
            hearthIcon[5].SetActive(false);
        }
    }
}
