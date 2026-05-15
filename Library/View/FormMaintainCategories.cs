using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormMaintainCategories : Form
    {
        public FormMaintainCategories()
        {
            InitializeComponent();
            dataGridViewCategories.CellClick += dataGridViewCategories_CellClick;
        }

        private void FormMaintainCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoryController categoryController = new CategoryController();
            List<CategoryDTO> listOfCategories = categoryController.GetAllCategories();
            dataGridViewCategories.DataSource = listOfCategories;
        }

        private void dataGridViewCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCategories.Rows[e.RowIndex];

                textBoxCategoryID.Text = row.Cells["CategoryID"].Value?.ToString() ?? "";
                textBoxCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
            }
        }

        private void RefreshGrid()
        {
            LoadCategories();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string categoryName = textBoxCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Type a valid name.");
                return;
            }

            CategoryController categoryController = new CategoryController();
            int iStatus = categoryController.AddCategory(categoryName);

            MessageBox.Show(iStatus == -1 ? "Error, failed to add category." : "Category added successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxCategoryID.Clear();
            textBoxCategoryName.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxCategoryID.Text, out int categoryId) ||
                string.IsNullOrWhiteSpace(textBoxCategoryName.Text))
            {
                MessageBox.Show("Category ID must be a number and name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoryName = textBoxCategoryName.Text.Trim();

            CategoryController categoryController = new CategoryController();
            int iStatus = categoryController.UpdateCategory(categoryName, categoryId);

            MessageBox.Show(iStatus == -1 ? "Error, failed to update category." : "Category updated successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxCategoryID.Clear();
            textBoxCategoryName.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string categoryName = textBoxCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Type a valid name.");
                return;
            }

            CategoryController categoryController = new CategoryController();
            int iStatus = categoryController.DeleteCategory(categoryName);

            MessageBox.Show(iStatus == -1 ? "Error, failed to delete category." : "Category deleted successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxCategoryID.Clear();
            textBoxCategoryName.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintain formMaintain = new FormMaintain();
            formMaintain.ShowDialog();
        }
    }
}
