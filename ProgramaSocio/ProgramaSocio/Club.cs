namespace ProgramaSocio
{
    public class Club
    {
        private Member member1;
        private Member member2;
        private Member member3;

        public Club(Member member1, Member member2, Member member3)
        {
            this.member1 = member1;
            this.member2 = member2;
            this.member3 = member3;
        }

        public void MemberMoreAntiquity()
        {
            Member memberMoreAntiquity = null;

            if (member1.Antiquity > member2.Antiquity && member1.Antiquity > member3.Antiquity)
            {
                memberMoreAntiquity = member1;
            }
            else if (member2.Antiquity > member1.Antiquity && member2.Antiquity > member3.Antiquity)
            {
                memberMoreAntiquity = member2;
            }
            else
            {
                memberMoreAntiquity = member3;
            }

            if(memberMoreAntiquity != null)
            {
                Console.WriteLine($"The member with the highest antiquity is: {memberMoreAntiquity.Name}");
            }
            else
            {
                Console.WriteLine("There aren't members in the club.");
            }
        }
    }
}
