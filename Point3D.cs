namespace ModelDesigner
{
    public class Point3D
    {
        public int Index { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D()
        {

        }

        public Point3D(int index, double x, double y, double z)
        {
            Index = index;
            X = x; Y = y; Z = z;
        }
    }
}
