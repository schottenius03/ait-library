namespace View
{
    partial class FormReports
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
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.buttonBooksAvailable = new System.Windows.Forms.Button();
            this.buttonBooksBorrowed = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(340, 18);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(127, 36);
            this.lblDashboard.TabIndex = 28;
            this.lblDashboard.Text = "Reports";
            this.lblDashboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(718, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(74, 30);
            this.btnBack.TabIndex = 27;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // buttonBooksAvailable
            // 
            this.buttonBooksAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBooksAvailable.Location = new System.Drawing.Point(67, 70);
            this.buttonBooksAvailable.Name = "buttonBooksAvailable";
            this.buttonBooksAvailable.Size = new System.Drawing.Size(169, 44);
            this.buttonBooksAvailable.TabIndex = 29;
            this.buttonBooksAvailable.Text = "Books available";
            this.buttonBooksAvailable.UseVisualStyleBackColor = true;
            this.buttonBooksAvailable.Click += new System.EventHandler(this.buttonBooksAvailable_Click);
            // 
            // buttonBooksBorrowed
            // 
            this.buttonBooksBorrowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBooksBorrowed.Location = new System.Drawing.Point(543, 70);
            this.buttonBooksBorrowed.Name = "buttonBooksBorrowed";
            this.buttonBooksBorrowed.Size = new System.Drawing.Size(197, 44);
            this.buttonBooksBorrowed.TabIndex = 30;
            this.buttonBooksBorrowed.Text = "Books borrowed";
            this.buttonBooksBorrowed.UseVisualStyleBackColor = true;
            this.buttonBooksBorrowed.Click += new System.EventHandler(this.buttonBooksBorrowed_Click);
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 143);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.Size = new System.Drawing.Size(776, 295);
            this.dataGridViewBooks.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(307, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 44);
            this.button1.TabIndex = 32;
            this.button1.Text = "Books reserved";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.buttonBooksBorrowed);
            this.Controls.Add(this.buttonBooksAvailable);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.btnBack);
            this.Name = "FormReports";
            this.Text = "FormReports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button buttonBooksAvailable;
        private System.Windows.Forms.Button buttonBooksBorrowed;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button button1;
    }
}