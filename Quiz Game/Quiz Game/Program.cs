namespace Quiz_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string[]
            {
                "1. what is capital of italy ?",
                "2. what is the red planet ?",
                "3. what is the largest animal ?"
            };
            string[] answers = new string[]
            {
                "rome",
                "mars",
                "whale"
            };
            int correctanswer = 0;

            Console.WriteLine("welcome to the game");
            Console.WriteLine("please answer the following qestions");
            Console.WriteLine("---------");
           
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                string useranswer = Console.ReadLine();
                try
                {
                    bool result = istheanswercorrect(useranswer, answers[i]);
                    if (result == true)
                    {
                        Console.WriteLine("the answer is correct !");
                        correctanswer ++;
                    }
                    else
                    {
                        Console.WriteLine($"sorry try again , the corrcti answer is {answers[i]}");
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                

            }
            Console.WriteLine($"your score is {correctanswer}/3");

            Console.WriteLine("quiz completed thank you for playing ");


        }
         private static bool istheanswercorrect(string userinput , string coorectanswer) 
        {
            if (string.IsNullOrEmpty(userinput))
            {
                throw new Exception("answer cant be empty");
            }
            //if (userinput == null) -----------> "  "فاضيه
            //{
            //    throw new Exception("answer cant be empty");

            //}
            if (userinput == coorectanswer) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
