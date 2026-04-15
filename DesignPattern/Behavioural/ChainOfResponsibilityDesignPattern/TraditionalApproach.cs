namespace ChainOfResponsibilityDesignPattern
{
    internal class TraditionalApproach
    {
        public void ApproveLeaves(int leaveDays)
        {
            if(leaveDays <= 3)
            {
                Console.WriteLine("Approved by supervisor");
            }
            else if(leaveDays <= 10)
            {
                Console.WriteLine("Approved by Manager");
            }
            else if (leaveDays <= 14)
            {
                Console.WriteLine("Approved by Director");
            }
            else
            {
                Console.WriteLine("Leave request denied, too many days");
            }
        }
    }
}
