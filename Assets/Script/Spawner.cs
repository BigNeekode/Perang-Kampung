using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    class Unit
    {
        public enum SpawnType { Enemy, Player };
        public SpawnType _spawnType;
        public GameObject _unitPrefab;
        public Color _unitColor;
    }
    [SerializeField] Unit[] _units;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _spawnInterval;
    private Coroutine _autoSpawnCoroutine;

    private void Start()
    {
        StartAutoSpawn();
    }

    public void SpawnUnit(int unitIndex)
    {
        if (unitIndex < 0 || unitIndex >= _units.Length)
        {
            return;
        }

        Unit unitToSpawn = _units[unitIndex];
        GameObject instantiatedUnit = Instantiate(unitToSpawn._unitPrefab, _spawnPoint.position + new Vector3(Random.Range(-3,3),0,0), Quaternion.identity);

        UnitController unitController = instantiatedUnit.GetComponent<UnitController>();
        if (unitController != null)
        {
            if (unitToSpawn._spawnType == Unit.SpawnType.Enemy)
            {
                //change the gameobject tag and layer
                instantiatedUnit.tag = "Enemy";
                instantiatedUnit.layer = LayerMask.NameToLayer("Enemy");
                //change material base color
                foreach (var renderer in instantiatedUnit.GetComponentsInChildren<Renderer>())
                {
                    renderer.material.color = unitToSpawn._unitColor;
                }
                unitController._targetType = UnitController.TargetType.Player;
            }
            else if (unitToSpawn._spawnType == Unit.SpawnType.Player)
            {
                //change the gameobject tag and layer
                instantiatedUnit.tag = "Player";
                instantiatedUnit.layer = LayerMask.NameToLayer("Player");
                unitController._targetType = UnitController.TargetType.Enemy;
            }
        }
        else
        {
            Debug.LogError("UnitController component not found on instantiated unit");
        }
    }

    public void StartAutoSpawn()
    {
        if (_autoSpawnCoroutine == null)
        {
            _autoSpawnCoroutine = StartCoroutine(AutoSpawn());
        }
    }

    public void StopAutoSpawn()
    {
        if (_autoSpawnCoroutine != null)
        {
            StopCoroutine(_autoSpawnCoroutine);
            _autoSpawnCoroutine = null;
        }
    }

    private IEnumerator AutoSpawn()
    {
        while (true)
        {
            SpawnUnit(Random.Range(0, _units.Length));
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
