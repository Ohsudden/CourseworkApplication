namespace CourseworkApplication
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productWithReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.productToolStripMenuItem,
            this.orderTableToolStripMenuItem,
            this.deliveryAddressToolStripMenuItem,
            this.cartContentsToolStripMenuItem,
            this.productReviewToolStripMenuItem,
            this.productWithReviewToolStripMenuItem,
            this.sellerToolStripMenuItem,
            this.sellerProductToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(163, 202);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // orderTableToolStripMenuItem
            // 
            this.orderTableToolStripMenuItem.Name = "orderTableToolStripMenuItem";
            this.orderTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orderTableToolStripMenuItem.Text = "OrderTable";
            this.orderTableToolStripMenuItem.Click += new System.EventHandler(this.orderTableToolStripMenuItem_Click);
            // 
            // deliveryAddressToolStripMenuItem
            // 
            this.deliveryAddressToolStripMenuItem.Name = "deliveryAddressToolStripMenuItem";
            this.deliveryAddressToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deliveryAddressToolStripMenuItem.Text = "DeliveryAddress";
            this.deliveryAddressToolStripMenuItem.Click += new System.EventHandler(this.deliveryAddressToolStripMenuItem_Click);
            // 
            // cartContentsToolStripMenuItem
            // 
            this.cartContentsToolStripMenuItem.Name = "cartContentsToolStripMenuItem";
            this.cartContentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cartContentsToolStripMenuItem.Text = "CartContents";
            this.cartContentsToolStripMenuItem.Click += new System.EventHandler(this.cartContentsToolStripMenuItem_Click);
            // 
            // productReviewToolStripMenuItem
            // 
            this.productReviewToolStripMenuItem.Name = "productReviewToolStripMenuItem";
            this.productReviewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productReviewToolStripMenuItem.Text = "ProductReview";
            this.productReviewToolStripMenuItem.Click += new System.EventHandler(this.productReviewToolStripMenuItem_Click);
            // 
            // productWithReviewToolStripMenuItem
            // 
            this.productWithReviewToolStripMenuItem.Name = "productWithReviewToolStripMenuItem";
            this.productWithReviewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productWithReviewToolStripMenuItem.Text = "ProductQuantity";
            this.productWithReviewToolStripMenuItem.Click += new System.EventHandler(this.productWithReviewToolStripMenuItem_Click);
            // 
            // sellerToolStripMenuItem
            // 
            this.sellerToolStripMenuItem.Name = "sellerToolStripMenuItem";
            this.sellerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sellerToolStripMenuItem.Text = "Seller";
            this.sellerToolStripMenuItem.Click += new System.EventHandler(this.sellerToolStripMenuItem_Click);
            // 
            // sellerProductToolStripMenuItem
            // 
            this.sellerProductToolStripMenuItem.Name = "sellerProductToolStripMenuItem";
            this.sellerProductToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sellerProductToolStripMenuItem.Text = "SellerProduct";
            this.sellerProductToolStripMenuItem.Click += new System.EventHandler(this.sellerProductToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.ContextMenuStrip = this.contextMenuStrip2;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обрати таблицю";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 586);
            this.Controls.Add(this.button1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productWithReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerProductToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}