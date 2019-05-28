using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace API_Client
{
    /// <summary>
    /// Static class that takes JSON from the API and converts the results into a list of objects from the API
    /// </summary>
    public static class JsonParser
    {
        /// <summary>
        /// Takes JSON as a dynamic type and converts the results into a list of Users
        /// </summary>
        /// <param name="JSONResult">JSON (dynamic) object from the HttpClientHelper method</param>
        /// <returns></returns>
        public static List<User> ConvertUsers(dynamic JSONResult)
        {
            List<User> AllUsers = new List<User> { };

            Console.WriteLine("Parsing through Users...");
            foreach (var user in JSONResult)
            {
                User NewUser = new User
                {
                  ApiUserId = user.id,
                  Email = user.email,
                  Name = user.name
                };
                AllUsers.Add(NewUser);
            }
            Console.WriteLine("Users Successfully parsed.");
            return AllUsers;
        }

        /// <summary>
        /// Takes JSON as a dynamic type and DatabaseContext and converts the results into a list of Posts.
        /// The DatabaseContext object is used in order to get the foreign key for the UserId
        /// </summary>
        /// <param name="JSONResult">JSON (dynamic) object from the HttpClientHelper method</param>
        /// <param name="DbContext"></param>
        /// <returns></returns>
        public static List<Post> ConvertPosts(dynamic JSONResult, DatabaseContext DbContext)
        {
            List<Post> AllPosts = new List<Post> { };
            int ApiUserId;

            Console.WriteLine("Parsing through Posts...");
            foreach (var post in JSONResult)
            {
                ApiUserId = post.userId;
                Post NewPost = new Post
                {
                    ApiPostId = post.id,
                    UserId = DbContext.Users.First(u => u.ApiUserId == ApiUserId).UserId,
                    Title = post.title,
                    Body = post.body
                };
                AllPosts.Add(NewPost);
            }
            Console.WriteLine("Posts Successfully parsed.");
            return AllPosts;
        }
        /// <summary>
        /// Takes JSON as a dynamic type and DatabaseContext and converts the results into a list of Comments.
        /// The DatabaseContext object is used in order to get the foreign key for the PostId
        /// </summary>
        /// <param name="JSONResult">JSON (dynamic) object from the HttpClientHelper method</param>
        /// <param name="DbContext"></param>
        /// <returns></returns>
        public static List<Comment> ConvertComments(dynamic JSONResult, DatabaseContext DbContext)
        {
            List<Comment> AllComments = new List<Comment> { };
            int ApiPostId;

            Console.WriteLine("Parsing through Comments...");
            foreach (var comment in JSONResult)
            {
                ApiPostId = comment.postId;
                Comment NewComment = new Comment
                {
                    ApiCommentId = comment.id,
                    PostId = DbContext.Posts.First(p => p.ApiPostId == ApiPostId).PostId,
                    Name = comment.name,
                    Body = comment.body
                };
                AllComments.Add(NewComment);
            }
            Console.WriteLine("Comments Successfully parsed.");
            return AllComments;
        }
    }
}
