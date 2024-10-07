using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private Economy _economy;
    private TMPro.TextMeshProUGUI _goldText;

    private void Start()
    {
        _economy = GameObject.FindGameObjectWithTag("Economy").GetComponent<Economy>();
        _goldText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Update()
    {
        _goldText.text = _economy._gold.ToString();
    }
}
