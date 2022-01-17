using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult ListarPosts()
        {
            return Ok(_postService.ListarPost());
        }

        [HttpPost]
        public IActionResult GuardarPost([FromBody] Post post)
        {



            return Ok(_postService.GuardarPost(post));
        }


    }
}
