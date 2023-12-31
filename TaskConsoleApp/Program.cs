namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }
    }
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            #region
            //Console.WriteLine("Hello, World!");

            //var mytask = new HttpClient().GetStringAsync("https://www.google.com")
            //     .ContinueWith((data) =>
            //     {
            //         Console.WriteLine("google data uzunluk : " + data.Result.Length);
            //     });

            //Console.WriteLine("Arada yapılacak işler");

            //await mytask;
            #endregion
            Console.WriteLine("Main Thread:" + Thread.CurrentThread.ManagedThreadId);

            List<string> urlsList = new List<string>()
            {
                "https://www.google.com",
                    "https://www.microsoft.com",
                    "https://www.amazon.com",
                    "https://www.n11.com",
                    "https://www.haberturk.com",
            };

            List<Task<Content>> tasks = new List<Task<Content>>();

            urlsList.ToList().ForEach(url =>
            {
                tasks.Add(GetContentAsync(url));
            });

            var firstData = await Task.WhenAny(tasks);
            Console.WriteLine($"{firstData.Result.Site} - {firstData.Result.Length}");
        }
        public static async Task<Content> GetContentAsync(string url)
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            c.Site = url;
            c.Length = data.Length;
            Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
            return c;
        }

    }

}
