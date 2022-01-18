using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = postRepository.GetAll();
            return mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetPostById(int id)
        {
            var post = postRepository.GetById(id);
            return mapper.Map<PostDto>(post);
        }

        public PostDto CreatePost(CreatePostDto model)
        {
            if (string.IsNullOrEmpty(model.Title)){
                throw new Exception("Post must have a value");
            }

            var post = mapper.Map<Post>(model);
            postRepository.Create(post);    
            return mapper.Map<PostDto>(post);
        }
    }
}
