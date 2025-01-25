
using Mission3Assignment;

// Defining an empty list to be able to store food items
List<FoodItem> foodItems = new List<FoodItem>();

Console.WriteLine("Welcome to the food bank! What would you like to do?: \n1: Add a food item\n" +
                  "2: Delete a food item\n3: Print a list of current food items\n4: Exit the program");

// Storing the user's input to go into each process
string userInput = Console.ReadLine();

while (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
{

    if (userInput == "1")
    {
        // Initialize repeating variable
        string anotherFoodItem = "yes";

        while (anotherFoodItem == "yes")
        {
            Console.WriteLine("What is the name of the food item? (e.g. Canned Beans): ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the category of the food item? (e.g. Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine();
            Console.WriteLine("How many would you like to add? (e.g. 15): ");
            int quantity = int.Parse(Console.ReadLine()); // Converting string to integer
            Console.WriteLine("What is the expiration date? (e.g. yyyy-MM-dd): ");
            DateTime expirationDate = DateTime.Parse(Console.ReadLine()); // Converting string to DateTime

            // Create a new FoodItem
            FoodItem foodItem = new FoodItem(name, category, quantity, expirationDate);

            // Add the new food items to a list
            foodItems.Add(foodItem);

            // Confirm to user that it was added
            Console.WriteLine("Food item added successfully!");

            // Ask if the user wants to add another food item
            Console.WriteLine("Would you like to add another food item? (yes/no): ");
            anotherFoodItem = Console.ReadLine();
            anotherFoodItem = anotherFoodItem.ToLower();

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

    }
    else if (userInput == "3")
    {

    }
    else if (userInput == "4")
    {
        Console.WriteLine("You have exited the program. Have a nice day!");
    }
    else
    {
        Console.WriteLine("Invalid number. Please select a valid option.");
    }
}