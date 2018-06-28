using System;

namespace Repository
{
    public class Post
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPost { get; set; }

        public override string ToString()
        {
            return $"{Content} {DateOfPost}";
        }
    }
}