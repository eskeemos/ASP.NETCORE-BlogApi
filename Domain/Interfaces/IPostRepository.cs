using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Create(Post model);
        void Update(Post model);
        void Delete(Post model);
    }
}
