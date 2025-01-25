
using Mission3Assignment;

// Defining an empty list to be able to store food items
List<FoodItem> foodItems = new List<FoodItem>();

string userInput;

// Main program loop
do
{
    Console.WriteLine("Welcome to the food bank! What would you like to do?: \n1: Add a food item\n" +
                      "2: Delete a food item\n3: Print a list of current food items\n4: Exit the program");

    // Storing the user's input to go into each process
    userInput = Console.ReadLine();

    if (userInput == "1")
    {
        // Initialize repeating variable
        string anotherFoodItem = "yes";

        while (anotherFoodItem == "yes")
        {
            Console.WriteLine("What is the name of the food item? (e.g. Canned Beans, Milk, Apple): ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the category of the food item? (e.g. Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine();
            
            // Validate the quantity
            int quantity;
            while (true)
            {
                Console.WriteLine("How many would you like to add? (e.g. 15): ");
                string quantityInput = Console.ReadLine();

                if (int.TryParse(quantityInput, out quantity) && quantity > 0)
                {
                    // Break the loop if the quantity is valid
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number greater than 0.\n");
                }
            }
            
            // Prompt for expiration date with error handling
            DateTime expirationDate;
            while (true) // Keep asking until a valid date is provided
            {
                Console.WriteLine("What is the expiration date? (e.g. yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out expirationDate))
                {
                    // Break the loop if the date is valid
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid date format. Please enter the date in the format yyyy-MM-dd.\n");
                }
            }

            // Create a new FoodItem
            FoodItem foodItem = new FoodItem(name, category, quantity, expirationDate);

            // Add the new food items to a list
            foodItems.Add(foodItem);

            // Confirm to user that it was added
            Console.WriteLine("\nFood item added successfully!\n");

            // Ask if the user wants to add another food item
            Console.WriteLine("Would you like to add another food item? (yes/no): ");
            anotherFoodItem = Console.ReadLine().ToLower();

            // Validate yes/no response
            while (anotherFoodItem != "yes" && anotherFoodItem != "no")
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no': ");
                anotherFoodItem = Console.ReadLine().ToLower();
            }
        }
    }
    else if (userInput == "2")
    {
        // If no items inputted, send message
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items available to delete.");
        }
        else
        {
            // Print out a list of food items so user can decide which to delete
            Console.WriteLine("Here are the current food items:");
            for (int i = 0; i < foodItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {foodItems[i].Name} - {foodItems[i].Category} (Qty: {foodItems[i].Quantity}, Expiration: {foodItems[i].ExpirationDate.ToShortDateString()})");
            }
            
            // Making sure that the user selects a food item to delete that is in the range of food items displayed
            int itemToDelete;
            while (true)
            {
                Console.WriteLine("Enter the number of the food item you want to delete (e.g., 1): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out itemToDelete) && itemToDelete > 0 && itemToDelete <= foodItems.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number corresponding to the food item.\n");
                }
            }

            // Confirm deletion
            Console.WriteLine($"Are you sure you want to delete '{foodItems[itemToDelete - 1].Name}'? (yes/no): ");
            string confirm = Console.ReadLine().ToLower();
            
            // Handles if user types anything but yes or no.
            while (confirm != "yes" && confirm != "no")
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no': ");
                confirm = Console.ReadLine().ToLower();
            }
            
            // Delete the item that the user chose and send message or cancel deletion
            if (confirm == "yes")
            {
                foodItems.RemoveAt(itemToDelete - 1);
                Console.WriteLine("Food item deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Deletion canceled.\n");
            }
        }
    }
    else if (userInput == "3")
    {
        // Print current list of food items. If no food items, print out message
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items found.");
        }
        else
        {
            Console.WriteLine("Current food items:");
            foreach (var item in foodItems)
            {
                Console.WriteLine($"Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Expiration Date: {item.ExpirationDate.ToShortDateString()}");
            }
        }
    }
    
    // Exits the program if 4 is inputted. Anything other than 1-4 sends an error and prompts user again
    else if (userInput == "4")
    {
        Console.WriteLine("You have exited the program. Have a nice day!");
    }
    else
    {
        Console.WriteLine("Invalid number. Please select a valid option.");
    }

} while (userInput != "4"); // Loop until the user chooses to exit