using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowLine : MonoBehaviour
{
    [SerializeField] private Transform _sphere;
    [SerializeField] private float _speed;

    private Vector3 _endPosition;

    private void Start()
    {
        //DrawPoint(new Vector3(0f, 0f, -1f), Color.yellow);

        //DrawLine(new Vector3(-100, 0, 0), new Vector3(200, 150, 0), Color.green);
        //DrawLine(new Vector3(0, -100, 0), new Vector3(0, 200, 0), Color.blue);

        _sphere.transform.position = new Vector3(-50, 0, 0);
        _endPosition = Intersection();
    }

    private void Update()
    {
        _sphere.position = Vector3.MoveTowards(_sphere.position, _endPosition, Time.deltaTime * _speed);
    }

    private void DrawPoint(Vector3 position, Color colour)
    {
        float width = 0.5f;
        GameObject point = new GameObject("Point_" + position.ToString());
        LineRenderer pointRenderer = point.AddComponent<LineRenderer>();
        pointRenderer.material = new Material(Shader.Find("Unlit/Color"));
        pointRenderer.material.color = colour;
        pointRenderer.positionCount = 2;
        pointRenderer.SetPosition(0, new Vector3(position.x - width, position.y - width, position.z));
        pointRenderer.SetPosition(1, new Vector3(position.x + width, position.y + width, position.z));
        pointRenderer.startWidth = width;
        pointRenderer.endWidth = width;
    }

   

    private Vector3 Intersection()
    {
        Vector3 pointA = new Vector3(-50, 0, 0);
        Vector3 pointAEnd = new Vector3(30, 60, 0);
        Vector3 v = pointAEnd - pointA;
        DrawLine(pointA, pointAEnd, Color.green);

        Vector3 pointB = new Vector3(0, -20, 0);
        Vector3 pointBEnd = new Vector3(10, 20, 0);
        Vector3 u = pointBEnd - pointB;
        DrawLine(pointB, pointBEnd, Color.blue);

        //Vector3 pointB = new Vector3(-100, 10, 0);
        //Vector3 pointBEnd = new Vector3(200, 160, 0);
        //Vector3 u = pointBEnd - pointB;
        //DrawLine(pointB, pointBEnd, Color.blue);

        Vector3 c = pointB - pointA;
        Vector3 c1 = pointA - pointB;

        Vector3 _uPerp = new Vector3(-u.y, u.x, u.z);
        Vector3 _vPerp = new Vector3(-v.y, v.x, v.z);

        //проверка на параллельность
        float checkPerp = Vector3.Dot(_uPerp, v);
        if (checkPerp == 0)
            return new Vector3(0, 0, 0);

        float t = (Vector3.Dot(_uPerp, c)) / (Vector3.Dot(_uPerp, v));
        Vector3 pos = pointA + (v * t);
        //float s = (Vector3.Dot(_vPerp, c1)) / (Vector3.Dot(_vPerp, u));
        //Vector3 pos = pointB + (u * s);

        if (t >= 0 || t <= 1)
            return pos;
        else
            return new Vector3(0, 0, 0);

        //DrawPoint(pos, Color.white);
    }
}

class Line
{
    private Vector3 _a;
    private Vector3 _b;

    public Line(Vector3 a, Vector3 b)
    {
        _a = a;
        _b = b;
    }

    public void DrawLine(Color color);
    {
        float width = 0.5f;
        GameObject line = new GameObject("Line_" + _a.ToString() + "_" + _b.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, startPos.z));
        lineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, endPos.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
