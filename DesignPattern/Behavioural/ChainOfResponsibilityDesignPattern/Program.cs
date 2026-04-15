namespace ChainOfResponsibilityDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Supervisor supervisor = new Supervisor();
            Director director = new Director();

            supervisor.SetNextApprover(manager);
            manager.SetNextApprover(director);

            int leaveDays = 20;
            supervisor.ProcessLeaveRequest(leaveDays);
        }
    }
}
