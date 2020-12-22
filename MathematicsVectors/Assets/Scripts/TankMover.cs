using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private Transform _tank;
    [SerializeField] private Transform _fuel;
    [SerializeField] private float _speed;

    private Vector3 _direction;


    //private void Start()
    //{
    //    float angle = Vector3.Angle(_tank.up, _fuel.position - _tank.position);

    //    //if (Vector3.Cross(_tank.up, (_fuel.position - _tank.position).normalized).z < 0)
    //    //    _tank.rotation *= Quaternion.Euler(0, 0, -angle);
    //    //else
    //    //    _tank.rotation *= Quaternion.Euler(0, 0, angle);

    //    _tank.up = new Vector3(0.9f, 0.5f, 0.0f);
    //    print(_tank.up);
    //}

    private void Update()
    {
        TurnToGoal();
    }

    private void TurnToGoal()
    {
        float angle = Vector3.Angle(_tank.up, _fuel.position - _tank.position);

        if (angle != 0)
        {
            if (Vector3.Cross(_tank.up, (_fuel.position - _tank.position).normalized).z < 0)
                _tank.rotation *= Quaternion.Euler(0, 0, -angle);
            else
                _tank.rotation *= Quaternion.Euler(0, 0, angle);
        }
    }
}
