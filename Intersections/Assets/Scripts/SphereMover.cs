using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _player;

    private void Update()
    {
        _player.position = SetPositionBetweenTwoPoints(_start.position, _end.position, -0.25f);
    }

    private Vector3 SetPositionBetweenTwoPoints(Vector3 start, Vector3 end, float t)
    {
        // как считается вектор, все по шагам
        Vector3 v = end - start; // не забывай !!! вектор из B -> A !!!!
        Vector3 vt = v * t;
        Vector3 lt = start + vt;

        return lt; // нужная точка между линиями
    }

    private void ParametricPoint(Vector3 point, Vector3 v, Vector3 u, float s, float t)
    {
        //P(s, t) = point + vs + ut;
        Vector3 vs = v * s;
        Vector3 ut = u * t;

        Vector3 pst; //ParametricPoint

        pst = point + ut + vs;
    }
}
