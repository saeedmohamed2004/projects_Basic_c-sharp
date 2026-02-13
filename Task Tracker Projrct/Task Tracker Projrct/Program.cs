namespace Task_Tracker_Projrct
{
    internal class Program
    {

        static string[] tasks = new string [1000];
        static int taskindex = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("welcom in my tasks ");
            Console.WriteLine("--------------------- ");
            while (true)
            {
                Console.WriteLine("Enter your choice ");
                Console.WriteLine("1 Add ");
                Console.WriteLine("2 view ");
                Console.WriteLine("3 complete ");
                Console.WriteLine("4 delete ");
                Console.WriteLine("5 exit ");
                Console.WriteLine("--------------------- ");
                string userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        //add
                        Addtask();
                        break;
                    case "2":
                        //view
                        Viewtask();
                        break;
                    case "3":
                        //complete
                        markcomplete();
                        break;
                    case "4":
                        //delete
                        Delete();
                        break;
                    case "5":
                        //exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please enter num correct ");
                        break;
                }
            }
        }
        private static void Addtask()
        {
            Console.WriteLine("--------------------- ");
            Console.WriteLine("enter your task name ");
            string tasktitle = Console.ReadLine();

            tasks[taskindex] = tasktitle;
            
            Console.WriteLine("Task Added");
            Console.WriteLine("--------------------- ");
            
            taskindex++;

        }
        private static void Viewtask()
        {
            Console.WriteLine("--------------------- ");

            Console.WriteLine("Task list :");
            for (int i = 0; i < taskindex; i++)
            {
                Console.WriteLine($"{i+1} task title :  {tasks[i]}");
            }
            Console.WriteLine("--------------------- ");

        }
        private static void markcomplete()
        {
            Console.WriteLine("--------------------- ");

            Console.WriteLine("Enter Task Number");
            int tasknum=Convert.ToInt32(Console.ReadLine());

            tasks[tasknum]=tasks[tasknum]+ " Completed";
            Console.WriteLine("Task completed successfull");
            Console.WriteLine("--------------------- ");



        }
        private static void Delete() 
        {
            Console.WriteLine("--------------------- ");

            Console.WriteLine("Enter Task Number to delete");
            int tasknum = Convert.ToInt32(Console.ReadLine());

            tasks[tasknum] = string.Empty;
            Console.WriteLine("Task Deleted  successfull");
            Console.WriteLine("--------------------- ");

        }




    }
}
