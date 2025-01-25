using Mission3Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        bool running = true;
        Console.WriteLine("Hello, welcome to the Food Bank Inventory System!\n");

        // loop here so the user will restart to here if they don't pick 4
        while (running == true)
        {
            Console.WriteLine("What would you like to do?\n 1. Add a new item to the inventory\n 2. Delete an item in the inventory\n 3. Print a list of current food items\n 4.Exit the program");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("You picked add a new item to the inventory");

                // get the inputs to push into the FoodItem class
                Console.WriteLine("What is the name of the food item? (e.g., \"Canned Beans\") ");
                string foodName = Console.ReadLine();
                Console.WriteLine("What is the category of the food item? (e.g., \"Canned Goods\", \"Dairy\", \"Produce\")");
                string foodCategory = Console.ReadLine();

                // Validate the quantity input
                string foodQuantity;
                while (true)
                {
                    Console.WriteLine("What is the quantity of the food item? (e.g., 15 units)");
                    foodQuantity = Console.ReadLine();
                    if (int.TryParse(foodQuantity, out int quantity) && quantity >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
                    }
                }

                Console.WriteLine("What is the expiration date of the food item?");
                string foodExpiration = Console.ReadLine();

                // Create a new FoodItem instance
                FoodItem newItem = new FoodItem(foodName, foodCategory, foodQuantity, foodExpiration);

                Console.WriteLine("Food item added successfully!\n");
            }
            else if (choice == "2")
            {
                Console.WriteLine("You picked delete an item in the inventory");

                // print out the food items from the list with numbers
                if (FoodItem.FoodItemsList.Count == 0)
                {
                    Console.WriteLine("There are no food items to delete.\n");
                }
                else
                {
                    for (int i = 0; i < FoodItem.FoodItemsList.Count; i++)
                    {
                        var item = FoodItem.FoodItemsList[i];
                        Console.WriteLine($"{i + 1}. Name: {item[0]}, Category: {item[1]}, Quantity: {item[2]}, Expiration: {item[3]}");
                    }
                    Console.WriteLine($"{FoodItem.FoodItemsList.Count + 1}. Back to menu\n");

                    // ask "What item would you like to delete?"
                    Console.WriteLine("Enter the number of the item you would like to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteChoice) && deleteChoice > 0 && deleteChoice <= FoodItem.FoodItemsList.Count)
                    {
                        // remove the item from the list
                        FoodItem.FoodItemsList.RemoveAt(deleteChoice - 1);
                        Console.WriteLine("Item deleted successfully!\n");
                    }
                    else if (deleteChoice == (FoodItem.FoodItemsList.Count + 1))
                    {
                        Console.WriteLine("Returning to main menu.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, returning to main menu.\n");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("You picked print a list of current food items");
                // print out the food items from the list
                if (FoodItem.FoodItemsList.Count == 0)
                {
                    Console.WriteLine("There are no food items in the inventory.\n");
                }
                else
                {
                    foreach (var item in FoodItem.FoodItemsList)
                    {
                        Console.WriteLine($"Name: {item[0]}, Category: {item[1]}, Quantity: {item[2]}, Expiration: {item[3]}");
                    }
                    Console.WriteLine();
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("You are now exiting the program");
                // exit the program
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, please pick a valid input\n");
            }
        }
    }
}
