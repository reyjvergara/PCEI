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
        string fileName = Console.ReadLine().TrimEnd().ToString();
        if(fileName != null)
        {
            try
            {
                System.IO.File.ReadAllLines("./" + fileName);
            }
            catch(FileNotFoundException fnf){
                Console.WriteLine(fnf.Message + "\nDefaulting to shapes.csv");
                fileName = "./shapes.csv";
            }
            finally
            {
                string []fileText = System.IO.File.ReadAllLines(fileName);
                foreach(string line in fileText)
                {
                    if(line != "") {
                        int commas = 0;
                        // using negatives since I would assume all sides would be declared positive
                        int[] numbers = {-1, -1, -1, -1};
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
                        }// end of switch statement
                    } // end of if statement to see if line is not null
                } // end of foreach loop 
            } // end of finally block
        } // end of fileName check
        
        
        
        // then count the amount in that stored object, which will call
        // uses the FindAll method, which returns a sublist of the matching clause
        Console.WriteLine("Amount of Circles: " + circleList.FindAll(n=>n.getShapeName()=="Circle").Count().ToString());
        Console.WriteLine("Amount of Rectangles: " + quadrilateralList.FindAll(n=>n.getShapeName()=="Rectangle").Count().ToString());
        Console.WriteLine("Amount of Squares: " + quadrilateralList.FindAll(n=>n.getShapeName()=="Square").Count().ToString());
        Console.WriteLine("Amount of Equilateral Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Equilateral").Count().ToString());
        Console.WriteLine("Amount of Isosceles Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Isosceles").Count().ToString());
        Console.WriteLine("Amount of Scalene Triangles: " + triangleList.FindAll(n=>n.getShapeName()=="Scalene").Count().ToString());

        quadrilateralList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));
        circleList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));
        triangleList.Sort((a, b) => a.getSurfaceArea().CompareTo(b.getSurfaceArea()));

        List<GenericGetter> sorry = new List<GenericGetter>();

        foreach(Triangle r in triangleList)
        {
            GenericGetter test = new GenericGetter(r);
            sorry.Add(test);
        }
        foreach(Circle r in circleList)
        {
            GenericGetter test = new GenericGetter(r);
            sorry.Add(test);
        }
        foreach(Quadrilateral r in quadrilateralList)
        {
            GenericGetter test = new GenericGetter(r);
            sorry.Add(test);
        }

        sorry.Sort((a,b) => a.surfaceArea.CompareTo(b.surfaceArea));
        string writeToFile = "";
        foreach(GenericGetter w in sorry)
        {
            writeToFile += w.name.ToString() + "| Surface Area: " + w.surfaceArea.ToString() + "| Perimeter: " + w.perimeter.ToString() + "\n";
        }
        Console.WriteLine(writeToFile);
        /*
        int tr = 0, cr = 0, qr = 0;
        while(tr < triangleList.Count() || cr < circleList.Count() || qr < quadrilateralList.Count())
        {
            if(tr < triangleList.Count() && cr < circleList.Count() && qr < quadrilateralList.Count())
            {
                if(triangleList.ElementAt(tr).getSurfaceArea() < circleList.ElementAt(cr).getSurfaceArea() 
                && triangleList.ElementAt(tr).getSurfaceArea() < quadrilateralList.ElementAt(qr).getSurfaceArea())
                {
                    Console.WriteLine(triangleList.ElementAt(tr).getShapeName().ToString() +": " + triangleList.ElementAt(tr).getSurfaceArea().ToString() 
                    + " "+ triangleList.ElementAt(tr).getPerimeter());
                    tr++;
                }
                
            }
            cr++;
            qr++;
            tr++;
        }*/
        // write the number of shapes of each type
        // sort all shapes by surface area
    }
    
}
