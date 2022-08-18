using System;
namespace Models;
using System.Collections.Generic;
class ShapesInterview{

    public static void Main(String[] args)
    {
        // Used to keep track of all new objects created
        // so knowing it will have up to 4 values, I should store these in a List/Array
        List<Circle> circleList = new List<Circle>();
        List<Triangle> triangleList = new List<Triangle>();
        List<Quadrilateral> quadrilateralList = new List<Quadrilateral>();
        Console.WriteLine("Please enter name of file to read from current directory (./ will be appended to string)");

        // defaults string to empty if nothing is read.
        string fileName = Console.ReadLine() ?? string.Empty;
        if(fileName != null || fileName != string.Empty) 
        {
            // This try catch block checks if the filename is valid, not the contents
            try
            {
                System.IO.File.ReadAllLines("./" + fileName);
            }
            catch(Exception fnf){
                Console.WriteLine(fnf.Message + "\nDefaulting to shapes.csv");
                fileName = "./shapes.csv";
            }
        } // end of fileName check
        
        // if statement to check if the file exists, just to remove null value problem
        if(System.IO.File.Exists(fileName))
                {
                    string []fileText = System.IO.File.ReadAllLines(fileName);
                    foreach(string line in fileText)
                    {
                        if(line != "") {
                            int commas = 0;
                            // using negatives since I would assume all sides would be declared positive
                            int[] numbers = {-1, -1, -1, 0};
                            string oneNumber = "";

                            for(int i = 0; i < line.Length; i++)
                            {
                                if(line[i] == ',')
                                {
                                    numbers[commas] = Int32.Parse(oneNumber);
                                    commas++;
                                    oneNumber = "";
                                }
                                else if( i+1 == line.Length)
                                {
                                    oneNumber += line[i].ToString();
                                    numbers[commas] = Int32.Parse(oneNumber);
                                    oneNumber = "";
                                }
                                else
                                {
                                    oneNumber += line[i].ToString();
                                }
                            } // end of for loop

                            switch(commas)
                            {
                                case 0:
                                    // circle
                                    Circle c = new Circle(numbers[0]);
                                    circleList.Add(c);
                                    break;
                                case 1:
                                    // rectangle/square
                                    Quadrilateral q = new Quadrilateral(numbers[0], numbers[1]);
                                    quadrilateralList.Add(q);
                                    break;
                                case 2:
                                    // triangle
                                    Triangle t = new Triangle(numbers[0], numbers[1], numbers[2]);
                                    triangleList.Add(t);
                                    break;
                                default:
                                    throw new InvalidDataException("");
                            }// end of switch statement
                        }// end of if statement to see if line is not null
                    } // end of foreach loop
                } // end of exists clause 
        
        // then count the amount in that stored object, which will call
        // uses the FindAll method, which returns a sublist of the matching clause
        Console.WriteLine("Amount of Circles: " + circleList.FindAll(n=>n.getShapeName()=="Circle").Count().ToString());
        Console.WriteLine("Amount of Rectangles: " + quadrilateralList.FindAll(n=>n.getShapeName()=="Rectangle").Count().ToString());
        Console.WriteLine("Amount of Squares: " + quadrilateralList.FindAll(n=>n.getShapeName()=="Square").Count().ToString());
        Console.WriteLine("Amount of Equilateral Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Equilateral").Count().ToString());
        Console.WriteLine("Amount of Isosceles Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Isosceles").Count().ToString());
        Console.WriteLine("Amount of Scalene Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Scalene").Count().ToString());
        Console.WriteLine("\n");
        /*
        quadrilateralList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));
        circleList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));
        triangleList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));
        */
        List<ShapeHolder> sorry = new List<ShapeHolder>();

        foreach(Triangle r in triangleList)
        {
            ShapeHolder test = new ShapeHolder(r);
            sorry.Add(test);
        }
        foreach(Circle r in circleList)
        {
            ShapeHolder test = new ShapeHolder(r);
            sorry.Add(test);
        }
        foreach(Quadrilateral r in quadrilateralList)
        {
            ShapeHolder test = new ShapeHolder(r);
            sorry.Add(test);
        }
        Console.WriteLine("Example of an operator overload: " + (sorry.ElementAt(0) + sorry.ElementAt(1)).ToString());

        sorry.Sort((a,b) => a.surfaceArea.CompareTo(b.surfaceArea));
        //string writeToFile = "";
        string writeToFile = String.Format("{0, -15} {1, -15} {2, -15}\n", "Shape Name", "Surface Area", "Perimeter" );
        writeToFile += "****************************************************\n";
        foreach(ShapeHolder w in sorry)
        {
            //writeToFile += w.name.ToString() + "| Surface Area: " + w.surfaceArea.ToString() + "| Perimeter: " + w.perimeter.ToString() + "\n";
            writeToFile += String.Format("{0, -15} {1, -15} {2, -15}\n", w.name.ToString(), w.surfaceArea.ToString(), w.perimeter.ToString());
        }
        Console.WriteLine(writeToFile);
        System.IO.File.WriteAllTextAsync("fileWritten.csv", writeToFile);
        Console.WriteLine("Wrote result to fileWritten.csv");
        // write the number of shapes of each type
        // sort all shapes by surface area
    }
    
}
