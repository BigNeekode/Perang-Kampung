using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField]UnitStat _unitStat;
    public string UnitName;
    public float Health;
    public float Damage;
    public float Speed;
    public float AttackRange;
    public int Cost;

    private void Awake()
    {
        UnitName = _unitStat.UnitName;
        Health = _unitStat.Health;
        Damage = _unitStat.Damage;
        Speed = _unitStat.Speed;
        AttackRange = _unitStat.AttackRange;
        Cost = _unitStat.Cost;
    }

    public void DamageUnit(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            KillUnit();
        }
    }

    private void KillUnit()
    {
        Destroy(gameObject);
    }
}
