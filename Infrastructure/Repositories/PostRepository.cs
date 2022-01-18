using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> posts = new HashSet<Post>()
        {
            new Post(1, "Title1", "Content1"),
            new Post(2, "Title2", "Content2"),
            new Post(3, "Title3", "Content3")
        };

        public IEnumerable<Post> GetAll()
        {
            return posts;
        }

        public Post GetById(int id)
        {
            return posts.SingleOrDefault(x => x.Id == id);
        }
        public Post Create(Post model)
        {
            model.Id = posts.Count() + 1;
            model.LastModified = DateTime.UtcNow;
            posts.Add(model);
            return model;
        }

        public void Update(Post model)
        {
            model.LastModified = DateTime.UtcNow;
        }

        public void Delete(Post model)
        {
            posts.Remove(model);
        }
        
    }
}
