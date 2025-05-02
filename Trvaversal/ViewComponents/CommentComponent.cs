using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class CommentComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int destinationId)
        {
            var model = _commentService.GetList().Where(x => x.DestinationId == destinationId).ToList();
            return View(model);
        }
    }
}
