namespace Mission3Assignment;

public class FoodItem
{
    // Setting the properties of each FoodItem
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    // Setting up the constructor to initialize properties
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }    

}