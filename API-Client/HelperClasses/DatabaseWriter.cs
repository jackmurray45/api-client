using System;
using System.Collections.Generic;
using System.Text;

namespace API_Client
{
    /// <summary>
    /// Static class that takes list of objects from the JsonParser and writes them to the database 
    /// </summary>
    public static class DatabaseWriter
    {
        /// <summary>
        /// Takes list of Users and Database Context and writes Users to the database
        /// </summary>
        /// <param name="UserList">List of Users returned from the JsonParser class</param>
        /// <param name="Context"></param>
        public static void WriteUsers(List<User> UserList, DatabaseContext Context)
        {
            var ContextUsers = Context.Set<User>();
            Console.WriteLine("Writing Users to database...");
            ContextUsers.AddRange(UserList);
            Context.SaveChanges();
            Console.WriteLine("Users successfully added to database.");
        }

        /// <summary>
        /// Takes list of Posts and Database Context and writes Users to the database
        /// </summary>
        /// <param name="PostList">List of Posts returned from the JsonParser class</param>
        /// <param name="Context"></param>
        public static void WritePosts(List<Post> PostList, DatabaseContext Context)
        {
            var ContextPosts = Context.Set<Post>();
            Console.WriteLine("Writing Posts to database...");
            ContextPosts.AddRange(PostList);
            Context.SaveChanges();
            Console.WriteLine("Posts successfully added to database.");
        }

        /// <summary>
        /// Takes list of Comments and Database Context and writes Users to the database
        /// </summary>
        /// <param name="CommentList">List of Comments returned from the JsonParser class</param>
        /// <param name="Context"></param>
        public static void WriteComments(List<Comment> CommentList, DatabaseContext Context)
        {
            var ContextComments = Context.Set<Comment>();
            Console.WriteLine("Writing Comments to database...");
            ContextComments.AddRange(CommentList);
            Context.SaveChanges();
            Console.WriteLine("Comments successfully added to database.");
        }

    }
}
