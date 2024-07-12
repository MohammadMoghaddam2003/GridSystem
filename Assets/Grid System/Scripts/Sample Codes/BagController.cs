using System.Collections.Generic;
using Grid_System;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private GridInfo gridInfo;

    private List<List<AbstractGridCell>> _grid = new List<List<AbstractGridCell>>();

    
    void Start()
    {
        _grid = gridGenerator.Generate(gridInfo, false, transform);
        
        print($"Grid Rows : {_grid.Count}");
    }
}
