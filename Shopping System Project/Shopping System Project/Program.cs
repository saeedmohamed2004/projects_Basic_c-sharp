namespace Shopping_System_Project
{
    internal class Program
    {
         static public List<string> CartItems = new List<string>();//usercart
         static public Dictionary<string,int> itemprice = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) //stock

         {
             {"Camera",1500 },
             {"Laptop",3000 },
             {"TV",2000 }
         };
        static Stack<string> undoStack = new Stack<string>();
        static void Main(string[] args)
        {

            Console.WriteLine(" Welcome In Store");

            while (true)
            {
                Console.WriteLine("Please inter number ");
                Console.WriteLine("1-Add Item to cart  ");
                Console.WriteLine("2-View Cart Items ");
                Console.WriteLine("3-Remove Item From Cart ");
                Console.WriteLine("4-Checkout ");
                Console.WriteLine("5-Undo Last Action ");
                Console.WriteLine("6-Exit ");
                var choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        Additem();
                        break;
                    case "2":
                        viewcart();
                        break;
                    case "3":
                        Removeitem();
                        break; 
                    case "4":
                        Checkout();
                        break; 
                        case "5":
                        Undo();
                        break; 
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Number, please try again");
                        break;


                }

            }
        }

        private static void Additem() 
        {
            Console.WriteLine("Availabel Items");
            foreach (var item in itemprice)
            {
                Console.WriteLine($"Item:{item.Key} - price:{item.Value}");

            }
            Console.WriteLine("Please inter product Name ");
            string input = Console.ReadLine();
            if (itemprice.ContainsKey(input))                                   //
            {
                CartItems.Add(input);
                undoStack.Push($"item {input} added");
                Console.WriteLine($"item {input} is added to your cart");


            }
            else
            {
                Console.WriteLine("Item is out of stock or not availabel");
            }


        }

        private static void viewcart()
        {
            Console.WriteLine("Your cart item");
            if (CartItems.Any())                                               //
            {
                foreach (var item in CartItems)
                {
                    if (itemprice.TryGetValue(item , out int price))           //
                    {
                        Console.WriteLine($"Item: {item} - Price: {price}");

                    }
                }

            }
            else 
            {
                Console.WriteLine("Cart is empty");
            }
            
        }


        private static void Removeitem()
        {
            viewcart();
            if (CartItems.Any()) 
            {
                Console.WriteLine("Please select item to remove");
                string itemtoremove = Console.ReadLine();

                if (CartItems.Contains(itemtoremove)) 
                {
                    CartItems.Remove(itemtoremove);
                    undoStack.Push($"item {itemtoremove} removed");
                    Console.WriteLine($"item {itemtoremove} is removed ");

                }
                else
                {
                    Console.WriteLine("Item dosent exist ");
                }
            }

        }

        private static void Checkout()
        {
            int total = 0;

            if (CartItems.Any())
            {
                Console.WriteLine("Your Bill:");
                
                foreach (var item in CartItems)
                {
                    if (itemprice.TryGetValue(item, out int price))
                    {
                        Console.WriteLine($"Item: {item} - Price: {price}");
                        total += price;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Cart is empty");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Total Amount: {total}");

            Console.WriteLine("Payment Successful ");

            CartItems.Clear();
            undoStack.Push("checkout");
        }
        private static void Undo()
        {
            if (undoStack.Count > 0)
            {
                string lastaction = undoStack.Pop();
                Console.WriteLine($"Your last action is {lastaction}");

                var actionarray = lastaction.Split();                           //

                if (lastaction.Contains("added"))
                {
                    CartItems.Remove(actionarray[1]);
                }
                else if (lastaction.Contains("removed"))
                {
                    CartItems.Add(actionarray[1]);
                }
                else 
                {
                    Console.WriteLine("checkout cannot be undo");

                }
            }

        }



        



    }
}
