namespace BlogDemo.Services.HelperServices
{
    public interface IHelperService
    {
        Task<List<string>> CSVExtract(string csv);
    }
}
