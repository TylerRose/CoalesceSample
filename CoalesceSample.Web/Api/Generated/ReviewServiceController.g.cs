
using CoalesceSample.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoalesceSample.Web.Api
{
    [Route("api/ReviewService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ReviewServiceController : Controller
    {
        protected CoalesceSample.Data.Services.IReviewService Service { get; }

        public ReviewServiceController(CoalesceSample.Data.Services.IReviewService service)
        {
            Service = service;
        }

        /// <summary>
        /// Method: GetReviews
        /// </summary>
        [HttpPost("GetReviews")]
        [AllowAnonymous]
        public virtual async Task<ItemResult<System.Collections.Generic.ICollection<ReviewDtoGen>>> GetReviews(System.Guid gameId, System.DateTime? firstDate, System.DateTime? secondDate, int page = 1, int reviewsPerPage = 10, double minRating = 0, double maxRating = 5)
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = await Service.GetReviews(gameId, firstDate, secondDate, page, reviewsPerPage, minRating, maxRating);
            var _result = new ItemResult<System.Collections.Generic.ICollection<ReviewDtoGen>>(_methodResult);
            _result.Object = _methodResult.Object?.ToList().Select(o => Mapper.MapToDto<CoalesceSample.Data.Models.Review, ReviewDtoGen>(o, _mappingContext, includeTree)).ToList();
            return _result;
        }

        /// <summary>
        /// Method: AddReview
        /// </summary>
        [HttpPost("AddReview")]
        [Authorize(Roles = "User")]
        public virtual async Task<ItemResult<ReviewDtoGen>> AddReview(System.Guid gameId, string reviewTitle, string reviewBody, double rating)
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = await Service.AddReview(User, gameId, reviewTitle, reviewBody, rating);
            var _result = new ItemResult<ReviewDtoGen>(_methodResult);
            _result.Object = Mapper.MapToDto<CoalesceSample.Data.Models.Review, ReviewDtoGen>(_methodResult.Object, _mappingContext, includeTree);
            return _result;
        }

        /// <summary>
        /// Method: DeleteReview
        /// </summary>
        [HttpPost("DeleteReview")]
        [Authorize(Roles = "User")]
        public virtual async Task<ItemResult> DeleteReview(System.Guid reviewId)
        {
            var _methodResult = await Service.DeleteReview(User, reviewId);
            var _result = new ItemResult(_methodResult);
            return _result;
        }
    }
}
