using Daguplo_Erica_ShoppingCartActivity;

Console.OutputEncoding = System.Text.Encoding.UTF8;


int cartSize = 5;
Product[] cart = new Product[cartSize];
int[] quantities = new int[cartSize];
int cartCount = 0;
double grandTotal = 0;

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

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1. View Products/Add to Cart");
    Console.WriteLine("2. View Cart");
    Console.WriteLine("3. Remove Item");
    Console.WriteLine("4. Update Quantity");
    Console.WriteLine("5. Clear Cart");
    Console.WriteLine("6. Exit");

    Console.Write("Choose option: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        // 1. ADD TO CART

        case 1: 

            Console.WriteLine("\n===== PRODUCTS =====");

            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} (Stock: {p.RemainingStock})");
            }

            Console.Write("\nEnter product number:");
            int productNum = int.Parse(Console.ReadLine());

            Product selected = null;

            foreach (Product p in products)
            {
                if (p.Id == productNum)
                {
                    selected = p;
                    break;
                }
            }

            if (selected == null)
            {
                Console.WriteLine("Invalid product!");
                break;
            }

            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("The product is out of stock! We're sorry.");
                break;
            }

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity > selected.RemainingStock)
            {
                Console.WriteLine("Not enough stock!");
                break;
            }

            if (cartCount >= cartSize)
            {
                Console.WriteLine("Cart is full! Sadly, you can no longer add more items.");
                break;
            }

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

            selected.DeductStock(quantity);

            Console.WriteLine("Item added to cart!");
            break;

        // 2. VIEW CART

        case 2:

            Console.WriteLine("\n===== CART =====");

            if (cartCount == 0)
            {
                Console.WriteLine("Cart is empty.");
                break;
            }

            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{i + 1}. {cart[i].Name} x{quantities[i]}");
            }
            break;

        // 3. REMOVE ITEM

        case 3:

            Console.Write("Enter item number to remove: ");
            int removeIndex = int.Parse(Console.ReadLine()) - 1;

            if (removeIndex >= 0 && removeIndex < cartCount)
            {
                cart[removeIndex] = cart[cartCount - 1];
                quantities[removeIndex] = quantities[cartCount - 1];
                cartCount--;

                Console.WriteLine("Item removed!");
            }
            else
            {
                Console.WriteLine("Invalid item.");
            }
            break;

        // 4. UPDATE QUANTITY

        case 4:

            Console.Write("Enter item number: ");
            int updateIndex = int.Parse(Console.ReadLine()) - 1;

            if (updateIndex >= 0 && updateIndex < cartCount)
            {
                Console.Write("New quantity: ");
                int newQty = int.Parse(Console.ReadLine());

                quantities[updateIndex] = newQty;

                Console.WriteLine("Quantity updated!");
            }
            else
            {
                Console.WriteLine("Invalid item.");
            }
            break;

        // 5. CLEAR CART

        case 5:

            cartCount = 0;
            Console.WriteLine("Cart cleared!");
            break;

        // 6. EXIT 

        case 6:

            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
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




