using Daguplo_Erica_ShoppingCartActivity;

Console.OutputEncoding = System.Text.Encoding.UTF8;

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
    return;
}

// OUT OF STOCK CHECKKK
if (selected.RemainingStock == 0)
{
    Console.WriteLine("We're sorry, the product is out of stock :(");
    return;
}

// ASK QUANTITY 
Console.Write("Enter quantity: ");
int quantity = int.Parse(Console.ReadLine());

// STOCK CHECKZ 
if (quantity > selected.RemainingStock)
{
    Console.WriteLine("Insufficient Stock available.");
    Console.WriteLine($" Only {selected.RemainingStock} item(s) left.");
    return;
}