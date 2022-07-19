namespace Models;

public abstract class Shapes
{
    protected string shapeName = "Shapes";
    // using decimal to 2 points since Pi is already 3.14 only
    protected decimal perimeter;

    protected decimal surfaceArea;

    // Writing these down, though I'm sure I should call these methods in a constructor instead of here
    // since a constructor will actually define them all given their input

    virtual protected void setName()
    {
        shapeName = "Shapes";
    }

    virtual protected void calculatePerimeter()
    {
        perimeter = 0.00M;
    }

    virtual protected void calculateSurfaceArea()
    {
        surfaceArea = 0.00M;
    }

    public string getShapeName()
    {
        return shapeName;
    }

    public decimal getPerimeter()
    {
        return perimeter;
    }

    public decimal getSurfaceArea()
    {
        return surfaceArea;
    }

}