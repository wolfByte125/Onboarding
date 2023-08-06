using BlogDemo.DTOs.NewReviewDTOs;
using BlogDemo.DTOs.ReviewDTOs;
using BlogDemo.Services.NewReviewServices;
using BlogDemo.Services.ReviewServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewReviewController : ControllerBase
    {
        private readonly INewReviewService _newReviewService;
        public NewReviewController(INewReviewService newReviewService)
        {
            _newReviewService = newReviewService;
        }
        [HttpPost]
        public async Task<ActionResult> AddReview(NewAddReviewDTO reviewDTO)
        {
            try
            {
                return Ok(await _newReviewService.AddReview(reviewDTO));
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
                return Ok(await _newReviewService.DeleteReview(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        [HttpGet("route2/{id}", Name = "Route2")]
        public async Task<ActionResult> GetRatingAggregateForBlog(int id)
        {
            try
            {
                return Ok(await _newReviewService.GetRatingAggregateForBlog(id));
            }
            catch (Exception ex) {
                return this.ParseException(ex);
            }
        }
        [HttpGet("route1/{id}", Name = "Route1")]
        public async Task<ActionResult> GetReview(int id)
        {
            try
            {
                return Ok(await _newReviewService.GetReview(id));
            }
            catch (Exception ex) {
                return this.ParseException(ex); }
        }
        [HttpGet]
        public async Task<ActionResult> GetReviews()
        {
            try
            {
                return Ok(await _newReviewService.GetReviews());
            }
            catch(Exception ex)
            {
                return this.ParseException(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateReview(NewUpdateReviewDTO updateReviewDTO)
        {
            try
            {
                return Ok(await _newReviewService.UpdateReview(updateReviewDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }



    }
}
