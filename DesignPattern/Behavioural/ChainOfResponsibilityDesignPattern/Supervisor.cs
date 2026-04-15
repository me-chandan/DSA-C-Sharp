namespace ChainOfResponsibilityDesignPattern
{
    public class Supervisor : Approver
    {
        public override void ProcessLeaveRequest(int leaveDays)
        {
            if(leaveDays <= 3)
            {
                Console.WriteLine("Leave approved by Supervisor");
            }
            else if(nextApprover != null)
            {
                Console.WriteLine("Leave days more, Supervisor delegating to next approver");
                nextApprover.ProcessLeaveRequest(leaveDays);
            }
            else
            {
                Console.WriteLine("Leave request denied, too many days");
            }
        }
    }
}
