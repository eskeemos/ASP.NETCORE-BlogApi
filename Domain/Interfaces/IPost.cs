using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPost
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Create(Post model);
        void Update(Post model);
        void Delete(Post model);
    }
}
