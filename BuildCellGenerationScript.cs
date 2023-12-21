using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCellGenerationScript : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    private Transform _cellGeneratorTransform;
    private Transform _startingPointOfGenerator;
    private int _amountOfCells = 8;
    private const float _distanceBetweenCells = 3.5f;
    //public List<GameObject> Cells;
    private int _cellNumber;
    private const float _heightOfCells = 0.01000024f;

    private void Awake()
    {
        _cellGeneratorTransform = GetComponent<Transform>();
        _startingPointOfGenerator = _cellGeneratorTransform;
        //Cells = new List<GameObject>();
    }

    void Start()
    {
        for (int i = 0; i < _amountOfCells; i++)
        {
            Vector3 startingPosition = transform.position;

            for (int j = 0; j < _amountOfCells;  j++)
            {
                GameObject cellClone =  Instantiate(cell, new Vector3(transform.position.x, _heightOfCells, transform.position.z), Quaternion.identity);
                _cellNumber++;
                cellClone.name = "CellClone " + (_cellNumber);
                //Cells.Add(cellClone);
                transform.Translate(_distanceBetweenCells, 0, 0);
            }
            transform.position = startingPosition;
            transform.Translate(0, 0, -_distanceBetweenCells);
            startingPosition = transform.position;
        }
    }
}
