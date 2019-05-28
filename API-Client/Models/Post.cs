using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API_Client
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int ApiPostId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
