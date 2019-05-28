using System;
using System.Collections.Generic;
using System.Net.Http;

namespace API_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize DatabaseContext class to communicate with database
            var DbContext = new DatabaseContext();
            using (DbContext)
            {
                //Drop database if it exist to prevent duplicate data
                DbContext.Database.EnsureDeleted();
                //Recreate database based off Models
                DbContext.Database.EnsureCreated();
                //Initialize the HttpClient object inside the HttpClientHelper class
                HttpClientHelper.Initialize();

                //Get JSON
                dynamic JsonUsers = HttpClientHelper.CallApi("Users").GetAwaiter().GetResult();
                dynamic JsonPosts = HttpClientHelper.CallApi("Posts").GetAwaiter().GetResult();
                dynamic JsonComments = HttpClientHelper.CallApi("Comments").GetAwaiter().GetResult();

                //Get list of Users from JSON
                List<User> Users = JsonParser.ConvertUsers(JsonUsers);
                //Write List of Users to database
                DatabaseWriter.WriteUsers(Users, DbContext);

                //Get list of Posts from JSON
                List<Post> Posts = JsonParser.ConvertPosts(JsonPosts, DbContext);
                //Write list of Posts to database
                DatabaseWriter.WritePosts(Posts, DbContext);

                //Get list of Comments from JSON
                List<Comment> Comments = JsonParser.ConvertComments(JsonComments, DbContext);
                //Write list of Comments to database
                DatabaseWriter.WriteComments(Comments, DbContext);
            }
        }
    }
}
