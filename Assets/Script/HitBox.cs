using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    enum HitBoxType { Melee, Projectile }
    [SerializeField] HitBoxType _hitBoxType;
    [SerializeField] UnitStats _targetUnitStats;
    [SerializeField] UnitStats _unitStats;
    [SerializeField]private bool _triggerProcessed = false;

    private void Start()
    {
        _unitStats = GetComponentInParent<UnitStats>();
        Debug.Log("HitBox initialized for " + gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
                if (_triggerProcessed) return; // Exit if the trigger has already been processed
        
        Debug.Log("Trigger detected with " + other.gameObject.name);
        if (_hitBoxType == HitBoxType.Melee)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit " + other.gameObject.name + " is an Enemy or Player");
                _targetUnitStats = other.gameObject.GetComponent<UnitStats>();
                UnitController targetUnitController = other.gameObject.GetComponent<UnitController>();
                UnitController parentUnitController = GetComponentInParent<UnitController>();
        
                if (_targetUnitStats != null && targetUnitController != null && parentUnitController != null)
                {
                    if (targetUnitController._targetType != parentUnitController._targetType)
                    {
                        _targetUnitStats.DamageUnit(_unitStats.Damage);
                        Debug.Log("Hit " + other.gameObject.name + " for " + _unitStats.Damage + " damage");
                        _triggerProcessed = true; // Set the flag to true after processing the trigger
                    }
                    else
                    {
                        Debug.Log("Friendly fire prevented on " + other.gameObject.name);
                    }
                }
                else
                {
                    Debug.Log("No UnitStats or UnitController component found on " + other.gameObject.name);
                }
            }
            else
            {
                Debug.Log(other.gameObject.name + " is not an Enemy or Player");
            }
        }
        
        else
        {
            Debug.Log("HitBox type is not Melee");
        }
        
    }

    private void OnDisable() {
        _triggerProcessed = false; // Reset the flag when the HitBox is disabled
    }
}
