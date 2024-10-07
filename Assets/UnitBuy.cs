using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitBuy : MonoBehaviour
{
    [SerializeField] private GameObject _unitPrefab;
    private GameObject _currentUnit;
    private Economy _economy;
    private bool _isPlacingUnit = false;
    public UnitStat unitStat;
    int unitCost;
    [SerializeField] TMPro.TextMeshProUGUI unitCostText;
    private void Start() {
        _economy = GameObject.FindGameObjectWithTag("Economy").GetComponent<Economy>();
        unitCost = unitStat.Cost;
        unitCostText.text = unitCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlacingUnit && _currentUnit != null)
        {
            Vector3 cursorPosition = GetCursorWorldPosition();
            _currentUnit.transform.position = cursorPosition;

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                PlaceUnit();
            }
        }
    }

    public void OnBuyUnit()
    {
        if (_unitPrefab != null && _economy != null && _economy._gold >= unitCost)
        {
            _economy.SpendGold(unitCost);
            // Instantiate the unit at the cursor position
            Vector3 cursorPosition = GetCursorWorldPosition();
            _currentUnit = Instantiate(_unitPrefab, cursorPosition, Quaternion.identity);
            _isPlacingUnit = true;
        }else{
            Debug.Log("Duid e gak pas");
        }
    }

    private Vector3 GetCursorWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit,LayerMask.GetMask("Ground")))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void PlaceUnit()
    {
        _isPlacingUnit = false;
        _currentUnit = null;
    }
}