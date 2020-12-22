using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlaneIntersections : MonoBehaviour
{
    [SerializeField] private Transform _sphere;
    [SerializeField] private GameObject _quad; // это как plane только плоский

    private UnityEngine.Plane _plane;

    private void Start()
    {
        Vector3[] vertisec = _quad.GetComponent<MeshFilter>().mesh.vertices;
        // переводим в мировые координаты
        vertisec[0] = _quad.transform.TransformPoint(vertisec[0]);
        vertisec[1] = _quad.transform.TransformPoint(vertisec[2]);
        vertisec[2] = _quad.transform.TransformPoint(vertisec[3]);
        _plane = new UnityEngine.Plane(vertisec[0], vertisec[1], vertisec[2]);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float t = 0.01f;

            if (_plane.Raycast(ray, out t))
            {
                Vector3 vector = ray.GetPoint(t);
                _sphere.position = vector;
            }

        }
    }
}
