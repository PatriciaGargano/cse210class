using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
 
        List<int> numbers = new List<int>();

        int number=-1;

        while (number !=0)
         
        { 
            Console.WriteLine("Enter a list of numbers, type 0 when finished ");

            string userResponse = Console.ReadLine();
            number = int.Parse(userResponse);
            
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum is: {sum}");

    }

}