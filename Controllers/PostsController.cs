using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Rotalarim.Models;
using Microsoft.EntityFrameworkCore;
using Rotalarim.Entity;

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
        public IActionResult AddComment(int PostId , string UserName ,string Text ,string Url){
            var entity = new Comment{
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                User  = new User {UserName = UserName , Image = "avatar.jpg" }
            };
            _commentRepository.CreateComment(entity);

            //return Redirect("/posts/details/" + Url);
            return RedirectToRoute("post_details", new{url = Url});

        }

    }
}