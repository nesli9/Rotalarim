using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Rotalarim.Models;
using Microsoft.EntityFrameworkCore;
using Rotalarim.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Rotalarim.Controllers{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private ITagRepository _tagRepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository, ITagRepository tagRepository ){
            _postRepository = postRepository; //inject yöntemiyle nesne oluşturulması sağlanır
            _commentRepository = commentRepository;
            _tagRepository = tagRepository;
        }
        public async Task<IActionResult> Index(string tag){

            var posts = _postRepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag)); //gönderilen tagle eşleşen bir kayıt varsa geri dönen kayda alınır
            }
            return View(new PostsViewModel {Posts = await posts.ToListAsync()});
            
        }
        public async Task<IActionResult> Details(string url){
            return View( await _postRepository
                                .Posts
                                .Include(x => x.Tags)
                                .Include(x => x.Comments) 
                                .ThenInclude(x => x.User)
                                .FirstOrDefaultAsync(p => p.Url == url));
        }
        [HttpPost]
        public IActionResult AddComment(int PostId ,string Text ){
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//claimstypes bir listedir ve liste elemanlarıunı bu şekilde çağırabiliyoruz
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);


            var entity = new Comment {
                PostId = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);

            return Json(new { //gelen json bilgisi burada yapılandırılır
                username,
                Text,
                entity.PublishedOn,
                avatar
            });

        }

    }
}