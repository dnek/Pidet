using System;

namespace pidet
{
    class Comment
    {
        int x, y;
        String body;

        Comment()
        {
            this.x = 0;
            this.y = 0;
            this.body = "";
        }

        Comment(int x, int y, String body)
        {
            this.x = x;
            this.y = y;
            this.body = body;
        }
        
        public static Comment Decode(string encodedComment)
        {
            return new Comment(0, 0, encodedComment);
        }
    }
}
