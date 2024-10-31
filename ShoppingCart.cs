using System.Collections.Generic;
using System.Linq;

public class ShoppingCart
{
    private List<Product> cartItems;

    public ShoppingCart()
    {
        cartItems = new List<Product>();
    }

    public void AddToCart(Product product)
    {
        var existingProduct = cartItems.FirstOrDefault(p => p.Name == product.Name);
        if (existingProduct != null)
        {
            existingProduct.Quantity += product.Quantity; 
        }
        else
        {
            cartItems.Add(product); 
        }
    }

    public void RemoveFromCart(Product product)
    {
        cartItems.Remove(product);
    }

 
    public List<Product> GetCartItems()
    {
        return cartItems; 
    }


    public decimal GetTotalPrice()
    {
        return cartItems.Sum(item => item.Price * item.Quantity);
    }
}
