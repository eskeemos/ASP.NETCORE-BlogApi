using Application.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetPostById(int id);
        PostDto CreatePost(CreatePostDto model);
        void UpdatePost(UpdatePostDto model);
        void DeletePost(int id);
    }
}
