namespace ProgramaPersona
{
    public class Employee : Person
    {
        public float Salary { get; set; }

        public Employee(string name, int age, float salary) : base(name, age)
        {
            this.Salary = salary;
        }

        public void PrintSalary()
        {
            Console.WriteLine($"Salary: {Salary}\n");
        }
    }
}
