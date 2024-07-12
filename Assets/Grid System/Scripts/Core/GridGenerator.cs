using System.Collections.Generic;
using UnityEngine;

namespace Grid_System
{
    public class GridGenerator : MonoBehaviour
    {
        
#if UNITY_EDITOR
        //Default Grid Info for test ("NOT RUN TIME - IN UNITY EDITOR ONLY")
        [SerializeField] private GridInfo defaultGridInfo;


        
        //Use in editor code for test ("NOT RUN TIME - IN UNITY EDITOR ONLY")
        private void Generate2D() => Generate(defaultGridInfo, false);
        
        private void Generate3D() => Generate(defaultGridInfo, true);
        
#endif

        
        
        //It should be called anywhere you want to generate a grid
        public List<List<AbstractGridCell>> Generate(GridInfo gridInfo, bool in3dSpace, Transform parent = null)
        {
            //Cash the data
            List<List<AbstractGridCell>> grid = new List<List<AbstractGridCell>>();
            List<Columns> gridTable = gridInfo.GetGridTable;
            AbstractGridCell prefab = gridInfo.GetPrefab.GetComponent<AbstractGridCell>();
            Vector2 origin = gridInfo.GetOrigin;
            float horizontalScale = gridInfo.GetHorizontalScale;
            float verticalScale = gridInfo.GetVerticalScale;
            float currentHorizontal = origin.x;
            float currentVertical = origin.y;
            
            
            //Calculate pos and generate cells
            currentVertical += ((gridTable.Count * verticalScale) * .5f); 

            for (int y = 0; y < gridTable.Count; y++)
            {
                grid.Add(new List<AbstractGridCell>());
                currentHorizontal -= (((gridTable[y].columns -1) * horizontalScale) * .5f);
                
                for (int x = 0; x < gridTable[y].columns; x++)
                {
                    grid[y].Add(!in3dSpace
                        ? Instantiate2D(prefab, currentHorizontal, currentVertical, parent)
                        : Instantiate3D(prefab, currentHorizontal, currentVertical, parent));

                    grid[y][x].StoreCoord(x, y);
                    currentHorizontal += horizontalScale;
                }

                currentVertical -= verticalScale;
                currentHorizontal = origin.x;
            }
            
            return grid;
        }



        private AbstractGridCell Instantiate2D(AbstractGridCell prefab, float currentHorizontal, float currentVertical, Transform parent)
        {
            return Instantiate(prefab, 
                new Vector3(currentHorizontal, currentVertical, 0), Quaternion.identity, parent ? parent : transform);
        }
        
        private AbstractGridCell Instantiate3D(AbstractGridCell prefab, float currentHorizontal, float currentVertical, Transform parent)
        {
            return Instantiate(prefab, 
                new Vector3(currentHorizontal, 0, currentVertical), Quaternion.identity, parent ? parent : transform);
        } 
            
    }
}
