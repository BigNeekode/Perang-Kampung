using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStat", menuName = "Unit/UnitStat")]
public class UnitStat : ScriptableObject    
{
    public string UnitName;

    public float Health;
    public float Damage;
    public float Speed;
    public float AttackRange;
    public int Cost;
}
