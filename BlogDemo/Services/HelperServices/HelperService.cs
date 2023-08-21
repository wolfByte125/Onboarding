namespace BlogDemo.Services.HelperServices
{
    public class HelperService : IHelperService
    {
        public HelperService()
        { 
                    
        }
        public async Task<List<string>> CSVExtract(string csv)
        {
            var delimiter = ',';

            string[] items = csv.Split(delimiter);
            
            List<string> result = new List<string>();
            
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
