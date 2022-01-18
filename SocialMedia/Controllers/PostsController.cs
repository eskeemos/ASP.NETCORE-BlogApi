using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService) 
        {
            this.postService = postService;
        }

        [HttpGet][SwaggerOperation(Summary = "Retrieves all posts")]
        public ActionResult Get()
        {
            return Ok(postService.GetAllPosts());
        }

        [HttpGet("${id}")][SwaggerOperation(Summary = "Retrieves a specific post by unique id")]
        public IActionResult GetById([FromRoute] int id)
        {
            var post = postService.GetPostById(id); 
            if (post is null) return NotFound();
            return Ok(post);
        }

        [HttpPost][SwaggerOperation(Summary = "Create a new post")] 
        public IActionResult Create(CreatePostDto model)
        {
            var post = postService.CreatePost(model);
            return Created($"api/posts/{post.Id}", post);

        }
    }
}
