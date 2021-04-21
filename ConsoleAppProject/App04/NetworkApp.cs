using System;
using System.Linq;
using System.Text.RegularExpressions;
using ConsoleAppProject.Helper;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class inherits from the news feed class.
    /// 
    /// The user is able to login with their username,
    /// post messages, post images, view posts, search for posts by
    /// author, search for posts by date, logout or quit the app.
    /// </summary>
    class NetworkApp : NewsFeed
    {
        private NewsFeed news = new NewsFeed();

        public int SearchPosts = 0;

        public const int MaxLength = 100;

        public const int MinLength = 1;

        public static string CurrentUser { get; set; }

        private char input;

        public const string AllowedChars = @"^[0-9a-zA-Z!@#$%&*()_\-+={[}\]|:;'<,>.?~` ]*$";

        private bool postNow = false;

        /// <summary>
        /// Display the main welcome menu.
        /// </summary>
        public void DisplayMenu()
        {
            Console.Clear();

            ConsoleHelper.OutputHeading("   Liam's News Feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image",
                "Display All Posts", "Display by Author", "Display by Date",
                "Logout", "Quit"
            };

            bool wantToQuit = false;

            Login();

            do
            {
                ConsoleHelper.Cyan();

                Console.WriteLine($"{BlueAlert}");

                BlueAlert = "";

                ConsoleHelper.Cyan();

                Console.WriteLine("\n       // Main Menu \\\\\n" +
                                "          ---------\n");

                ConsoleHelper.Green();

                Console.WriteLine($"    -- Logged in as: {CurrentUser} --\n");

                ConsoleHelper.White();

                int choice = ConsoleHelper.SelectChoice(choices);

                postNow = false;

                switch (choice)
                {
                    case 1: PostDynamicMessage(); break;

                    case 2: PostImage(); break;

                    case 3: DisaplayAll(); break;

                    case 4: DisplayByAuthor(); break;

                    case 5: DisplayByDate(); break;

                    case 6: DisplayMenu(); break;

                    case 7: wantToQuit = true; break;

                    default: break;
                }

            } while (!wantToQuit);
        }

        /// <summary>
        /// Promts the user for their username.
        /// (passwords have not been configured)
        /// </summary>
        private void Login()
        {
            Console.Write("\n Enter username > ");

            CurrentUser = Console.ReadLine();

            news.Author = CurrentUser;

            Console.Clear();
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

            PhotoPost photopost = new PhotoPost(CurrentUser, filename, caption);

            news.AddPhotoPost(photopost);

            ConsoleHelper.Cyan();

            BlueAlert = "\n -- Your image has been posted ! --\n";

            ConsoleHelper.White();

            Console.Clear();
        }

        /// <summary>
        /// Displays the message back to the user as they type
        /// and shows the amount of permitted characters used.
        /// </summary>
        private void PostDynamicMessage()
        {
            ConsoleHelper.Red();

            Console.Clear();

            Console.Write(RedAlert);

            ConsoleHelper.Cyan();

            Console.WriteLine($"\n {MaxLength}/{MaxLength} characters " +
                $"remaining\n");

            ConsoleHelper.White();

            Console.Write($" Type your message > ");

            var message = "";

            int remainingChars = MaxLength;

            do
            {               
                DetectUserInput();

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Backspace) &&
                    message.Length >= MinLength)
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

                if (Convert.ToChar(input) == Convert.ToChar(ConsoleKey.Enter) &&
                    message.Length >= MinLength)
                {
                    postNow = true; 
                }

                Console.Clear();

                ConsoleHelper.Cyan();

                Console.WriteLine($"\n {remainingChars}/{MaxLength} characters " +
                    $"remaining\n");

                ConsoleHelper.White();

                Console.Write($" Type your message > {message}");
                
            } while (postNow == false);

            if (message.Length <= MaxLength)
            {
                MessagePost post = new MessagePost(CurrentUser, message);

                news.AddMessagePost(post);

                Console.WriteLine();

                BlueAlert = "\n -- Your message has been posted ! --\n";

                Console.Clear();
            }

            else
            {
                ConsoleHelper.Red();

                RedAlert = $"\n -- Message must be {MaxLength} characters " +
                    $"or less --\n";

                postNow = false;

                ConsoleHelper.White();

                PostDynamicMessage();
            }      
        }

        /// <summary>
        /// Displays all posts by a selected author.
        /// </summary>
        private void DisplayByAuthor()
        {
            if (news.Posts.Count == 0)
            {
                BlueAlert = "\n    -- No posts to display --\n";

                Console.Clear();
            }

            else
            {
                Console.Write("\n Enter author name > ");

                Search = Console.ReadLine();

                SearchPosts = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Username.ToString() == Search)
                    {
                        SearchPosts++;
                    }
                }

                if (SearchPosts > 0)
                {
                    int i = 0;

                    foreach (Post post in news.Posts.ToList())
                    {
                        if (post.Username.ToString() == Search)
                        {
                            i++;

                            DisplayResults(i, post);
                        }
                    }
                }

                else
                {
                    BlueAlert = "\n    -- No posts found --\n";

                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Display search results for posts by author or date.
        /// </summary>
        private void DisplayResults(int i, Post post)
        {
            ConsoleHelper.Cyan();

            Console.WriteLine($"\n -- Showing {i}/{SearchPosts} posts by" +
                $" {Search} --");

            ConsoleHelper.White();

            post.Display();

            if (i == SearchPosts)
            {
                BlueAlert = "    -- End of posts --\n";
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

        /// <summary>
        /// Display posts by date.
        /// </summary>
        private void DisplayByDate()
        {
            if (news.Posts.Count == 0)
            {
                BlueAlert = "\n    -- No posts to display --\n";

                Console.Clear();
            }

            else
            {
                Console.Write("\n Enter year > ");

                Search = Console.ReadLine();

                SearchPosts = 0;

                foreach (Post post in news.Posts.ToList())
                {
                    if (post.Timestamp.Date.Year.ToString() == Search)
                    {
                        SearchPosts++;
                    }
                }

                if (SearchPosts > 0)
                {
                    int i = 0;

                    foreach (Post post in news.Posts.ToList())
                    {
                        if (post.Timestamp.Date.Year.ToString() == Search)
                        {
                            i++;

                            DisplayResults(i, post);
                        }
                    }
                }

                else
                {
                    BlueAlert = "\n    -- No posts found --\n";

                    Console.Clear();
                }
            }
        }
    }
}
