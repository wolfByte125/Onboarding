using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ReviewService(IMapper mapper, DataContext dataContext)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async Task<Review> AddReview(AddReviewDTO reviewDTO)
        {
            var user = await _context.Users
                .Where(u => u.Id == reviewDTO.UserId)
                .FirstOrDefaultAsync();

            if (user == null) 
                throw new KeyNotFoundException("User Not Found.");

            var review = _mapper.Map<Review>(reviewDTO);

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review> DeleteReview(int id)
        {
            var review = await _context.Reviews
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (review == null) throw new KeyNotFoundException("Review Not Found");
            _context.Reviews.Remove(review);
            _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReview(int id)
        {
            var review = await _context.Reviews
                        .Where(bp => bp.Id == id)
                        .Include(bp => bp.User)
                        .FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Couldn't find Review");
            return review;
        }
        public async Task<List<Review>> GetReviews()
        {
            var reviews = await _context.Reviews
                .Include(bp => bp.User)
                .OrderByDescending(bp => bp.UpdatedAt)
                .ToListAsync();
            if (reviews == null) throw new KeyNotFoundException("Couldn't Find Records");
            return reviews;
        }

        public async Task<Review> UpdateReview(UpdateReviewDTO updateReviewDTO)
        {
            var review = await _context.Reviews.Where(bp => bp.Id == updateReviewDTO.Id).FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Review to be updated not found!");
            review = _mapper.Map(updateReviewDTO, review);
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;

        }
        public async Task<int> GetRatingAggregateForBlog(int blogId)
        {
            var aggregate = await _context.Reviews.Where(bp => bp.BlogPostId == blogId)
                                                     .Select(bp => bp.Rating)
                                                     .ToListAsync();
            var count = aggregate.Count();
            var agg = aggregate?.Sum() ?? 0;
            //var agg = 0;
            //foreach (var bp in aggregate)
            //{
            //    agg = (int)(agg + bp);
            //}
            return agg/count;
        }
    }
}
