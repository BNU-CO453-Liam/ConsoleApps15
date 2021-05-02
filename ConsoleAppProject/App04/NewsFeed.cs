using ConsoleAppProject.Helper;
using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    ///This app is a console based social media platform.
    ///
    ///This class allows the user to view the news feed.
    ///
    ///From here the user can like posts, unlike posts
    ///remove a post, remove all posts, add acomment to a post,
    ///view the next post or exit to the main menu.
    ///</summary>
    ///<author>
    ///Liam Smith
    ///version 0.3
    ///</author> 
    public class NewsFeed
    {
        public const string EmptyString = "";

        public List<Post> Posts { get; set; }

        public List<int> Likes;

        public string Author;

        public string Search { get; set; }

        public static string RedAlert;

        public static string BlueAlert { get; set; }

        public bool ExitLoop { get; set; }

        public bool NoPosts = false;

        public static int VisiblePost { get; set; }

        public int VisiblePostIndex { get; set; }

        ///<summary>
        /// Construct an empty news feed with an empty list of
        /// posts and likes.
        ///</summary>
        public NewsFeed()
        {
            Posts = new List<Post>();

            Likes = new List<int>();
        }

        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {          
                Posts.Add(message);           
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            Posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal.
        ///</summary>
        public void Display()
        {
            if (Posts.Count == 0)
            {
                BlueAlert = "\n    -- No posts to display --\n";

                Console.Clear();
            }

            else
            {
                LoopDisplay();
            }
        }

        /// <summary>
        /// Displays a menu of options after each post
        /// until the user exits the loop.
        /// </summary>
        public void LoopDisplay()
        {
            if (Posts.Count == 0)
            {
                VisiblePostIndex = 0;
            }

            else
            {
                for (VisiblePostIndex = 0; VisiblePostIndex <= Posts.Count; VisiblePostIndex++)
                {
                    ExitLoop = false;

                    //Console.Clear();

                    RepeatFinalPost();

                    if (VisiblePost < Posts.Count - 1)
                    {
                        ShowPost();
                    }

                    ShowRedAlert();

                    ShowBlueAlert();

                    ResetAlertValues();

                    Console.WriteLine();

                    string[] choices = new string[]
                    {
                    " [1] Like ", "  [3] Remove this post","  [5] Comment \n",
                    " [2] Unlike ","[4] Remove all posts ", " [6] Next post ",
                    "[7] Main Menu"
                    };

                    int choice = ConsoleHelper.SelectChoice2(choices);

                    switch (choice)
                    {
                        case 1:
                            LikePost(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 2:
                            UnlikePost(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 3:
                            RemovePost();

                            VisiblePostIndex--;

                            break;

                        case 4:
                            RemoveAllPosts();

                            break;

                        case 5:
                            AddComment(Posts[VisiblePostIndex]);

                            VisiblePostIndex--;

                            break;

                        case 6:
                            ShowNextPost();

                            break;

                        case 7:
                            Console.Clear();

                            ExitLoop = true;

                            break;

                        default:
                            break;
                    }

                    if (ExitLoop && NoPosts)
                    {
                        VisiblePost = 0;

                        BlueAlert = "\n    -- All posts removed --\n";

                        Console.WriteLine();

                        break;
                    }

                    else

                    {
                        if (ExitLoop)
                        {
                            VisiblePost = 0;

                            Console.WriteLine();

                            break;
                        }
                    }
                }
            }
        }

        // Resets alerts to empty string for next use.
        private static void ResetAlertValues()
        {
            RedAlert = EmptyString;

            BlueAlert = EmptyString;
        }

        /// <summary>
        /// Disaplays a blue alert message.
        /// </summary>
        private static void ShowBlueAlert()
        {
            ConsoleHelper.Cyan();

            Console.Write(BlueAlert);

            ConsoleHelper.White();
        }

        /// <summary>
        /// Displays a red alert message;
        /// </summary>
        private static void ShowRedAlert()
        {
            ConsoleHelper.Red();

            Console.Write(RedAlert);

            ConsoleHelper.White();
        }

        /// <summary>
        /// Displays the next post unless it is the last post.
        /// </summary>
        private void ShowNextPost()
        {
            if (VisiblePostIndex < Posts.Count - 1)
            {
                VisiblePost++;
            }
            else
            {
                VisiblePostIndex--;

                BlueAlert = "    -- No more posts to display ! --\n";
            }
        }

        /// <summary>
        /// Shows a post in the standard format.
        /// </summary>
        private void ShowPost()
        {
            ConsoleHelper.Cyan();

            Console.WriteLine($"\n    -- Showing {VisiblePost + 1}/" +
                $"{Posts.Count} posts --");

            ConsoleHelper.White();

            Posts[VisiblePostIndex].Display();
        }

        /// <summary>
        /// Repeats the display of the final post in the list.
        /// </summary>
        private void RepeatFinalPost()
        {
            if (VisiblePostIndex == Posts.Count - 1)
            {
                VisiblePost = Posts.Count - 1;

                VisiblePostIndex = VisiblePost - 1;

                ShowLastPost();

                VisiblePostIndex++;
            }
        }

        /// <summary>
        /// Shows last post with specific variable adjustments.
        /// </summary>
        private void ShowLastPost()
        {
            ConsoleHelper.Cyan();

            Console.WriteLine($"\n    -- Showing {VisiblePost + 1}/" +
                $"{Posts.Count} posts --");

            ConsoleHelper.White();

            Posts[VisiblePost].Display();
        }

        /// <summary>
        /// Promts the user to enter a comment and adds it to a post.
        /// </summary>
        public static void AddComment(Post post)
        {
            Console.Write("\n    Enter comment > ");

            string text = Console.ReadLine();

            post.AddComment(text);

            BlueAlert = "\n    -- Comment added --\n";
        }

        /// <summary>
        /// Like a post if the user is not the author of the post,
        /// or if they have already liked the post.
        /// </summary>
        private void LikePost(Post post)
        {
            if (Posts[VisiblePostIndex].Username == NetworkApp.CurrentUser)
            {
                RedAlert = "    -- You cannot like your own posts --\n";
            }

            else
            {
                if (!Likes.Contains(VisiblePostIndex))
                {
                    post.Like();

                    BlueAlert = "    -- You liked this post --\n";

                    Likes.Add(VisiblePostIndex);
                }

                else
                {
                    RedAlert = "    -- You have already liked this post --\n";
                }
            }
        }

        /// <summary>
        /// Unlike a post unless the user is the author of the post or 
        /// has not already liked the post.
        /// </summary>
        private void UnlikePost(Post post)
        {
            if (Posts[VisiblePostIndex].Username == NetworkApp.CurrentUser)
            {
                RedAlert = "    -- You cannot like your own posts --\n";
            }

            else
            {
                if (Likes.Contains(VisiblePostIndex))
                {
                    post.Unlike();

                    BlueAlert = "    -- You unliked this post --\n";

                    int like = Likes.FindIndex(x => x==VisiblePostIndex);

                    Likes.RemoveAt(like);
                }

                else
                {
                    RedAlert = "    -- You have not liked this post yet --\n";
                }
            }  
        }

        /// <summary>
        /// Removes all posts regardless of the post author
        /// to demonstrate admin priveleges.
        /// </summary>
        private void RemoveAllPosts()
        {
            Posts = new List<Post>();

            BlueAlert = "    -- All posts removed --\n";

            Console.Clear();

            ExitLoop = true;
        }

        /// <summary>
        /// Removes a post if the user is the author of the post.
        /// </summary>
        private void RemovePost()
        {
            if (Posts[VisiblePostIndex].Username == NetworkApp.CurrentUser)
            {
                Posts.RemoveAt(VisiblePostIndex);

                RedAlert = "    -- Post removed --\n";
            }

            else
            {
                if (Posts.Count == 1)
                {
                    RemoveAllPosts();
                }

                else
                {
                    RedAlert = "    -- Only the author can remove this post --\n";
                }
            }          
        }
    }
}
