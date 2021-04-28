using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult ReturnNotFoundError()
        {
            var product = _context.Products.Find(42);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult ReturnServerError()
        {
            var product = _context.Products.Find(42);

            if (product.Name == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult ReturnBadRequestError(int id)
        {
            return Ok();
        }
    }
}