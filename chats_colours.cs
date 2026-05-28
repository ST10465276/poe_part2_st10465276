using System.Runtime.Remoting.Messaging;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace part2
{//start of namespace
    public class chats_colours
    {//start of class

        //creating ai_chats method
        public void ai_chats(string ai_name, ListView chats_view, string ai_answer) 
        {//start of ai_chats method

            //setting the ai and ai messages colours
            chats_view.Items.Add(
                new TextBlock
                {
                    Inlines = {
                    new Run{
                    Text = ai_name + " : ",
                    Foreground = Brushes.DarkCyan

                    },
                    new Run{ 
                    Text =ai_answer +  "",
                    Foreground = Brushes.DarkGreen

                    }
                    }
                }
                );

            //auto scroll if reach the end of the chat
            chats_view.ScrollIntoView(chats_view.Items[chats_view.Items.Count - 1]);

        }//end of ai_chats method

        //ceating user_chats method
        public void user_chats(string username, ListView chats_view, string question) 
        {//start of method

            //setting username color
            chats_view.Items.Add(
                new TextBlock
                {
                    Inlines ={
                        new Run{
                        Text = username + " : ",
                        Foreground = Brushes.Magenta
                        },
                        new Run{
                        Text = question,
                        Foreground = Brushes.DarkGoldenrod

                        }
                    }
                }
                );

            //auto scroll if reach the end of the chat
            chats_view.ScrollIntoView(chats_view.Items[chats_view.Items.Count - 1]);

        }//end of method

        //creating ai_chats method
        public void ai_error(string ai_name, ListView chats_view,string message)
        {//start of ai_chats method

            //setting the colors
            chats_view.Items.Add(
                new TextBlock
                {
                    Inlines = {
                    new Run{
                    Text = ai_name+ " : ",
                    Foreground = Brushes.DarkCyan

                    },
                    new Run{
                    Text = message ,
                    Foreground = Brushes.Red

                    }
                    }
                }
                );

            //auto scroll if reach the end of the chats
            chats_view.ScrollIntoView(chats_view.Items[chats_view.Items.Count - 1]);

        }//end of ai_chats method

    }//end of class
}//end of namespace
