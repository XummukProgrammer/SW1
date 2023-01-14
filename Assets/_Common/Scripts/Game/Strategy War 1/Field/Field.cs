using System;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private EntryPoint _entryPoint;
    private Transform _container;
    private List<Cell> _cells = new List<Cell>();
    private int _cellWidth;
    private int _cellHeight;
    private Vector2 _startPosition;

    public void Init(EntryPoint entryPoint, Transform container, int cellWidth, int cellHeight, Vector2 startPosition)
    {
        _entryPoint = entryPoint;
        _container = container;
        _cellWidth = cellWidth;
        _cellHeight = cellHeight;
        _startPosition = startPosition;
    }

    public void Deinit()
    {
        foreach (var cell in _cells)
        {
            cell.Remove();
        }

        _cells.Clear();
    }

    public Cell CreateCell<T>(CellBehaviour prefab, int x, int y, int layer, bool isForce) where T : Cell
    {
        if (!isForce && HasCellByRect(x, y, layer))
        {
            return null;
        }

        var cell = Activator.CreateInstance<T>();
        cell.Init(_entryPoint, _container, prefab, x, y, layer, _cellWidth, _cellHeight, _startPosition);
        return cell;
    }

    public Cell CreateAndAddCell<T>(CellBehaviour prefab, int x, int y, int layer, bool isForce) where T : Cell
    {
        var cell = CreateCell<T>(prefab, x, y, layer, isForce);

        if (cell == null)
        {
            return null;
        }

        AddCell(cell);
        return cell;
    }

    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
    }

    public void RemoveCell(Cell cell)
    {
        cell.Remove();
        _cells.Remove(cell);
    }

    public bool HasCell(Cell cell)
    {
        return _cells.Find((Cell _cell) => _cell == cell) != null;
    }

    public bool HasCellByRect(int x, int y, int layer)
    {
        return GetCellByRect(x, y, layer) != null;
    }

    public Cell GetCellByRect(int x, int y, int layer)
    {
        foreach (var cell in _cells)
        {
            if (x >= cell.X && x < cell.Width && y >= cell.Y && y < cell.Height)
            {
                if (layer != -1 && cell.Layer != layer)
                {
                    return null;
                }
                return cell;
            }
        }

        return null;
    }
}
