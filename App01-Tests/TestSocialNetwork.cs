using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App04;

namespace ConsoleAppTests
{
    [TestClass]
    public class TestSocialNetwork
    {
        //NetworkApp app04 = new NetworkApp();

        private const string testString = "test";

        private string message = testString;
        private string comment = testString;
        private string author = testString;
        private string caption = testString;
        private string filename = testString;
        public string date = "2021";

        [TestMethod]
        public void AddMessagePost()
        {
            NetworkApp app04 = new NetworkApp();

            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            Assert.IsTrue(app04.Posts.Contains(testMessagePost));
        }

        [TestMethod]
        public void AddPhotoPost()
        {
            NetworkApp app04 = new NetworkApp();

            PhotoPost testPhotoPost = new PhotoPost(author, filename, caption);

            testPhotoPost.Filename = filename;
            testPhotoPost.Caption = caption;

            app04.AddPhotoPost(testPhotoPost);

            Assert.IsTrue(app04.Posts.Contains(testPhotoPost));
        }

        [TestMethod]
        public void DisplayAllPosts()
        {
            NetworkApp app04 = new NetworkApp();

            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            PhotoPost testPhotoPost = new PhotoPost(author, filename, caption);

            testPhotoPost.Filename = filename;
            testPhotoPost.Caption = caption;

            app04.AddPhotoPost(testPhotoPost);

            app04.ExitLoop = true;
            app04.LoopDisplay();

            Assert.IsTrue(app04.VisiblePostIndex + 1 > 0);
        }

        [TestMethod]
        public void DisplayPostsByDate()
        {
            NetworkApp app04 = new NetworkApp();

            MessagePost testMessagePost = new MessagePost(author, message);

            testMessagePost.Message = message;

            app04.AddMessagePost(testMessagePost);

            PhotoPost testPhotoPost = new PhotoPost(author, filename, caption);

            testPhotoPost.Filename = filename;
            testPhotoPost.Caption = caption;

            app04.AddPhotoPost(testPhotoPost);

            app04.DisplayByDate(date);

            Assert.IsTrue(app04.SearchPosts > 0);
        }
    }
}
