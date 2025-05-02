using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService) 
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentDTO model)
        {
           if(ModelState.IsValid)
            {
                Comment comment = new Comment();
                comment.Name = model.Name;
                comment.Email = model.Email;
                comment.Message = model.Message;
                comment.DestinationId = model.DestinationId;
                comment.Date = DateTime.Now;
                comment.Status = false;
                _commentService.Add(comment);
                return Ok();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest( errors);
        }
    }
}
