using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API_Client
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int ApiCommentId { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
