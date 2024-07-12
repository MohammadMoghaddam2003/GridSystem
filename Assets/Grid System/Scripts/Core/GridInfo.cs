using System.Collections.Generic;
using UnityEngine;

namespace Grid_System
{
    [CreateAssetMenu(menuName = "Grid/Grid Info", fileName = "New Grid Info")]
    public class GridInfo : ScriptableObject
    {
        [SerializeField] private float horizontalScale;
        [SerializeField] private float verticalScale;
        [SerializeField] private Vector2 origin;
        [SerializeField] private GameObject prefab;
        [SerializeField] private List<Columns> gridTable = new List<Columns>();

        
        public float GetHorizontalScale => horizontalScale;
        public float GetVerticalScale => verticalScale;
        public Vector2 GetOrigin => origin;
        public GameObject GetPrefab => prefab;
        public List<Columns> GetGridTable => gridTable;
    }
    
    [System.Serializable]
    public class Columns
    {
        public int columns;
    }
}