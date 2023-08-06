using BlogDemo.DTOs.NewReviewDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.NewReviewServices
{
    public interface INewReviewService
    {
        Task<NewReview> AddReview(NewAddReviewDTO reviewDTO);
        Task<NewReview> DeleteReview(int id);
        Task<int> GetRatingAggregateForBlog(int blogId);
        Task<NewReview> GetReview(int id);
        Task<List<NewReview>> GetReviews();
        Task<NewReview> UpdateReview(NewUpdateReviewDTO updateReviewDTO);
    }
}