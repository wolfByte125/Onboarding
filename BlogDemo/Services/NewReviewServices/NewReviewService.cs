using AutoMapper;
using BlogDemo.Contexts;
using BlogDemo.DTOs.NewReviewDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Services.NewReviewServices
{
    public class NewReviewService : INewReviewService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public NewReviewService(IMapper mapper, DataContext dataContext)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async Task<NewReview> AddReview(NewAddReviewDTO reviewDTO)
        {
            var review = _mapper.Map<NewReview>(reviewDTO);

            _context.NewReviews.Add(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<NewReview> DeleteReview(int id)
        {
            var review = await _context.NewReviews
                .Where(bp => bp.Id == id)
                .FirstOrDefaultAsync();

            if (review == null) throw new KeyNotFoundException("Review Not Found");
            _context.NewReviews.Remove(review);
            _context.SaveChangesAsync();
            return review;
        }

        public async Task<NewReview> GetReview(int id)
        {
            var review = await _context.NewReviews
                        .Where(bp => bp.Id == id)
                        .FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Couldn't find Review");
            return review;
        }
        public async Task<List<NewReview>> GetReviews()
        {
            var reviews = await _context.NewReviews.
                               OrderByDescending(bp => bp.UpdatedAt)
                               .ToListAsync();
            if (reviews == null) throw new KeyNotFoundException("Couldn't Find Records");
            return reviews;
        }

        public async Task<NewReview> UpdateReview(NewUpdateReviewDTO updateReviewDTO)
        {
            var review = await _context.NewReviews.Where(bp => bp.Id == updateReviewDTO.Id).FirstOrDefaultAsync();
            if (review == null) throw new KeyNotFoundException("Review to be updated not found!");
            review = _mapper.Map(updateReviewDTO, review);
            _context.NewReviews.Update(review);
            await _context.SaveChangesAsync();
            return review;

        }
        public async Task<int> GetRatingAggregateForBlog(int blogId)
        {
            var aggregate = await _context.NewReviews.Where(bp => bp.BlogId == blogId)
                                                     .Select(bp => bp.Rating)
                                                     .ToListAsync();
            var count = aggregate.Count();
            var agg = 0;
            foreach (var bp in aggregate)
            {
                agg = (int)(agg + bp);
            }
            return agg/count;
        }
    }
}
