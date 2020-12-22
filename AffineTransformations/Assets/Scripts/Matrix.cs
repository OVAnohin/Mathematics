using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Matrix 
{
    private float[] _values;
    private int _rows;
    private int _columns;

    public Matrix(int rows, int columns, float[] values)
    {
        _rows = rows;
        _columns = columns;

        _values = new float[_rows * _columns];
        Array.Copy(values, _values, _rows * _columns);
    }

    public override string ToString()
    {
        string result = "";

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _columns; c++)
            {
                result += _values[r * _columns + c] + " "; // это из побитовой математики достать число из 2-х мерного массива
            }
            result += "\n";
        }

        return result;
    }

    public Coords AsCoords()
    {
        if (_rows == 4 && _columns == 1)
            return new Coords(_values[0], _values[1], _values[2], _values[3]);

        return null;
    }

    static public Matrix operator +(Matrix a, Matrix b)
    {
        if (a._columns != b._columns || a._rows != b._rows)
            return null;

        float[] timeMatrix = new float[a._values.Length];

        for (int i = 0; i < timeMatrix.Length; i++)
            timeMatrix[i] = a._values[i] + b._values[i];

        return new Matrix(a._rows, a._columns, timeMatrix);
    }

    static public Matrix operator *(Matrix a, Matrix b)
    {
        if (a._columns != b._rows)
            return null;

        float[] timeMatrix = new float[a._rows * b._columns];

        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < b._columns; j++)
            {
                for (int k = 0; k < a._columns; k++)
                {
                    timeMatrix[i * b._columns + j] += a._values[i * a._columns + k] * b._values[k * b._columns + j];
                }
            }
        }

        return new Matrix(a._rows, b._columns, timeMatrix);
    }

}
