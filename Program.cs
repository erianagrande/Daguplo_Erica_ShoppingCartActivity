using Daguplo_Erica_ShoppingCartActivity;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Product[] products = new Product[]
{ 
    new Product(1, "Peptide Lip Care", 250, 10),
    new Product(1, "Lipliner", 199, 10),
    new Product(1, "Liquid Blush", 225, 10),
    new Product(1, "Waterproof Mascara", 199, 10),
    new Product(1, "Eyeshadow Palette", 300, 10),
    new Product(1, "Powder Blush", 245, 10),
};

Console.WriteLine(" Welcome to Eri the Label!");
Console.WriteLine("---------------------------");

foreach (Product p in products)
{
    p.DisplayProduct();
}

    