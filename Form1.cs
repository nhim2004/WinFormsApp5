
using System.Linq;  // Thêm dòng này

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {

        private List<Product> products;
        private ShoppingCart cart;
        public Form1()
        {
            cart = new ShoppingCart();
            InitializeProducts();
            InitializeComponent();
            DisplayProducts();

        }


         private void InitializeShoppingCart() => cart = new ShoppingCart();

        private void InitializeProducts()
        {

            products = new List<Product>
            {
                new Product(null, "Sản phẩm 1", 100, 1),
                new Product(null, "Sản phẩm 2", 200, 1),
                new Product(null, "Sản phẩm 3", 300, 1)
            };
        }

        private void DisplayProducts()
        {
            listBox1.DataSource = products;
            listBox1.DisplayMember = "Name";
        }

        private void UpdateCartDisplay()
        {

            dataGridView1.Rows.Clear();

            foreach (var item in cart.GetCartItems())
            {
                dataGridView1.Rows.Add(
                    item.Name,                        
                    item.Price,                       
                    item.Quantity                     
                );
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Product selectedProduct)
            {
                var productToAdd = new Product(selectedProduct.Image, selectedProduct.Name, selectedProduct.Price, 1);
                cart.AddToCart(productToAdd);  
                UpdateCartDisplay();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm vào giỏ hàng.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var selectedProduct = dataGridView1.CurrentRow?.DataBoundItem as Product;

            if (selectedProduct != null)
            {

                string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng mới cho sản phẩm:", "Cập nhật Số lượng", selectedProduct.Quantity.ToString()
                );


                if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
                {
                    selectedProduct.Quantity = newQuantity;
                    UpdateCartDisplay();
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số nguyên dương.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedProduct = dataGridView1.CurrentRow?.DataBoundItem as Product;

            if (selectedProduct != null)
            {
                cart.RemoveFromCart(selectedProduct); 
                UpdateCartDisplay(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa khỏi giỏ hàng.");
            }

        }
    }
}

