namespace ChainOfResponsibilityDesignPattern
{
    internal class Manager : Approver
    {
        public override void ProcessLeaveRequest(int leaveDays)
        {
            if (leaveDays <= 10)
            {
                Console.WriteLine("Leave approved by Manager");
            }
            else if (nextApprover != null)
            {
                Console.WriteLine("Leave days more, Manager delegating to next approver");
                nextApprover.ProcessLeaveRequest(leaveDays);
            }
            else
            {
                Console.WriteLine("Leave request denied, too many days");
            }
        }
    }
}
