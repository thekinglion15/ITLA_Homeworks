class Program
{
    static void Main()
    {
        Random random = new Random();

        int dice1 = random.Next(1, 7);
        int dice2 = random.Next(1, 7);
        int dice3 = random.Next(1, 7);

        Console.WriteLine($"Dice 1: {dice1}");
        Console.WriteLine($"Dice 2: {dice2}");
        Console.WriteLine($"Dice 3: {dice3}");

        if(dice1 == dice2 && dice2 == dice3)
        {
            Console.WriteLine("¡YOU WIN!");
        }
        else
        {
            Console.WriteLine("You lose. Try again");
        }

        Console.ReadKey();
    }
} 