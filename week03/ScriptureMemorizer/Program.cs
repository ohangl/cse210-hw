using System;

class Program
{
    static void Main(string[] args)
    {
        // creativity:
        // the program asks the user how many words (1 or 3) they would like to hide each time.
        
        Reference reference = new Reference("2 Nephi", 2, 25);
        string text = "Adam fell that men might be and men are that they might have joy";
        Scripture scripture = new Scripture(reference, text);


        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("How many words would you like to hide each time? (Enter 1 or 3):");

        int wordsToHide = 1;
        string inputChoice = Console.ReadLine();

        if (inputChoice == "3")
        {
            wordsToHide = 3;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(wordsToHide);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program finished.");
                break;
            }
        }
    }
}
