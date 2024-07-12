using UnityEngine;

namespace Grid_System
{
    public abstract class AbstractGridCell : MonoBehaviour
    {
        //Store the coordinate of cell to faster find it
        public abstract void StoreCoord(int x, int y);

        
        //Anywhere you need access to this cell, call this method and receive the coordinates
        public abstract void GetCoord(out int x, out int y);
    }
}