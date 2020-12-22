using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    private void Start()
    {
        //2 row and 3 columns
        Matrix matrix1 = new Matrix(2, 3, new float[6] { 1, 2, 3, 4, 5, 6 });
        Matrix matrix2 = new Matrix(3, 2, new float[6] { 1, 2, 3, 4, 5, 6 });

        Matrix resultMatrix = matrix1 * matrix2;

        Debug.Log(resultMatrix.ToString());
    }
}
