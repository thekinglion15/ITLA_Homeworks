namespace ProgramaSocio
{
    public class Member
    {
        private string name;
        private int antiquity;

        public Member(string name, int antiquity)
        {
            this.name = name;
            this.antiquity = antiquity;
        }

        public string Name { get { return name; } }
        public int Antiquity { get { return antiquity; } }

        public static Member NewMember()
        {
            int antiquity;

            Console.Write("Enter the member's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the member's antiquity in years: ");
            while (!int.TryParse(Console.ReadLine(), out antiquity) || antiquity < 0)
            {
                Console.WriteLine("Enter a valid antiquity in years.");
            }

            return new Member(name, antiquity);
        }
    }
}
