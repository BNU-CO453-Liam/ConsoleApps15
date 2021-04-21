using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleAppProject.Helper;

namespace ConsoleAppProject.App04
{
    class NetworkApp : NewsFeed
    {
        private NewsFeed news = new NewsFeed();

        public static int PostIndex = -1;

        private int authorPosts;

        public static int MaxLength = 150;

        public static int MinLength = 1;

        public static string Author { get; set; }

        private char input;

        public const string AllowedChars = @"^[0-9a-zA-Z!@#$%&*()_\-+={[}\]|:;'<,>.?~` ]*$";

        private bool postNow = false;


        public void DisplayMenu()
        {
            Console.Clear();

            ConsoleHelper.OutputHeading("   Liam's News Feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image",
                "Display All Posts", "Search posts", "Logout", "Quit"
            };

            bool wantToQuit = false;

            Console.Write("\n Enter username > ");

            Author = Console.ReadLine();

            news.Author = Author;

            Console.Clear();

            do
            {
                ConsoleHelper.Cyan();

                Console.WriteLine($"{blueAlert}");

                blueAlert = "";

                ConsoleHelper.Green();

                Console.WriteLine($"    -- Logged in as: {Author} --\n");

                ConsoleHelper.White();

                int choice = ConsoleHelper.SelectChoice(choices);

                postNow = false;

                base.VisiblePostIndex = 0;

                switch (choice)
                {
                    case 1: PostDynamicMessage(); break;

                    case 2: PostImage(); break;

                    case 3: DisaplayAll(); break;

                    case 4: DisplayPostsByAuthor(); break;

                    case 5: DisplayMenu(); break;

                    case 6: wantToQuit = true; break;

                    default: break;
                }

            } while (!wantToQuit);
        }

        /// <summary>
        /// Displays all posts in the news feed.
        /// </summary>
        private void DisaplayAll()
        {
            news.Display();
        }

        /// <summary>
        /// Posts an image.
        /// </summary>
        private void PostImage()
        {
            ConsoleHelper.White();

            Console.Write("\n    Enter image filename > ");

            string filename = Console.ReadLine();

            Console.Write("\n    Enter image caption > ");

            string caption = Console.ReadLine();

            PhotoPost photopost = new PhotoPost(Author, filename, caption);

            news.AddPhotoPost(photopost);

            ConsoleHelper.Cyan();

            blueAlert = "\n-- Your image has been posted ! --\n";

            ConsoleHelper.White();

            PostIndex++;

            Console.Clear();
        }

        /// <summary>
        /// Displays the message back to the user as they type
        /// and shows the amount of permitted characters used.
        /// </summary>
        private void PostDynamicMessage()
        {
            ConsoleHelper.White();

            Console.Clear();

            ConsoleHelper.Cyan();

            Console.WriteLine($"\n {MaxLength}/{MaxLength} characters remaining\n");

            ConsoleHelper.White();

            Console.Write($" Type your message > ");

            var message = "";

            int remainingChars = MaxLength;

            do
            {               
                DetectUserInput();

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Backspace) && message.Length >= MinLength)
                {
                    int lastChar = message.Length - 1;

                    message = message.Remove(lastChar);

                    remainingChars++;
                }

                else
                {

                    if (Regex.IsMatch(input.ToString(), AllowedChars))
                    {
                        message += input.ToString();
                        remainingChars--;
                    }

                }

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Enter) && message.Length >= MinLength)
                {
                    postNow = true; 
                }

                Console.Clear();

                ConsoleHelper.Cyan();

                Console.WriteLine($"\n {remainingChars}/{MaxLength} characters remaining\n");

                ConsoleHelper.White();

                Console.Write($" Type your message > {message}");
                
            } while (postNow == false);

            if (message.Length <= MaxLength)
            {
                MessagePost post = new MessagePost(Author, message);

                news.AddMessagePost(post);

                Console.WriteLine();

                blueAlert = "\n -- Your message has been posted ! --\n";

                Console.Clear();

                PostIndex++;
            }

            else
            {
                ConsoleHelper.Red();

                Console.WriteLine($"\n -- Message must be {MaxLength} characters or less --\n");

                ConsoleHelper.White();

                PostDynamicMessage();
            }      
        }

        /// <summary>
        /// Displays all posts by a selected author.
        /// </summary>
        private void DisplayPostsByAuthor()
        {
            if (news.Posts.Count == 0)
            {
                blueAlert = "\n    -- No posts to display --\n";

                Console.Clear();
            }

            else
            {
                Console.Write("\n Enter author name > ");

                AuthorSearch = Console.ReadLine();

                authorPosts = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Username.ToString() == AuthorSearch)
                    {
                        authorPosts++;
                    }
                }

                if (authorPosts > 0)
                {
                    int i = 0;

                    foreach (Post post in news.Posts.ToList())
                    {
                        if (post.Username.ToString() == AuthorSearch)
                        {
                            i++;

                            ConsoleHelper.Cyan();

                            Console.WriteLine($"\n -- Showing {i}/{authorPosts} posts by { AuthorSearch } --");

                            ConsoleHelper.White();

                            post.Display();

                            if (i == authorPosts)
                            {
                                blueAlert = "    -- End of posts --\n";
                            }   
                        }
                    }
                }

                else
                {
                    blueAlert = "\n    -- No posts found --\n";

                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Detects which key the user has pressed.
        /// </summary>
        public char DetectUserInput()
        {
            input = Console.ReadKey().KeyChar;

            return input;
        }
    }
}
