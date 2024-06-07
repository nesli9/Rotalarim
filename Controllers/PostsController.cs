using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Rotalarim.Models;
using Microsoft.EntityFrameworkCore;

namespace Rotalarim.Controllers{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository ){
            _postRepository = postRepository; //inject yöntemiyle nesne oluşturulması sağlanır
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
                                .FirstOrDefaultAsync(p => p.Url == url));
        }

    }
}