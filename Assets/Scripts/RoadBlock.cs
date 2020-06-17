using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] const int numberOfRows = 3, numberOfColumns = 3;
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
            column * columnSize - columnSize,
            1,
            row * rowsSize + rowsSize / 2);
    }

    public List<(int row, int column)> GetAllIndices()
    {
        List<(int row, int column)> indices = new List<(int row, int column)>();

        for (int row = 0, currentIndex = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < numberOfColumns; column++, currentIndex++)
            {
                var index = (row: row, column: column);
                indices.Add(index);
            }
        }

        return indices;
    }
}
