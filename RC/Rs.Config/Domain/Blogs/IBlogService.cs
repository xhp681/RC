﻿using Rs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial interface IBlogService
    {
        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        Task DeleteBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Gets a blog post
        /// </summary>
        /// <param name="blogPostId">Blog post identifier</param>
        /// <returns>Blog post</returns>
        Task<BlogPost> GetBlogPostByIdAsync(int blogPostId);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
        /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="title">Filter by blog post title</param>
        /// <returns>Blog posts</returns>
        Task<IPagedList<BlogPost>> GetAllBlogPostsAsync(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false, string title = null);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="tag">Tag</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog posts</returns>
        Task<IPagedList<BlogPost>> GetAllBlogPostsByTagAsync(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// Gets all blog post tags
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog post tags</returns>
        Task<IList<BlogPostTag>> GetAllBlogPostTagsAsync(int storeId, int languageId, bool showHidden = false);

        /// <summary>
        /// Inserts a blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        Task InsertBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Updates the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        Task UpdateBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Returns all posts published between the two dates.
        /// </summary>
        /// <param name="blogPosts">Source</param>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <returns>Filtered posts</returns>
        Task<IList<BlogPost>> GetPostsByDateAsync(IList<BlogPost> blogPosts, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Parse tags
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <returns>Tags</returns>
        Task<IList<string>> ParseTagsAsync(BlogPost blogPost);

        //TODO: migrate to an extension method
        /// <summary>
        /// Get a value indicating whether a blog post is available now (availability dates)
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="dateTime">Datetime to check; pass null to use current date</param>
        /// <returns>Result</returns>
        bool BlogPostIsAvailable(BlogPost blogPost, DateTime? dateTime = null);
        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="blogPostId">Blog post ID; 0 or null to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item creation to; null to load all records</param>
        /// <param name="commentText">Search comment text; null to load all records</param>
        /// <returns>Comments</returns>
        Task<IList<BlogComment>> GetAllCommentsAsync(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null);

        /// <summary>
        /// Gets a blog comment
        /// </summary>
        /// <param name="blogCommentId">Blog comment identifier</param>
        /// <returns>Blog comment</returns>
        Task<BlogComment> GetBlogCommentByIdAsync(int blogCommentId);

        /// <summary>
        /// Get blog comments by identifiers
        /// </summary>
        /// <param name="commentIds">Blog comment identifiers</param>
        /// <returns>Blog comments</returns>
        Task<IList<BlogComment>> GetBlogCommentsByIdsAsync(int[] commentIds);

        /// <summary>
        /// Get the count of blog comments
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of blog comments</returns>
        Task<int> GetBlogCommentsCountAsync(BlogPost blogPost, int storeId = 0, bool? isApproved = null);

        /// <summary>
        /// Deletes a blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        Task DeleteBlogCommentAsync(BlogComment blogComment);

        /// <summary>
        /// Deletes blog comments
        /// </summary>
        /// <param name="blogComments">Blog comments</param>
        Task DeleteBlogCommentsAsync(IList<BlogComment> blogComments);

        /// <summary>
        /// Inserts a blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        Task InsertBlogCommentAsync(BlogComment blogComment);

        /// <summary>
        /// Update a blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        Task UpdateBlogCommentAsync(BlogComment blogComment);
    }
}
