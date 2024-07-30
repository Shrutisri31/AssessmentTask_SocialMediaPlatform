using System.Collections.Generic;

namespace Social_Media.Models
{
    public class FeedDto
    {
        public int PostID { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public int LikeCount { get; set; }
    }
}
