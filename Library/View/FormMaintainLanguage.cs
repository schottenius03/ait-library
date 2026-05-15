using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormMaintainLanguage : Form
    {
        public FormMaintainLanguage()
        {
            InitializeComponent();
            dataGridViewLanguages.CellClick += dataGridViewLanguages_CellClick;
        }

        private void FormMaintainLanguage_Load(object sender, EventArgs e)
        {
            LoadLanguages();
        }

        private void LoadLanguages()
        {
            LanguageController languageController = new LanguageController();
            List<LanguageDTO> languages = languageController.GetAllLanguages();
            dataGridViewLanguages.DataSource = languages;
        }

        private void RefreshGrid()
        {
            LoadLanguages();
        }

        private void dataGridViewLanguages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewLanguages.Rows[e.RowIndex];

                // ✅ FIX: Use correct column names as returned by your dataset
                textBoxLanguageID.Text = row.Cells["LanguageID"].Value?.ToString() ?? "";
                textBoxLanguageName.Text = row.Cells["LanguageName"].Value?.ToString() ?? "";
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string languageName = textBoxLanguageName.Text.Trim();

            if (string.IsNullOrWhiteSpace(languageName))
            {
                MessageBox.Show("Please type a valid name.");
                return;
            }

            LanguageController languageController = new LanguageController();
            int iStatus = languageController.AddLanguage(languageName);

            MessageBox.Show(iStatus == -1 ? "Error, failed to add language." : "Language added successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxLanguageID.Clear();
            textBoxLanguageName.Clear();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxLanguageID.Text, out int languageId) ||
                string.IsNullOrWhiteSpace(textBoxLanguageName.Text))
            {
                MessageBox.Show("Language ID must be a valid number and name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string languageName = textBoxLanguageName.Text.Trim();

            LanguageController languageController = new LanguageController();
            int iStatus = languageController.UpdateLanguage(languageName, languageId);

            MessageBox.Show(iStatus == -1 ? "Error, failed to update language." : "Language updated successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxLanguageID.Clear();
            textBoxLanguageName.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxLanguageID.Text, out int languageId) ||
                string.IsNullOrWhiteSpace(textBoxLanguageName.Text))
            {
                MessageBox.Show("Both Language ID and Name must be valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string languageName = textBoxLanguageName.Text.Trim();

            LanguageController languageController = new LanguageController();
            int iStatus = languageController.DeleteLanguage(languageId, languageName);

            MessageBox.Show(iStatus == -1 ? "Error, failed to delete language." : "Language deleted successfully.");
            RefreshGrid();

            // clear textboxes
            textBoxLanguageID.Clear();
            textBoxLanguageName.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintain formMaintain = new FormMaintain();
            formMaintain.ShowDialog();
        }

        private void textBoxLanguageName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
