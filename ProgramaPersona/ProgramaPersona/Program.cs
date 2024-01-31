using ProgramaPersona;

class Program
{
    static void Main()
    {
        Person person = new Person("Enmanuel", 32);
        person.PrintInformation();

        Employee employee = new Employee("Kendall", 22, 10000.0f);
        employee.PrintInformation();
        employee.PrintSalary();
    }
}