﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }

    public Coords(float x, float y)
    {
        X = x;
        Y = y;
        Z = -1;
    }

    public Coords(float x, float y, float z) : this(x, y)
    {
        Z = z;
    }

    public override string ToString()
    {
        return "(" + X + "," + Y + "," + Z + ")";
    }

    //static public void DrawPoint(Coords position, float width, Color colour)
    //{
    //    //GameObject line = new GameObject("Point_" + position.ToString());
    //    //LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
    //    //lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
    //    //lineRenderer.material.color = colour;
    //    //lineRenderer.positionCount = 2;
    //    //lineRenderer.SetPosition(0, new Vector3(position.x - width / 3.0f, position.y - width / 3.0f, position.z));
    //    //lineRenderer.SetPosition(1, new Vector3(position.x + width / 3.0f, position.y + width / 3.0f, position.z));
    //    //lineRenderer.startWidth = width;
    //    //lineRenderer.endWidth = width;
    //}

    //static public void DrawLine(Coords startPos, Coords endPos, float width, Color colour)
    //{
    //    GameObject line = new GameObject("Line_" + startPos.ToString() + "_" + endPos.ToString());
    //    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
    //    lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
    //    lineRenderer.material.color = colour;
    //    lineRenderer.positionCount = 2;
    //    lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, startPos.z));
    //    lineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, endPos.z));
    //    lineRenderer.startWidth = width;
    //    lineRenderer.endWidth = width;
    //}
}
