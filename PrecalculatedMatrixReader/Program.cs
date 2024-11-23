using System;
using System.Linq;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        List<string> elements = new(9);
        while(true)
        {
            elements.Clear();
            Console.WriteLine("Enter the 3x3 matrix as a string of 9 floats:");
            while(elements.Count < 9)
            {
                string input = Console.ReadLine();
                elements.AddRange(input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            }
        
            // Check if we have exactly 9 elements
            if (elements.Count != 9)
            {
                Console.WriteLine("Error: Please provide exactly 9 floats for a 3x3 matrix.");
                return;
            }

            // Format the elements into a 4x4 matrix with added 0s and 1
            string output = string.Format(
                "{0}f, {1}f, {2}f, 0,\n{3}f, {4}f, {5}f, 0,\n{6}f, {7}f, {8}f, 0,\n0, 0, 0, 1",
                elements[0], elements[1], elements[2],
                elements[3], elements[4], elements[5],
                elements[6], elements[7], elements[8]
            );

            Console.WriteLine("4x4 Matrix:");
            Console.WriteLine(output);
        }
    }
}