using System;
namespace Models;
class ShapesInterview{

    public static void Main(String[] args)
    {
        
        // Used to keep track of all new objects created
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
                    if(line != ""){
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
                        }
                        switch(commas)
                        {
                            case 0:
                                // circle
                                Circle c = new Circle(numbers[0]);
                                circleList.Add(c);
                                Console.WriteLine("Created Circle");
                                break;
                            case 1:
                                // rectangle/square
                                Quadrilateral q = new Quadrilateral(numbers[0], numbers[1]);
                                quadrilateralList.Add(q);
                                Console.WriteLine("Created Qua");
                                break;
                            case 2:
                                // triangle
                                Triangle t = new Triangle(numbers[0], numbers[1], numbers[2]);
                                triangleList.Add(t);
                                Console.WriteLine("Created Tri");
                                break;
                        }
                    }
                }
            }
        }
        
        
        // I will read the file line by line until it reaches end of file,
        // so knowing it will have up to 4 values, I should store these in a List/Array
        // then count the amount in that stored object, which will call

        // write the number of shapes of each type
        // sort all shapes by surface area
    }
    
}
