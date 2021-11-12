using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCMS.Model;

namespace CustomCMS.Data
{
    public class PostService
    {
        private PostDbContext dbContext;

        public PostService(PostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// This method returns the list of post
        /// </summary>
        /// <returns></returns>
        public async Task<List<Post>> GetPostAsync()
        {
            return await dbContext.Post.ToListAsync();
        }

        /// <summary>
        /// This method add a new post to the DbContext and saves it
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<Post> AddPostAsync(Post post)
        {
            try
            {
                dbContext.Post.Add(post);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return post;
        }

        /// <summary>
        /// This method update and existing post and saves the changes
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<Post> UpdatePostAsync(Post post)
        {
            try
            {
                var productExist = dbContext.Post.FirstOrDefault(p => p.Id == post.Id);
                if (productExist != null)
                {
                    dbContext.Update(post);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return post;
        }

        /// <summary>
        /// This method removes and existing post from the DbContext and saves it
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task DeletePostAsync(Post post)
        {
            try
            {
                dbContext.Post.Remove(post);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}