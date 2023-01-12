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

    public Cell CreateCell<T>(CellBehaviour prefab, int x, int y) where T : Cell
    {
        var cell = Activator.CreateInstance<T>();
        cell.Init(_entryPoint, _container, prefab, x, y, _cellWidth, _cellHeight, _startPosition);
        return cell;
    }

    public Cell CreateAndAddCell<T>(CellBehaviour prefab, int x, int y) where T : Cell
    {
        var cell = CreateCell<T>(prefab, x, y);
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

    public Cell GetCellByPosition(int x, int y)
    {
        foreach (var cell in _cells)
        {
            if (cell.X == x && cell.Y == y)
            {
                return cell;
            }
        }

        return null;
    }
}
