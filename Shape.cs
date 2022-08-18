namespace Models;

public abstract class Shapes
{
    protected string shapeName = "Shapes";
    // using a double to reduce the amount of conversions needed
    protected double perimeter;

    protected double surfaceArea;

    // Writing these down, though I'm sure I should call these methods in a constructor instead of here
    // since a constructor will actually define them all given their input

    virtual protected void setName()
    {
        shapeName = "Shapes";
    }

    virtual protected void calculatePerimeter()
    {
        perimeter = 0;
    }

    virtual protected void calculateSurfaceArea()
    {
        surfaceArea = 0;
    }

    public string getShapeName()
    {
        return shapeName;
    }

    public double getPerimeter()
    {
        return perimeter;
    }

    public double getSurfaceArea()
    {
        return surfaceArea;
    }

}