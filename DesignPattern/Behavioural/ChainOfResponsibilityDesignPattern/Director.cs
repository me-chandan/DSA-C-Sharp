namespace ChainOfResponsibilityDesignPattern
{
    internal class Director : Approver
    {
        public override void ProcessLeaveRequest(int leaveDays)
        {
            if (leaveDays <= 14)
            {
                Console.WriteLine("Leave approved by Director");
            }
            else if (nextApprover != null)
            {
                Console.WriteLine("Leave days more, Director delegating to next approver");
                nextApprover.ProcessLeaveRequest(leaveDays);
            }
            else
            {
                Console.WriteLine("Leave request denied, too many days");
            }
        }
    }
}
