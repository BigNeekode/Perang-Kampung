using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class UnitHealtUI : MonoBehaviour
{
    [SerializeField] UnitStats _unitStats;
    Slider _slider;

    private void Start()
    {
        _unitStats = GetComponentInParent<UnitStats>();
        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = _unitStats.Health;
        _slider.value = _unitStats.Health;
    }

    private void Update()
    {
        _slider.value = _unitStats.Health;
    }
}
