public class Product
{
    public string Image { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string image, string name, decimal price, int quantity)
    {
        Image = image;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name} - Giá: {Price:C} - Số lượng: {Quantity}";
    }
}
