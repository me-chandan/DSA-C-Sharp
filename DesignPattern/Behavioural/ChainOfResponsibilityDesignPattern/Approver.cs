namespace ChainOfResponsibilityDesignPattern
{
    public abstract class Approver
    {
        protected Approver nextApprover;
        public void SetNextApprover(Approver nextApprover)
        {
            this.nextApprover = nextApprover;
        }

        public abstract void ProcessLeaveRequest(int leaveDays);
    }
}
