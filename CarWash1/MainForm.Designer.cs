namespace CarWash1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSales = new System.Windows.Forms.Button();
            this.btStaff = new System.Windows.Forms.Button();
            this.btDrink = new System.Windows.Forms.Button();
            this.btExpense = new System.Windows.Forms.Button();
            this.btIncome = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            this.labelStaff = new System.Windows.Forms.Label();
            this.btNewUser = new System.Windows.Forms.Button();
            this.pictureBoxCreateUser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCreateUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CarWash1.Properties.Resources.CarWash;
            this.pictureBox1.Location = new System.Drawing.Point(404, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btSales
            // 
            this.btSales.BackColor = System.Drawing.Color.Transparent;
            this.btSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSales.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSales.ForeColor = System.Drawing.Color.Red;
            this.btSales.Location = new System.Drawing.Point(91, 402);
            this.btSales.Name = "btSales";
            this.btSales.Size = new System.Drawing.Size(147, 38);
            this.btSales.TabIndex = 1;
            this.btSales.Text = "Sales";
            this.btSales.UseVisualStyleBackColor = false;
            this.btSales.Click += new System.EventHandler(this.btSales_Click);
            // 
            // btStaff
            // 
            this.btStaff.BackColor = System.Drawing.Color.Transparent;
            this.btStaff.Enabled = false;
            this.btStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStaff.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStaff.ForeColor = System.Drawing.Color.Red;
            this.btStaff.Location = new System.Drawing.Point(266, 402);
            this.btStaff.Name = "btStaff";
            this.btStaff.Size = new System.Drawing.Size(147, 38);
            this.btStaff.TabIndex = 2;
            this.btStaff.Text = "Staff";
            this.btStaff.UseVisualStyleBackColor = false;
            this.btStaff.Click += new System.EventHandler(this.btStaff_Click);
            // 
            // btDrink
            // 
            this.btDrink.BackColor = System.Drawing.Color.Transparent;
            this.btDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDrink.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDrink.ForeColor = System.Drawing.Color.Red;
            this.btDrink.Location = new System.Drawing.Point(440, 402);
            this.btDrink.Name = "btDrink";
            this.btDrink.Size = new System.Drawing.Size(147, 38);
            this.btDrink.TabIndex = 3;
            this.btDrink.Text = "Drink";
            this.btDrink.UseVisualStyleBackColor = false;
            this.btDrink.Click += new System.EventHandler(this.btDrink_Click);
            // 
            // btExpense
            // 
            this.btExpense.BackColor = System.Drawing.Color.Transparent;
            this.btExpense.Enabled = false;
            this.btExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExpense.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExpense.ForeColor = System.Drawing.Color.Red;
            this.btExpense.Location = new System.Drawing.Point(618, 402);
            this.btExpense.Name = "btExpense";
            this.btExpense.Size = new System.Drawing.Size(147, 38);
            this.btExpense.TabIndex = 4;
            this.btExpense.Text = "Expense ";
            this.btExpense.UseVisualStyleBackColor = false;
            this.btExpense.Click += new System.EventHandler(this.btExpense_Click);
            // 
            // btIncome
            // 
            this.btIncome.BackColor = System.Drawing.Color.Transparent;
            this.btIncome.Enabled = false;
            this.btIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIncome.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIncome.ForeColor = System.Drawing.Color.Red;
            this.btIncome.Location = new System.Drawing.Point(793, 402);
            this.btIncome.Name = "btIncome";
            this.btIncome.Size = new System.Drawing.Size(147, 38);
            this.btIncome.TabIndex = 5;
            this.btIncome.Text = "Income";
            this.btIncome.UseVisualStyleBackColor = false;
            this.btIncome.Click += new System.EventHandler(this.btIncome_Click);
            // 
            // btLogout
            // 
            this.btLogout.BackColor = System.Drawing.Color.Transparent;
            this.btLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLogout.BackgroundImage")));
            this.btLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.Location = new System.Drawing.Point(937, 12);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(55, 37);
            this.btLogout.TabIndex = 20;
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // labelStaff
            // 
            this.labelStaff.AutoSize = true;
            this.labelStaff.BackColor = System.Drawing.Color.Transparent;
            this.labelStaff.ForeColor = System.Drawing.Color.Red;
            this.labelStaff.Location = new System.Drawing.Point(49, 12);
            this.labelStaff.Name = "labelStaff";
            this.labelStaff.Size = new System.Drawing.Size(76, 29);
            this.labelStaff.TabIndex = 21;
            this.labelStaff.Text = "User :";
            // 
            // btNewUser
            // 
            this.btNewUser.BackColor = System.Drawing.Color.Red;
            this.btNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewUser.ForeColor = System.Drawing.Color.White;
            this.btNewUser.Location = new System.Drawing.Point(841, 501);
            this.btNewUser.Name = "btNewUser";
            this.btNewUser.Size = new System.Drawing.Size(161, 40);
            this.btNewUser.TabIndex = 23;
            this.btNewUser.Text = "Create New User";
            this.btNewUser.UseVisualStyleBackColor = false;
            this.btNewUser.Visible = false;
            this.btNewUser.Click += new System.EventHandler(this.btNewUser_Click);
            // 
            // pictureBoxCreateUser
            // 
            this.pictureBoxCreateUser.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCreateUser.Image = global::CarWash1.Properties.Resources.Shape_03;
            this.pictureBoxCreateUser.Location = new System.Drawing.Point(762, 463);
            this.pictureBoxCreateUser.Name = "pictureBoxCreateUser";
            this.pictureBoxCreateUser.Size = new System.Drawing.Size(245, 111);
            this.pictureBoxCreateUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCreateUser.TabIndex = 22;
            this.pictureBoxCreateUser.TabStop = false;
            this.pictureBoxCreateUser.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1004, 552);
            this.Controls.Add(this.btNewUser);
            this.Controls.Add(this.pictureBoxCreateUser);
            this.Controls.Add(this.labelStaff);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.btIncome);
            this.Controls.Add(this.btExpense);
            this.Controls.Add(this.btDrink);
            this.Controls.Add(this.btStaff);
            this.Controls.Add(this.btSales);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCreateUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btSales;
        private System.Windows.Forms.Button btStaff;
        private System.Windows.Forms.Button btDrink;
        private System.Windows.Forms.Button btExpense;
        private System.Windows.Forms.Button btIncome;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Label labelStaff;
        private System.Windows.Forms.Button btNewUser;
        private System.Windows.Forms.PictureBox pictureBoxCreateUser;
    }
}