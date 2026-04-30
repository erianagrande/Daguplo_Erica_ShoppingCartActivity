using Daguplo_Erica_ShoppingCartActivity;

Console.OutputEncoding = System.Text.Encoding.UTF8;


int cartSize = 5 ;
Product[] cart = new Product[cartSize];
int[] quantities = new int[cartSize];
int cartCount = 0;
double grandTotal = 0;
bool continueShopping = true;

Product[] products = new Product[]
{ 
    new Product(1, "Peptide Lip Care", 250, 10),
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
    Console.WriteLine("\n===== OUR PRODUCTS =====");

    foreach (Product p in products)
    {
        Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} (Stock: {p.RemainingStock})");
    }


    // USER INPUT
    Console.Write("\nEnter product number:");
    int productNum = int.Parse(Console.ReadLine());

    // FIND PRODUCT
    Product selected = null;

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
        Console.WriteLine("The product is out of stock! We're sorry.");
        continue;
    }

    // ASK QUANTITY 
    Console.Write("Enter quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    // STOCK CHECKZ 
    if (quantity > selected.RemainingStock)
    {
        Console.WriteLine("Insufficient Stock available.");
        continue;
    }
    
    // CART FULL CHECK
    if (cartCount >= cartSize)
    {
        Console.WriteLine("Cart is full! Sadly, you can no longer add more items.");
        continue;
    }

    // ADD TO CART 
    bool found = false;

    for (int i = 0; i < cartCount; i++)
    {
        if (cart[i].Id == selected.Id)
        {
            quantities[i] += quantity;
            found = true;
            break; 
        }

    }

    if (!found)
    {
        cart[cartCount] = selected;
        quantities[cartCount] = quantity;
        cartCount++;
    }

    // DEDUCT STOCK
    selected.DeductStock(quantity);

    // CONFIRMATION MESSAGE
    Console.WriteLine("Item added to cart successfully!");

    // DISPLAY CART 
    Console.WriteLine("\n--- CART ---");

    for (int i = 0; i < cartCount; i++)
    {
        Console.WriteLine($"{cart[i].Name} x{quantities[i]}");
    }

    // CONTINUE?
    Console.Write("Do you want to add more items? (y/n): ");
    string choice = Console.ReadLine().ToLower();

    if (choice != "y")
    {
        continueShopping = false;
    }
}

// RECEIPT

Console.WriteLine("\n===== RECEIPT =====");

grandTotal = 0;

for (int i = 0; i < cartCount; i++)
{
    double total = cart[i].Price * quantities[i];
    grandTotal += total;

    Console.WriteLine($"{cart[i].Name} x{quantities[i]} = ₱{total}");
}

Console.WriteLine("---------------------");
Console.WriteLine($"Grand Total: ₱{grandTotal}");

// DISCOUNT

double discount = 0;

if (grandTotal >= 5000)
{
    discount = grandTotal * 0.10;
}

double finalTotal = grandTotal - discount;

Console.WriteLine($"Discount: ₱{discount}");
Console.WriteLine($"Final Total: ₱{finalTotal}");

// UPDATED STOCK !

Console.WriteLine("\n===== UPDATED STOCK =====");

foreach (Product p in products)
{
    Console.WriteLine($"{p.Name} - Stock left: {p.RemainingStock}");
}




