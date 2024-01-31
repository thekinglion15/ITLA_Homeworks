using ProgramaBanco;

class Program
{
    static void Main()
    {
        int option = 0;
        string name;
        float balance;
        Client selected = null;

        Client client1 = new Client("Enmanuel", 0.0f);
        Client client2 = new Client("Kendall", 0.0f);
        Client client3 = new Client("Gabriel", 0.0f);

        while(option != 3)
        {
            Console.Clear();
            Console.Write("Choose an option:\n1. Make deposit.\n2. Make withdrawal.\n3. Exit\n\nOption: ");
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Write your name: ");
                    name = Console.ReadLine();

                    selected = Client.GetName(name, client1, client2, client3);

                    if (selected != null)
                    {
                        Console.Write("Write amount to deposit: ");
                        balance = float.Parse(Console.ReadLine());
                        selected.Deposit(balance);
                    }
                    else
                    {
                        Console.WriteLine("Client not found");
                        Console.ReadKey();
                    }
                    
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Write your name: ");
                    name = Console.ReadLine();

                    selected = Client.GetName(name, client1, client2, client3);

                    if (selected != null)
                    {
                        Console.Write("Write amount to withdrawal: ");
                        balance = float.Parse(Console.ReadLine());
                        selected.Withdrawal(selected, balance);
                    }
                    else
                    {
                        Console.WriteLine("Client not found");
                        Console.ReadKey();
                    }
                    
                    break;

                case 3:
                    Console.Clear();
                    Client.Consult(client1, client2, client3);
                    Console.WriteLine("\n\nThanks you for using");
                    Console.ReadKey();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("It isn't an option.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}