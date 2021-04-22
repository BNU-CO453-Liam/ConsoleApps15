using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App04;

namespace ConsoleAppTests
{
    [TestClass]
    public class TestSocialNetwork
    {
        NetworkApp app04 = new NetworkApp();

        private const string testString = "test";

        private string message = testString;
        private string comment = testString;
        private string author = testString;
        private string caption = testString;
        private string fileName = testString;
        //private string currentUser = testString;
        public string date = "2021";

        [TestMethod]
        public void AddMessagePost()
        {
            //NetworkApp app04 = new NetworkApp();

            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            Assert.IsTrue(app04.Posts.Contains(testMessagePost));
        }

        [TestMethod]
        public void AddPhotoPost()
        {
            //NetworkApp app04 = new NetworkApp();

            PhotoPost testPhotoPost = new PhotoPost(author, fileName, caption);

            testPhotoPost.Filename = fileName;
            testPhotoPost.Caption = caption;

            app04.AddPhotoPost(testPhotoPost);

            Assert.IsTrue(app04.Posts.Contains(testPhotoPost));
        }

        [TestMethod]
        public void LikePost()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            app04.Posts[0].Like();

            Assert.IsTrue(app04.Posts[0].likes > 0);
        }

        [TestMethod]
        public void UnlikePost()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            app04.Posts[0].Like();

            app04.Posts[0].Unlike();

            Assert.IsTrue(app04.Posts[0].likes == 0);
        }

        [TestMethod]
        public void AddComment()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            app04.Posts[0].AddComment(comment);

            Assert.IsTrue(app04.Posts[0].comments.Contains(comment));
        }

        [TestMethod]
        public void RemovePost()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            app04.Posts.RemoveAt(0);

            Assert.IsTrue(app04.Posts.Count == 0);
        }

        [TestMethod]
        public void SearchPostsByDate()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.news.AddMessagePost(testMessagePost);

            app04.DisplayByDate("2021");

            Assert.IsTrue(app04.SearchPosts > 0);
        }

        [TestMethod]
        public void SearchPostsByAuthor()
        {
            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.news.AddMessagePost(testMessagePost);

            app04.DisplayByAuthor(author);

            Assert.IsTrue(app04.SearchPosts > 0);
        }

    }
}
