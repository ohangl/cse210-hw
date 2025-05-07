using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 when u finish): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // part1
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // part2
       
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // part3
        
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}