namespace Models;


// lets assume that we know that our program will know what object to create
public class Circle : Shapes
{
    private double Pi = 3.14;
    public Circle(int radius)
    {
        setName();
        calculatePerimeter(radius);
        calculateSurfaceArea(radius);
    }

    protected override void setName()
    {
        shapeName = "Circle";
    }

    protected void calculatePerimeter(int radius)
    {
        perimeter = 2.0 * Pi * radius;
    }

    protected void calculateSurfaceArea(int radius)
    {
        surfaceArea = Pi * radius * radius;
    }
}

/*
    For triangle, it must compare the sides to see if they are equivalent to determine what goes where
*/
class Triangle : Shapes
{
    public Triangle(int side1, int side2, int side3)
    {
        if( side1 == side2 && side2 == side3)
        {
            shapeName = "Equilateral";
        }
        else if( side1 == side2 || side2 == side3 || side1 == side3)
        {
            shapeName = "Isosceles";
        }
        else
        {
            shapeName = "Scalene";
        }
        calculatePerimeter(side1, side2, side3);
        calculateSurfaceArea(side1, side2, side3);
    }
    protected void calculatePerimeter(int side1, int side2, int side3)
    {
        perimeter = side1 + side2 + side3;
    }

    protected void calculateSurfaceArea(int a, int b, int c)
    {
        double temp = (a + b + c) / 2.0;
        // It broke for equilateral triangles
        surfaceArea = Math.Sqrt( temp * (temp - a) * (temp - b) * (temp - c) );
    }
}

class Quadrilateral : Shapes
{
    public Quadrilateral(int width, int length)
    {
        if(width == length){ shapeName = "Square"; }
        else{ shapeName = "Rectangle"; }
        calculatePerimeter(width, length);
        calculateSurfaceArea(width, length);
    }
    
    protected void calculatePerimeter(int width, int length)
    {
        perimeter = (width * length) * 2.0;
    }

    protected void calculateSurfaceArea(int width, int length)
    {
        surfaceArea = (double)(width * length);
    }
}


class GenericGetter
{
    public double surfaceArea;
    public string name;
    public double perimeter;

    public GenericGetter(Quadrilateral x)
    {
        perimeter = x.getPerimeter();
        name = x.getShapeName();
        surfaceArea = x.getSurfaceArea();
    }
    public GenericGetter(Triangle x)
    {
        perimeter = x.getPerimeter();
        name = x.getShapeName();
        surfaceArea = x.getSurfaceArea();
    }
    public GenericGetter(Circle x)
    {
        perimeter = x.getPerimeter();
        name = x.getShapeName();
        surfaceArea = x.getSurfaceArea();
    }
}
/*
not needed
class Rectangle : Shapes
{}
*/