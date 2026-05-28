using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace part2
{//start of namespace
    public partial class MainWindow : Window
    {//start of class


        //creating an instance for a class user_check
        //object name username_check
        private user_check username_check = new user_check();

        //creating an instance for a class chats_colours
        //object name chats_color
        private chats_colours chats_color = new chats_colours();

        //creating an instance for check questions class
        //with an object name question_asked
        check_questions question_asked = new check_questions();

        //declaring a global variable
        int user_respond_count = 0;
    
        public MainWindow()
        {//start of constructor
            InitializeComponent();

            //auto greet the user with voice 
            Greet();


        }//end of constructor

        private void start_click(object sender, RoutedEventArgs e)
        {//start of start handler

            //setting the logo grid to hidden
            //setting the username grid to visible
            logo_grid.Visibility = Visibility.Hidden;
            username_grid.Visibility = Visibility.Visible;

        }//end of start handler

        private void submit_username(object sender, RoutedEventArgs e)
        {//start of submit_username handler

            //collecting the username
            string name = user_input.Text.ToString();

            //calling the username_checking 
           bool found = username_check.username_checking(name,error_username,username_grid,chat_grid);

            if (found) 
            {
                //calling the welcome method
                username_check.welcome_user(chats_view);
            }

        }//end of submit_username handler

        private void send_question(object sender, RoutedEventArgs e)
        {//start of send_question handler

            //collecting username, ai name and user_questions
            string collect_username = username_check.return_username();
            string ai_name = "CyberBot";
            string user_questions = enter_question.Text.ToString();

            //clear question 
            enter_question.Clear();

            //calling the user_respond_count variable
            user_respond_count++;

            //check if the user entered something
            if (question_asked.question_check(user_questions, chats_view))
            {//start of if

                //calling the username
                chats_color.user_chats(collect_username, chats_view, user_questions);
                
                //searching for the answers
                string ai_answer = question_asked.searching_response(user_questions,collect_username);

                if (ai_answer == "please enter questions related to cybersecurity." || ai_answer == "i didn't quite understand that. could you please rephrase your question?" || ai_answer == "please enter interests related to cybersecurity")
                {
                    chats_color.ai_error(ai_name,chats_view,ai_answer);
                }
                else
                {
                    //show the response to the user
                    chats_color.ai_chats(ai_name, chats_view, ai_answer);

                }
            }//end of if 

            //check if user_repond_count is equals to 3 
            if (user_respond_count == 3) 
            {//start of if

                //declare a temp variable for the file path
                string filename = "interests.txt";

                //if 
                if (!File.Exists(filename)) 
                {

                    File.AppendAllText(filename,":\n");
                
                }

                //read interested user topics from the text file
                string[] topics = File.ReadAllLines(filename);

                //foreach to get interests of the user
                foreach (string each_topic in topics) 
                {//start of foreach

                    //check if there are toics the user is interested in
                    if (each_topic.ToLower().StartsWith(collect_username.ToLower())) 
                    {//start of if

                        chats_color.ai_chats(ai_name,chats_view," As someone interested in " + each_topic);

                        break;

                    }//end of if
                
                }//end of foreach

                user_respond_count = 0;
            
            }//end of if

        }//end of send_question handler

        //sound method
        private void Greet()
        {//start of sound method

            //creating an instance for the sound greeting class with a constructor
            new Greet_users() { };

        }//end of sound method

    }//end of class
}//end of namespace
