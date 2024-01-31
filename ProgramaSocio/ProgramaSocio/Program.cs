using ProgramaSocio;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the member 1:");
        Member member1 = Member.NewMember();

        Console.WriteLine("Enter the member 2:");
        Member member2 = Member.NewMember();

        Console.WriteLine("Enter the member 3:");
        Member member3 = Member.NewMember();

        Club club = new Club(member1, member2, member3);
        club.MemberMoreAntiquity();
    }
}