using BlogDemo.Services.BlogPostServices;
using BlogDemo.Services.ReviewServices;
using BlogDemo.Services.UserServices;

namespace BlogDemo
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserServices, UserServices>();
        }
    }
}
