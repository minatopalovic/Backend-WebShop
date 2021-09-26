using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Data;
using WebShopIT28g2017.Entities;

namespace WebShopIT28g2017.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        IRatingRepository _ratingRep;

        public RatingsController(IRatingRepository ratingRepository)
        {
            _ratingRep = ratingRepository;
        }

        [HttpGet]
        public IActionResult GetRatings()
        {
            var ratings = _ratingRep.GetRating();

            if (ratings == null || ratings.Count == 0)
            {
                return NoContent();
            }
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public IActionResult GetRatingById(int id)
        {
            var rating = _ratingRep.GetRatingById(id);

            if (rating != null)
            {
                return Ok(rating);

            }
            return NotFound($"Ocena sa id-jem: {id} ne postoji u bazi!");

        }

        [HttpPost]
        public IActionResult InsertRating(Rating rating)
        {
            _ratingRep.Insert(rating);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "://" + rating.RatingId, rating);

        }

        [HttpPut]
        public IActionResult UpdateRating(Rating rating)
        {

            if (_ratingRep.GetRatingById(rating.RatingId) == null)
            {
                return NotFound();
            }

            _ratingRep.Update(rating);
            return Ok(rating);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int id)
        {
            var rating = _ratingRep.GetRatingById(id);

            if (rating != null)
            {
                _ratingRep.Delete(rating);
                return Ok();
            }
            return NotFound($"Ocena sa id-jem: {id} ne postoji u bazi!");
        }
    }
}
