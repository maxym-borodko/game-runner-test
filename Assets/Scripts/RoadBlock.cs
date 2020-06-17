using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] int numberOfRows = 3, numberOfColumns = 3;
    [SerializeField] float rowsSize = 3f, columnSize = 3f;

    public int GetNumberOfRows()
    {
        return numberOfRows;
    }

    public int GetNumberOfColumns()
    {
        return numberOfColumns;
    }

    public float GetRowsSize()
    {
        return rowsSize;
    }

    public float GetColumnSize()
    {
        return columnSize;
    }

    public float BlockWidth()
    {
        return numberOfColumns * columnSize;
    }

    public float BlockLength()
    {
        return numberOfRows * rowsSize;
    }

    public void PutObject(GameObject newObject, int row, int column)
    {
        newObject.transform.parent = transform;
        newObject.transform.localPosition = new Vector3(
            (row - 1) * rowsSize,
            1,
            (column - 1) * columnSize);
    }
}
