using System;

namespace ProgramaBanco
{
    public class Client
    {
        public Client(string name, float balance)
        {
            Name = name;
            Balance = balance;
        }
        
        public string Name { get; set; }
        public float Balance { get; set; }

        public void Deposit(float amount)
        {
            Balance += amount;
            Console.WriteLine("Deposit made.");
            Console.ReadKey();
        }

        public void Withdrawal(Client client, float amount)
        {
            if(amount <= client.Balance)
            {
                client.Balance -= amount;
                Console.WriteLine("Withdrawal made.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Insufficient funds to make the withdrawal.");
                Console.ReadKey();
            }
        }

        public static Client GetName(string name, params Client[] clients)
        {
            foreach (var client in clients)
            {
                if(client.Name == name)
                {
                    return client;
                }
            }
            return null;
        }

        public static void Consult(params Client[] clients)
        {
            foreach(var client in clients)
            {
                Console.WriteLine($"Current balance of {client.Name}: {client.Balance:C2}");
            }
        }
    }
}