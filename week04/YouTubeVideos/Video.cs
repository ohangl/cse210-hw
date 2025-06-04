using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int LengthInSeconds
        {
            get { return _lengthInSeconds; }
            set { _lengthInSeconds = value; }
        }

        public void AddComment(Comment c)
        {
            if (c != null)
            {
                _comments.Add(c);
            }
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _comments;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Length: {LengthInSeconds}s, Comments: {GetCommentCount()}";
        }
    }
}
