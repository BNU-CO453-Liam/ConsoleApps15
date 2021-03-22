using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helper;

namespace ConsoleAppProject.App04
{
    class NetworkApp
    {
        private NewsFeed news = new NewsFeed();

        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("   Liam's News Feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "" +
                "Disaply All Posts", "Quit"
            };

            bool wantToQuit = false;

            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisaplayAll(); break;
                    case 4: wantToQuit = true; break;
                    default:
                        break;
                }

            } while (!wantToQuit);

        }

        private void DisaplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            throw new NotImplementedException();
        }

        private void PostMessage()
        {
            throw new NotImplementedException();
        }
    }
}
