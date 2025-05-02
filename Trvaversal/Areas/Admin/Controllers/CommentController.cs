using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            var model = commentService.GetCommentWidthDestination();
            return View(model);
        }
    }
}
