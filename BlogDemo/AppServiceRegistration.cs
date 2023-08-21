using BlogDemo.Models;
using BlogDemo.Services.BlogPostServices;
using BlogDemo.Services.HelperServices;
using BlogDemo.Services.ReviewServices;
using BlogDemo.Services.ReviewServices;
using BlogDemo.Services.TagService;
using BlogDemo.Services.UserServices;

namespace BlogDemo
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IHelperService, HelperService>();
        }
    }
}
