using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Services.ReviewServices;
using BlogDemo.Services.ReviewServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddReview(AddReviewDTO reviewDTO)
        {
            try
            {
                return Ok(await _reviewService.AddReview(reviewDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            try
            {
                return Ok(await _reviewService.DeleteReview(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReview(int id)
        {
            try
            {
                return Ok(await _reviewService.GetReview(id));
            }
            catch (Exception ex) {
                return this.ParseException(ex); }
        }
        
        [HttpGet]
        public async Task<ActionResult> GetReviews()
        {
            try
            {
                return Ok(await _reviewService.GetReviews());
            }
            catch(Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateReview(UpdateReviewDTO updateReviewDTO)
        {
            try
            {
                return Ok(await _reviewService.UpdateReview(updateReviewDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }



    }
}
