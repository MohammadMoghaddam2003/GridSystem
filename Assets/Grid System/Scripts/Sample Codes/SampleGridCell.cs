
namespace Grid_System
{
    public class SampleGridCell : AbstractGridCell
    {
        private int _xCoord;
        private int _yCoord;


        public override void StoreCoord(int x, int y)
        {
            _xCoord = x;
            _yCoord = y;
        }

        public override void GetCoord(out int x, out int y)
        {
            x = _xCoord;
            y = _yCoord;
        }


        private void OnMouseUp()
        {
            print($"Index [X : {_xCoord} , Y : {_yCoord}]");
        }
    }
}