using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] UnitStats _unitStats;
    [SerializeField] Transform _target;
    public enum TargetType { Enemy, Player}
    public TargetType _targetType;
    [SerializeField] Transform _targetBase;
    [SerializeField] float _speed;
    Animator _animator;
    [SerializeField] GameObject _Bullet;
    [SerializeField] Transform _bulletSpawnPoint;
    Rigidbody _rigidbody;
    

    private void Start() {
        _unitStats = GetComponent<UnitStats>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _speed = _unitStats.Speed;

        if(_targetType == TargetType.Enemy)
        {
            _targetBase = GameObject.Find("EnemyBase").transform;
        }else if(_targetType == TargetType.Player)
        {
            _targetBase = GameObject.Find("PlayerBase").transform;
        }
    }

    private void Update()
    {
        if(_targetType == TargetType.Enemy)
        {
            TargetFinder("Enemy");
        }else if(_targetType == TargetType.Player)
        {
            TargetFinder("Player");
        }

        MoveTowardsTarget();
    }

    private void TargetFinder(string targetTag)
    {
        // Define the layer mask for the target
        int targetLayerMask = LayerMask.GetMask(targetTag);

        // Scan for closer targets in front of the unit
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f, targetLayerMask);
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(targetTag) && hitCollider.gameObject.activeInHierarchy)
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = hitCollider.transform;
                }
            }
        }
        _target = closestTarget;
        _target = _target == null ? _targetBase : _target;
    }
    private void MoveTowardsTarget()
{
    _animator.SetBool("Attack", false);
    if (_target != null)
    {
        transform.LookAt(_target);

        // Calculate the direction
        Vector3 direction = (_target.position - transform.position).normalized;

        // Use Rigidbody to move the unit, preserving collision interactions
        Vector3 newPosition = _rigidbody.position + direction * _speed * Time.deltaTime;
        _rigidbody.MovePosition(newPosition);
    }

    // Check if the target is in range
    if(Vector3.Distance(transform.position, _target.position) <= _unitStats.AttackRange)
    {
        _speed = 0;
        Attack();
    } else {
        _speed = _unitStats.Speed;
    }
}

    private void Attack()
    {
        _animator.SetBool("Attack", true);
        _speed = 0;
        //Attack the target
        Debug.Log("Attacking " + _target.name);
    }

    public Transform GetTarget()
    {
        return _target;
    }

    public void SummonBullet()
    {
      Instantiate(_Bullet, _bulletSpawnPoint.position, Quaternion.Euler(0, 90, 0),gameObject.transform);
    }
}
