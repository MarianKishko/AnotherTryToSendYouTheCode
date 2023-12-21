using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Cell _cellClass;
    private float _speed = 75f;
    private float _horizontal;
    private float _vertical;
    private float _scrollWheel;
    private float _zoomingSpeed;
    private Ray ray;

    private void Awake()
    {
        _zoomingSpeed = _speed * 2;
    }

    void Update()
    {
        Interact();

        _scrollWheel = Input.GetAxis("Mouse ScrollWheel") * _zoomingSpeed * Time.deltaTime;
        transform.Translate(0, _scrollWheel, 0);

        Moving();
    }

    void Moving ()
    {
        if (Input.GetMouseButton(1))
        {
            _horizontal = Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
            _vertical = Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;

            transform.Translate(_horizontal, 0, _vertical);
        }
    }

    void Interact()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 40, Color.blue);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Cell>())
            {
                hit.transform.gameObject.GetComponent<Cell>().InterectWithTheCursor();
                
                if (Input.GetMouseButtonDown(0))
                {
                    // The problem is it works only I clicking the gameobject with Cell script, NOT the variable that is inside of the parent gameobject
                    if (hit.transform.gameObject.GetComponent<Cell>() || hit.transform.gameObject.GetComponent<Cell>().isBuildingNotSelected())
                    {
                        hit.transform.gameObject.GetComponent<Cell>().Build();
                    }
                }
            }

            Debug.Log(hit.transform.gameObject.name);
        }
    }
}
