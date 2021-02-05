namespace ModelDesigner
{
    public class Line
    {
        public Point3D point1 { get; set; }
        public Point3D point2 { get; set; }

        public Line()
        {

        }

        public Line(Point3D point1, Point3D point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
    }
}
