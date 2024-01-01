namespace TaskFromResultConsoleApp
{
    internal class Program
    {
        public  static string CacheData { get; set; }
        private async static Task Main(string[] args)
        {
            CacheData = await GetDataAsync();
            await Console.Out.WriteLineAsync(CacheData);
        }
        public static Task<String>  GetDataAsync()
        {
            

            if(String.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("dosya.txt");
            }
            else
            {
                return Task.FromResult<string>(CacheData);
            }
            

        }
    }
}
