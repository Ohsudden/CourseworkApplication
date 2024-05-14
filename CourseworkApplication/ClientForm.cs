using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CourseworkApplication
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        private List<TextBox> activeTextBoxes = new List<TextBox>();
        private Button activeButton = null;

        private void ClearPreviousControls()
        {
            foreach (var textBox in activeTextBoxes)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }
            activeTextBoxes.Clear();

            if (activeButton != null)
            {
                this.Controls.Remove(activeButton);
                activeButton.Dispose(); 
                activeButton = null;
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point idLocation = new Point(20, 70);
            Point fullNameLocation = new Point(20, 100);
            Point emailLocation = new Point(20, 130);
            Point phoneNumberLocation = new Point(20, 160);
            Point dobLocation = new Point(20, 190);
            Point passwordLocation = new Point(20, 220);
            Point userRoleLocation = new Point(20, 250);

            TextBox idTextBox = new TextBox();
            idTextBox.Location = idLocation;
            this.Controls.Add(idTextBox);
            activeTextBoxes.Add(idTextBox);

            TextBox fullNameTextBox = new TextBox();
            fullNameTextBox.Location = fullNameLocation;
            this.Controls.Add(fullNameTextBox);
            activeTextBoxes.Add(fullNameTextBox);

            TextBox emailTextBox = new TextBox();
            emailTextBox.Location = emailLocation;
            this.Controls.Add(emailTextBox);
            activeTextBoxes.Add(emailTextBox);

            TextBox phoneNumberTextBox = new TextBox();
            phoneNumberTextBox.Location = phoneNumberLocation;
            this.Controls.Add(phoneNumberTextBox);
            activeTextBoxes.Add(phoneNumberTextBox);

            TextBox dobTextBox = new TextBox();
            dobTextBox.Location = dobLocation;
            this.Controls.Add(dobTextBox);
            activeTextBoxes.Add(dobTextBox);

            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Location = passwordLocation;
            this.Controls.Add(passwordTextBox);
            activeTextBoxes.Add(passwordTextBox);

            TextBox userRoleTextBox = new TextBox();
            userRoleTextBox.Location = userRoleLocation;
            this.Controls.Add(userRoleTextBox);
            activeTextBoxes.Add(userRoleTextBox);

            idTextBox.Text = "Customer ID";
            fullNameTextBox.Text = "Full Name";
            emailTextBox.Text = "Email";
            phoneNumberTextBox.Text = "Phone Number";
            dobTextBox.Text = "Date of Birth";
            passwordTextBox.Text = "Password";
            userRoleTextBox.Text = "User Role";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 280);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                // Retrieve values from TextBoxes
                string customerId = idTextBox.Text;
                string fullName = fullNameTextBox.Text;
                string email = emailTextBox.Text;
                string phoneNumber = phoneNumberTextBox.Text;
                string dob = dobTextBox.Text;
                string password = passwordTextBox.Text;
                string userRole = userRoleTextBox.Text;

                string query = $"INSERT INTO Customer (Customer_ID, Full_Name, Email, Phone_Number, Date_of_Birth, Password, userRole) " +
                               $"VALUES ({customerId}, '{fullName}', '{email}', '{phoneNumber}', '{dob}', '{password}', '{userRole}')";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point idLocation = new Point(20, 70);
            Point nameLocation = new Point(20, 100);
            Point categoryLocation = new Point(20, 130);
            Point descriptionLocation = new Point(20, 160);
            Point photoLocation = new Point(20, 190);
            Point priceLocation = new Point(20, 220);

            TextBox idTextBox = new TextBox();
            idTextBox.Location = idLocation;
            this.Controls.Add(idTextBox);
            activeTextBoxes.Add(idTextBox);

            TextBox nameTextBox = new TextBox();
            nameTextBox.Location = nameLocation;
            this.Controls.Add(nameTextBox);
            activeTextBoxes.Add(nameTextBox);

            TextBox categoryTextBox = new TextBox();
            categoryTextBox.Location = categoryLocation;
            this.Controls.Add(categoryTextBox);
            activeTextBoxes.Add(categoryTextBox);

            TextBox descriptionTextBox = new TextBox();
            descriptionTextBox.Location = descriptionLocation;
            this.Controls.Add(descriptionTextBox);
            activeTextBoxes.Add(descriptionTextBox);

            TextBox photoTextBox = new TextBox();
            photoTextBox.Location = photoLocation;
            this.Controls.Add(photoTextBox);
            activeTextBoxes.Add(photoTextBox);

            TextBox priceTextBox = new TextBox();
            priceTextBox.Location = priceLocation;
            this.Controls.Add(priceTextBox);
            activeTextBoxes.Add(priceTextBox);

            idTextBox.Text = "Product ID";
            nameTextBox.Text = "Product Name";
            categoryTextBox.Text = "Product Category";
            descriptionTextBox.Text = "Product Description";
            photoTextBox.Text = "Product Photo URL";
            priceTextBox.Text = "Unit Price";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);

            submitButton.Location = new Point(150, 250);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                // Retrieve values from TextBoxes
                string productId = idTextBox.Text;
                string productName = nameTextBox.Text;
                string productCategory = categoryTextBox.Text;
                string productDescription = descriptionTextBox.Text;
                string productPhoto = photoTextBox.Text;

                if (!decimal.TryParse(priceTextBox.Text, out decimal unitPrice))
                {
                    MessageBox.Show("Error.");
                    return;
                }

                string query = $"INSERT INTO Product (Product_ID, Product_Name, Product_Category, Product_Description, Product_Photo, Unit_Price) " +
                               $"VALUES ({productId}, '{productName}', '{productCategory}', '{productDescription}', '{productPhoto}', {unitPrice})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void productWithReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point reviewIdLocation = new Point(20, 70);
            Point productIdLocation = new Point(20, 100);

            TextBox reviewIdTextBox = new TextBox();
            reviewIdTextBox.Location = reviewIdLocation;
            this.Controls.Add(reviewIdTextBox);
            activeTextBoxes.Add(reviewIdTextBox);

            TextBox productIdTextBox = new TextBox();
            productIdTextBox.Location = productIdLocation;
            this.Controls.Add(productIdTextBox);
            activeTextBoxes.Add(productIdTextBox);

            reviewIdTextBox.Text = "Review ID";
            productIdTextBox.Text = "Product ID";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 130);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string reviewId = reviewIdTextBox.Text;
                string productId = productIdTextBox.Text;

                string query = $"INSERT INTO ProductWithReview (Review_ID, Product_ID) " +
                               $"VALUES ({reviewId}, {productId})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void orderTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point orderIdLocation = new Point(20, 70);
            Point customerIdLocation = new Point(20, 100);
            Point orderStatusLocation = new Point(20, 130);
            Point costLocation = new Point(20, 160);
            Point orderDateLocation = new Point(20, 190);
            Point paymentMethodLocation = new Point(20, 220);
            Point cartIdLocation = new Point(20, 250);

            TextBox orderIdTextBox = new TextBox();
            orderIdTextBox.Location = orderIdLocation;
            this.Controls.Add(orderIdTextBox);
            activeTextBoxes.Add(orderIdTextBox);

            TextBox customerIdTextBox = new TextBox();
            customerIdTextBox.Location = customerIdLocation;
            this.Controls.Add(customerIdTextBox);
            activeTextBoxes.Add(customerIdTextBox);

            TextBox orderStatusTextBox = new TextBox();
            orderStatusTextBox.Location = orderStatusLocation;
            this.Controls.Add(orderStatusTextBox);
            activeTextBoxes.Add(orderStatusTextBox);

            TextBox costTextBox = new TextBox();
            costTextBox.Location = costLocation;
            this.Controls.Add(costTextBox);
            activeTextBoxes.Add(costTextBox);

            TextBox orderDateTextBox = new TextBox();
            orderDateTextBox.Location = orderDateLocation;
            this.Controls.Add(orderDateTextBox);
            activeTextBoxes.Add(orderDateTextBox);

            TextBox paymentMethodTextBox = new TextBox();
            paymentMethodTextBox.Location = paymentMethodLocation;
            this.Controls.Add(paymentMethodTextBox);
            activeTextBoxes.Add(paymentMethodTextBox);

            TextBox cartIdTextBox = new TextBox();
            cartIdTextBox.Location = cartIdLocation;
            this.Controls.Add(cartIdTextBox);
            activeTextBoxes.Add(cartIdTextBox);

            orderIdTextBox.Text = "Order ID";
            customerIdTextBox.Text = "Customer ID";
            orderStatusTextBox.Text = "Order Status";
            costTextBox.Text = "Cost";
            orderDateTextBox.Text = "Order Date";
            paymentMethodTextBox.Text = "Payment Method";
            cartIdTextBox.Text = "Cart ID";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 280);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string orderId = orderIdTextBox.Text;
                string customerId = customerIdTextBox.Text;
                string orderStatus = orderStatusTextBox.Text;
                string cost = costTextBox.Text;
                string orderDate = orderDateTextBox.Text;
                string paymentMethod = paymentMethodTextBox.Text;
                string cartId = cartIdTextBox.Text;

                string query = $"INSERT INTO OrderTable (Order_ID, Customer_ID, Order_Status, Cost, Order_Date, Payment_Method, Cart_ID) " +
                               $"VALUES ({orderId}, {customerId}, '{orderStatus}', {cost}, '{orderDate}', '{paymentMethod}', {cartId})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }




        private void deliveryAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point addressIdLocation = new Point(20, 70);
            Point customerIdLocation = new Point(20, 100);
            Point orderIdLocation = new Point(20, 130);
            Point deliveryAddressLocation = new Point(20, 160);

            TextBox addressIdTextBox = new TextBox();
            addressIdTextBox.Location = addressIdLocation;
            this.Controls.Add(addressIdTextBox);
            activeTextBoxes.Add(addressIdTextBox);

            TextBox customerIdTextBox = new TextBox();
            customerIdTextBox.Location = customerIdLocation;
            this.Controls.Add(customerIdTextBox);
            activeTextBoxes.Add(customerIdTextBox);

            TextBox orderIdTextBox = new TextBox();
            orderIdTextBox.Location = orderIdLocation;
            this.Controls.Add(orderIdTextBox);
            activeTextBoxes.Add(orderIdTextBox);

            TextBox deliveryAddressTextBox = new TextBox();
            deliveryAddressTextBox.Location = deliveryAddressLocation;
            this.Controls.Add(deliveryAddressTextBox);
            activeTextBoxes.Add(deliveryAddressTextBox);

            addressIdTextBox.Text = "Address ID";
            customerIdTextBox.Text = "Customer ID";
            orderIdTextBox.Text = "Order ID";
            deliveryAddressTextBox.Text = "Delivery Address";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 190);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string addressId = addressIdTextBox.Text;
                string customerId = customerIdTextBox.Text;
                string orderId = orderIdTextBox.Text;
                string deliveryAddress = deliveryAddressTextBox.Text;

                string query = $"INSERT INTO DeliveryAddress (Address_ID, Customer_ID, Order_ID, Delivery_Address) " +
                               $"VALUES ({addressId}, {customerId}, {orderId}, '{deliveryAddress}')";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void cartContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point productIdLocation = new Point(20, 70);
            Point cartIdLocation = new Point(20, 100);
            Point quantityLocation = new Point(20, 130);

            TextBox productIdTextBox = new TextBox();
            productIdTextBox.Location = productIdLocation;
            this.Controls.Add(productIdTextBox);
            activeTextBoxes.Add(productIdTextBox);

            TextBox cartIdTextBox = new TextBox();
            cartIdTextBox.Location = cartIdLocation;
            this.Controls.Add(cartIdTextBox);
            activeTextBoxes.Add(cartIdTextBox);

            TextBox quantityTextBox = new TextBox();
            quantityTextBox.Location = quantityLocation;
            this.Controls.Add(quantityTextBox);
            activeTextBoxes.Add(quantityTextBox);

            productIdTextBox.Text = "Product ID";
            cartIdTextBox.Text = "Cart ID";
            quantityTextBox.Text = "Quantity";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);


            submitButton.Location = new Point(150, 160);
            submitButton.Click += (btnSender, btnEvent) =>
            {
               
                string productId = productIdTextBox.Text;
                string cartId = cartIdTextBox.Text;
                string quantity = quantityTextBox.Text;

                string query = $"INSERT INTO CartContents (Product_ID, Cart_ID, Quantity) " +
                               $"VALUES ({productId}, {cartId}, {quantity})";

                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }


        private void productReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point reviewIdLocation = new Point(20, 70);
            Point customerIdLocation = new Point(20, 100);
            Point productIdLocation = new Point(20, 130);
            Point reviewTextLocation = new Point(20, 160);
            Point ratingLocation = new Point(20, 190);

            TextBox reviewIdTextBox = new TextBox();
            reviewIdTextBox.Location = reviewIdLocation;
            this.Controls.Add(reviewIdTextBox);
            activeTextBoxes.Add(reviewIdTextBox);

            TextBox customerIdTextBox = new TextBox();
            customerIdTextBox.Location = customerIdLocation;
            this.Controls.Add(customerIdTextBox);
            activeTextBoxes.Add(customerIdTextBox);

            TextBox productIdTextBox = new TextBox();
            productIdTextBox.Location = productIdLocation;
            this.Controls.Add(productIdTextBox);
            activeTextBoxes.Add(productIdTextBox);

            TextBox reviewTextBox = new TextBox();
            reviewTextBox.Location = reviewTextLocation;
            this.Controls.Add(reviewTextBox);
            activeTextBoxes.Add(reviewTextBox);

            TextBox ratingTextBox = new TextBox();
            ratingTextBox.Location = ratingLocation;
            this.Controls.Add(ratingTextBox);
            activeTextBoxes.Add(ratingTextBox);

            reviewIdTextBox.Text = "Review ID";
            customerIdTextBox.Text = "Customer ID";
            productIdTextBox.Text = "Product ID";
            reviewTextBox.Text = "Review Text";
            ratingTextBox.Text = "Rating";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 220);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string reviewId = reviewIdTextBox.Text;
                string customerId = customerIdTextBox.Text;
                string productId = productIdTextBox.Text;
                string reviewText = reviewTextBox.Text;

                if (!decimal.TryParse(ratingTextBox.Text, out decimal rating))
                {
                    MessageBox.Show("Error.");
                    return;
                }

                string query = $"INSERT INTO ProductReview (Review_ID, Customer_ID, Product_ID, Review_Text, Rating) " +
                               $"VALUES ({reviewId}, {customerId}, {productId}, '{reviewText}', {rating})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }


        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point sellerIdLocation = new Point(20, 70);
            Point productIdLocation = new Point(20, 100);

            TextBox sellerIdTextBox = new TextBox();
            sellerIdTextBox.Location = sellerIdLocation;
            this.Controls.Add(sellerIdTextBox);
            activeTextBoxes.Add(sellerIdTextBox);

            TextBox productIdTextBox = new TextBox();
            productIdTextBox.Location = productIdLocation;
            this.Controls.Add(productIdTextBox);
            activeTextBoxes.Add(productIdTextBox);

            sellerIdTextBox.Text = "Seller ID";
            productIdTextBox.Text = "Product ID";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 130);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string sellerId = sellerIdTextBox.Text;
                string productId = productIdTextBox.Text;

                string query = $"INSERT INTO Seller (Seller_ID, Product_ID) " +
                               $"VALUES ({sellerId}, {productId})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void sellerProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPreviousControls();

            Point sellerIdLocation = new Point(20, 70);
            Point productIdLocation = new Point(20, 100);

            TextBox sellerIdTextBox = new TextBox();
            sellerIdTextBox.Location = sellerIdLocation;
            this.Controls.Add(sellerIdTextBox);
            activeTextBoxes.Add(sellerIdTextBox);

            TextBox productIdTextBox = new TextBox();
            productIdTextBox.Location = productIdLocation;
            this.Controls.Add(productIdTextBox);
            activeTextBoxes.Add(productIdTextBox);

            sellerIdTextBox.Text = "Seller ID";
            productIdTextBox.Text = "Product ID";

            Button submitButton = new Button();
            submitButton.Text = "Підтвердити";
            submitButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular);
            submitButton.Size = new Size(150, 40);
            submitButton.Location = new Point(150, 130);
            submitButton.Click += (btnSender, btnEvent) =>
            {
                string sellerId = sellerIdTextBox.Text;
                string productId = productIdTextBox.Text;

                string query = $"INSERT INTO SellerProduct (Seller_ID, Product_ID) " +
                               $"VALUES ({sellerId}, {productId})";
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        ExecuteChangingQuery(con, query);
                    }
                }
                

            };

            this.Controls.Add(submitButton);
            activeButton = submitButton; 
        }

        private void ExecuteChangingQuery(NpgsqlConnection connection, string query)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rowsAffected} строк додано.",
                        "Query Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Server=localhost;Port=5432;Database=Online store;User Id=postgres;Password=admin;");
        }
        private DataTable ExecuteQuery(NpgsqlConnection connection, string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка при виконанні запита: {ex.Message}");
            }

            return dataTable;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void connectAndExecute(string query)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    DataTable dataTable = ExecuteQuery(con, query);
                    Form2 resultForm = new Form2(dataTable);
                    resultForm.ShowDialog();

                }
            }
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM Customer";

            connectAndExecute(query);
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM Product";

            connectAndExecute(query);
        }

        private void shoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM ShoppingCart";

            connectAndExecute(query);
        }

        private void orderTableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM OrderTable";

            connectAndExecute(query);
        }

        private void deliveryAddressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM DeliveryAddress";

            connectAndExecute(query);
        }

        private void cartContentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM CartContents";

            connectAndExecute(query);
        }

        private void productReviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM ProductReview";

            connectAndExecute(query);
        }

        private void productWithReviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM ProductWithReview";

            connectAndExecute(query);
        }

        private void productQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM ProductQuantity";

            connectAndExecute(query);
        }

        private void sellerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM Seller";

            connectAndExecute(query);
        }

        private void sellerProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM SellerProduct";

            connectAndExecute(query);
        }

        private void findTop3ByRating(object sender, EventArgs e)
        {
            string query = "SELECT Product.Product_Name, Product.Product_Category, AVG(ProductReview.Rating) AS Average_Rating\r\nFROM Product\r\nJOIN ProductWithReview ON Product.Product_ID = ProductWithReview.Product_ID\r\nJOIN ProductReview ON ProductReview.Review_ID = ProductWithReview.Review_ID\r\nGROUP BY Product.Product_Name, Product.Product_Category\r\nORDER BY Average_Rating DESC\r\nLIMIT 3;";
            connectAndExecute(query);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
