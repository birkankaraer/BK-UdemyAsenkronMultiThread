namespace TaskStartNewConsoleApp
{
    public class Status
    {
        public int threadId { get; set; }
        public DateTime date { get; set; }
    }
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            var myTask = Task.Factory.StartNew((Obj) =>
            {
                Console.WriteLine("myTask çalıştı");
                var status = Obj as Status;

                status.threadId = Thread.CurrentThread.ManagedThreadId;

            }, new Status() { date = DateTime.Now });

            await myTask;
            Status s = myTask.AsyncState as Status;

            Console.WriteLine(s.date);
            Console.WriteLine(s.threadId);
        }
    }
}
