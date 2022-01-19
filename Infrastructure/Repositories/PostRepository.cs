using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext socialMedia;

        public PostRepository(SocialMediaContext socialMedia)
        {
            this.socialMedia = socialMedia;
        }

        public IEnumerable<Post> GetAll()
        {
            return socialMedia.Posts;
        }   

        public Post GetById(int id)
        {
            return socialMedia.Posts.SingleOrDefault(x => x.Id == id);
        }
        public Post Create(Post model)
        {
            socialMedia.Posts.Add(model);
            socialMedia.SaveChanges();
            return model;
        }

        public void Update(Post model)
        {
            socialMedia.Posts.Update(model);
            socialMedia.SaveChanges();
        }

        public void Delete(Post model)
        {
            socialMedia.Posts.Remove(model);
            socialMedia.SaveChanges();
        }
        
    }
}
