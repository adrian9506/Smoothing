using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSmoothing.Forms.AddSeries
{
    public partial class ColumnNameEditor : Form
    {
        public ColumnNameEditor(string windowTitle)
        {
            InitializeComponent();
            this.Text = windowTitle;
        }

        /// <summary>
        /// Pobiera wprowadzoną nazwę
        /// </summary>
        public string GetName
        {
            get
            {
                return this.nameTextBox.Text;
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
