using System;

namespace Inventory_Management_System
{
    internal class Program

    {
        static int numberofproduct = 50;
        static string[,] inventory = new string[numberofproduct, 3];

        static int productcount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("welcom in Inventory Management System ");
            Console.WriteLine("--------------------- ");
            while (true)
            {
                Console.WriteLine("Enter your choice ");
                Console.WriteLine("1 Add ");
                Console.WriteLine("2 update ");
                Console.WriteLine("3 view ");
                Console.WriteLine("4 exit ");
                Console.WriteLine("--------------------- ");
                string userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        //add
                        Addproduct();
                        break;
                    case "2":
                        //update();
                        updateproduct();
                        break;
                    case "3":
                        viewproducts();
                        break;
                    case "4":
                        //exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please enter num correct ");
                        break;
                }
            }
        }

        static private void Addproduct()
        {
            Console.WriteLine("enter of name product");
            string name = Console.ReadLine();

            Console.WriteLine("enter of quantity product");
            string quantity = Console.ReadLine();

            Console.WriteLine("enter of price product");
            string price = Console.ReadLine();

            inventory[productcount, 0] = name;
            inventory[productcount, 1] = quantity;
            inventory[productcount, 2] = price;

            productcount++;

            Console.WriteLine("the product add successfull");
        }
        static private void viewproducts()
        {
            if (productcount == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            Console.WriteLine("Products List");
            Console.WriteLine("---------------------");

            for (int i = 0; i < productcount; i++)   
            {
                Console.Write($"ID: {i} | ");

                for (int j = 0; j < inventory.GetLength(1); j++) 
                {
                    if (j == 0)
                        Console.Write($"Name: {inventory[i, j]} | ");
                    else if (j == 1)
                        Console.Write($"Qty: {inventory[i, j]} | ");
                    else if (j == 2)
                        Console.Write($"Price: {inventory[i, j]} ");
                }

                Console.WriteLine();
            }
        }
        static private void updateproduct()
        {
            if (productcount == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            viewproducts();

            Console.WriteLine("Enter product ID to update:");
            string inputId = Console.ReadLine();

            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            if (id < 0 || id >= productcount)
            {
                Console.WriteLine("Product ID not found");
                return;
            }

            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Quantity");
            Console.WriteLine("3 - Price");
            Console.WriteLine("4 - All");

            string choice = Console.ReadLine();

            // 6️⃣ تنفيذ التعديل
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new name:");
                    inventory[id, 0] = Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Enter new quantity:");
                    inventory[id, 1] = Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("Enter new price:");
                    inventory[id, 2] = Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("Enter new name:");
                    inventory[id, 0] = Console.ReadLine();

                    Console.WriteLine("Enter new quantity:");
                    inventory[id, 1] = Console.ReadLine();

                    Console.WriteLine("Enter new price:");
                    inventory[id, 2] = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            // 7️⃣ نجاح العملية
            Console.WriteLine("Product updated successfully");
        }


    }



    
}

