using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _building;

    public void InterectWithTheCursor()
    {
        _building.transform.position = new Vector3(transform.position.x, 1.02f, transform.position.z);
    }

    public void Build()
    {
        Instantiate(_building, _building.transform.position, Quaternion.identity);
    }

    public bool isBuildingNotSelected()
    {
        return _building == null;
    }
}
