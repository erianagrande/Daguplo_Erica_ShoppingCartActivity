using Daguplo_Erica_ShoppingCartActivity;

Console.OutputEncoding = System.Text.Encoding.UTF8;


List<CartItem> cart = new List<CartItem>();
double grandTotal = 0;
bool continueShopping = true;

Product[] products = new Product[]
{ 
    new Product(1, "Peptide Lip Care", 250, 0),
    new Product(2, "Lipliner", 199, 10),
    new Product(3, "Liquid Blush", 225, 10),
    new Product(4, "Waterproof Mascara", 199, 10),
    new Product(5, "Eyeshadow Palette", 300, 10),
    new Product(6, "Powder Blush", 245, 10),
};

Console.WriteLine(" Welcome to Eri the Label!");
Console.WriteLine("---------------------------");

while (continueShopping)

{

    // DISPLAY MENU
    foreach (Product p in products)
    {
        p.DisplayProduct();
    }

    // USER INPUT
    Console.Write("\nEnter product number:");
    int productNum = int.Parse(Console.ReadLine());

    // DECLARE selected here
    Product selected = null;

    // FIND SELECTED PRODUCT
    foreach (Product p in products)
    {
        if (p.Id == productNum)
        {
            selected = p;
            break;
        }
    }
    // VALIDATION
    if (selected == null)
    {
        Console.WriteLine("Invalid product number!");
        continue;
    }

    // OUT OF STOCK CHECKKK
    if (selected.RemainingStock == 0)
    {
        Console.WriteLine("We're sorry, the product is out of stock :(");
        continue;
    }

    // ASK QUANTITY 
    Console.Write("Enter quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    // STOCK CHECKZ 
    if (quantity > selected.RemainingStock)
    {
        Console.WriteLine("Insufficient Stock available.");
        Console.WriteLine($" Only {selected.RemainingStock} item(s) left.");
        continue;
    }

    // COMPUTE ITEM'S TOTAL
    double itemTotal = selected.Price * quantity;

    // ADD TO CART
    CartItem existingItem = null;

    foreach (var item in cart)
    {
        if (item.Product.Id == selected.Id)
        {
            existingItem = item;
            break;
        }
    }

    if (existingItem != null)
    {
        existingItem.Quantity += quantity;
    }
    else
    {
        cart.Add(new CartItem
        {
            Product = selected,
            Quantity = quantity
        });
    }

    // DEDUCT STOCK
    selected.DeductStock(quantity);

    // ADD TO GRAND TOTAL
    grandTotal += itemTotal;

    // CONFIRMATION MESSAGE
    Console.WriteLine("Item added to cart successfully!");

    // QUESTIONNN
    Console.Write("Do you want to add more items? (y/n): ");
    string choice = Console.ReadLine().ToLower();

    if (choice != "y")
    {
        continueShopping = false;
    }
}