using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace part2
{//start of namespace
    public class check_questions
    {//start of class

        //creating an instance for the chats_color class
        //with an object name called get_chats_color
        chats_colours get_chats_color = new chats_colours();


        //creating an instance for the searching answers class
        //with an object name searching
        searching_answers searching = new searching_answers();

        //creating two instances for the arraylist 
        private ArrayList ai_answers, ai_questions, ignore;

        //creating an instance for a store_answers class 
        //with an object name answers 
        searching_answers answers = new searching_answers();

        //check if stored before
        bool stored = false;

        //method to return  answers
        public string searching_response(string questions, string username)
        {//start of searching method

            //temp message variable
            string message = string.Empty;


            //check if not stored before
            if (!stored) {

                //auto store
                auto_store();
            }

            //using if else to check user messages
            if (questions.ToLower() != string.Empty && questions.ToLower() != " ")
            { //start of if 

                //local variable declaration
                bool found = false;
                int index_found = 0;

                //if first one fails then do fallback and recheck on the second one

                //turn the users input to array by split
                string[] find_words = questions.Split(' ');
                ArrayList found_answers = new ArrayList();

                //check if user message contains the word interested
              

                //using for loop for searching the answer
                for (int index = 0; index < find_words.Length; index++)
                {//start of for loop

                    //temp variable
                    string searched_by_word = find_words[index].ToString();
                    string answer=string.Empty;

                    //inner for loop to check answers by words while ignoring
                    for (int ignores = 0; ignores < ai_questions.Count; ignores++)
                    {
                        //temp variable
                        string searched = ai_questions[ignores].ToString();


                        //using if statement to check whether
                        //the question asked is related to cybersecurity
                        if ( !ignore.Contains(searched_by_word))
                        {//start of if

                           
                            index_found = ignores;

                            //get all answers 
                            ArrayList all_found = new ArrayList();
                            Random get_answer = new Random();


                     
                            //answer += ai_answers[ignores].ToString()+",";

                            //if/else statement for user interest message
                            if (searched_by_word.ToLower() =="interested")
                            {//start of if

                                //temp variable
                                int count_interest = 0;
                                string message_interest = string.Empty;
                                bool found_interest = false;

                                //
                                foreach (string interest_words in find_words) 
                                {
                                    
                                    if (!ignore.Contains(interest_words.ToLower()) && interest_words.ToLower()!="interested") 
                                    {//start of if

                                        //inner foreach
                                        foreach (string get_interest in ai_answers)
                                        {
                                            if (get_interest.Contains(interest_words.ToLower()))
                                            {
                                                found_interest = true;

                                            }//end of if
                                        }//end of foreach

                                        if (count_interest == 0)
                                                {//start of if

                                                    
                                                    count_interest++;
                                                    message_interest += interest_words;

                                                }//end of if

                                                else
                                                {
                                                    message_interest += " , " + interest_words;

                                                }//end of else
                                            
                                    }//end of if
                                
                                }
                                if (!found_interest)

                                {//start of if

                                    found_answers.Add("please enter interests related to cybersecurity");
                                }
                                else 
                                {
                                    //write into the text file
                                    File.AppendAllText("interests.txt", username + " " + message_interest + "\n");
                                    
                                    found_answers.Add("great i will remember that you are interested in " + message_interest);

                                }//end of else
                                
                                found = true;

                                break;

                            }//end of if

                           
                            foreach (string randomize in ai_answers)
                            {

                               // MessageBox.Show(searched_by_word);
                                if (randomize.ToLower().Contains(searched_by_word.ToLower())   )
                                {
                               //if question is found, assign to true then assign index
                                  found = true;

                                    all_found.Add(randomize.Substring(searched_by_word.Length) );
                                }

                            }

                            // ONLY proceed if we actually found matches
                            if (all_found.Count > 0)
                            {
                                int indexes = get_answer.Next(all_found.Count);

                                string selected = all_found[indexes].ToString();

                                //avoid duplicate answers
                                if (!found_answers.Contains(selected))
                                {
                                    found_answers.Add(selected);
                                }
                            }
                           


                        }//end of if

                    }

                }//end of for loop



                //display the found answer or error message
                //using if else statements 
                if (found)
                {//start of if



                    int count = found_answers.Count;
                    int counting = 0;

                    foreach (string get_answer in found_answers)
                    {
                        if (counting == count - 1)
                        {
                            // Last item
                            message += get_answer;
                        }
                        else
                        {
                            // Not last item
                            message += get_answer + "\n              and ";
                        }

                        counting++;
                    }

                }//end of if
                else
                {//start of else


                    //display error message for message not found
                    //error message with text color red
                    message = "i didn't quite understand that. could you please rephrase your question?";

                }//end of else

            }//end of if
            else
            {//start of else 

                //display error message with text color red
                message = "please enter questions related to cybersecurity.";

            }//end of else

            //return
            return message;

        }//end of searching method

        //method to auto store
        private void auto_store()
        {
            //store answers before user interaction
            ai_answers = answers.return_answers();

            //store questions before user interaction
            ai_questions = answers.user_questions();


            //store the ignore
            ignore = answers.ignores();

            //then assign to true
            stored = true;

        }

        //check questions
        public Boolean question_check(string question, ListView chats_view)
        {//start of questions
            //using if statement to check username
            if (question != "")
            {//start of if 

                return true;
            }
            else
            {
                get_chats_color.ai_error("CyberBot", chats_view, "Please enter a question related to cybersecurity, to get a response.....");
            }

            return false;

        }//end of questions

















    }
}