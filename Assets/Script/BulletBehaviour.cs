using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]UnitController _unitController;
    [SerializeField]Transform _target;

    private void Awake()
    {
        _unitController = GetComponentInParent<UnitController>();
    }

    private void Update()
    {
        flytoTarget();
    }

    private void flytoTarget()
    {
        _target = _unitController.GetTarget();
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, 15f * Time.deltaTime);
            if (Vector3.Distance(transform.position, _target.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
