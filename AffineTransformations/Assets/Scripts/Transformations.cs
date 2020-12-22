using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    [SerializeField] private GameObject _point;
    [SerializeField] private float _angle;
    [SerializeField] private Vector3 _translation;

    private void Start()
    {
        Coords position = new Coords(_point.transform.position, 1);

        _point.transform.position = HolisticMath.Translate(position, new Coords(_translation, 0).ToVector()).ToVector();
    }
}
