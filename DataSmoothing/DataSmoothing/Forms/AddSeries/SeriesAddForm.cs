using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSmoothing.Forms.AddSeries
{
    public partial class SeriesAddForm : Form
    {
        private List<string> _filePath;
        private DataTable _dataFiles;
        public SeriesAddForm()
        {
            InitializeComponent();
            this._filePath = new List<string>();
            this._dataFiles = new DataTable();
            this.pathListView.View = View.List;
            this.varListView.View = View.List;
            this.delimiterComboBox.Items.Add(".");
            this.delimiterComboBox.Items.Add(",");
            this.delimiterComboBox.Items.Add(";");
            this.dataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
            this.dataGridView.CellMouseClick += DataGridView_CellMouseClick;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.delimiterComboBox.SelectedIndex = 1;
        }

        /// <summary>
        /// Kliknięcie na komórkę tabeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cellMenu = new ContextMenuStrip();
                int position = e.RowIndex;

                if (position >= 0)
                {
                    cellMenu.Items.Add("Ustaw jako nazwy kolumn").Name = "CollName";
                    cellMenu.Items["CollName"].Tag = e.RowIndex;
                    cellMenu.Items.Add("Usuń wiersz").Name = "RemRow";
                    cellMenu.Items["RemRow"].Tag = e.RowIndex;
                }

                cellMenu.ItemClicked += CellMenu_ItemClicked;
                cellMenu.Show(this.dataGridView, new Point(e.X, e.Y));
            }
        }

        private void CellMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "CollName":
                    this.NameVariable(Convert.ToInt32(e.ClickedItem.Tag.ToString()), this._dataFiles.Rows[Convert.ToInt32(e.ClickedItem.Tag.ToString())]);
                    break;
                case "RemRow":
                    this.dataGridView.Rows.RemoveAt(Convert.ToInt32(e.ClickedItem.Tag.ToString()));
                    break;
            }
        }

        /// <summary>
        /// Kliknięcie na nagłówek tabeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int positionColumn = this.dataGridView.HitTest(e.X, e.Y).ColumnIndex;

                if (positionColumn >= 0)
                {
                    menu.Items.Add("Nazwij zmienną").Name = "NameVar";
                    menu.Items["NameVar"].Tag = e.ColumnIndex;
                    menu.Items.Add("Dodaj do zmiennych").Name = "AddVar";
                    menu.Items["AddVar"].Tag = e.ColumnIndex;
                    menu.Items.Add("Usuń kolumnę").Name = "RemColl";
                    menu.Items["RemColl"].Tag = e.ColumnIndex;
                }

                menu.Show(this.dataGridView, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        /// <summary>
        /// Menu kontekstowe dla kolumn tabeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "NameVar":
                    this.NameVariable(Convert.ToInt32(e.ClickedItem.Tag.ToString()));
                    break;
                case "AddVar":
                    this.AddVar(this._dataFiles.Columns[Convert.ToInt32(e.ClickedItem.Tag.ToString())].ColumnName);
                    break;
                case "RemColl":
                    foreach (ListViewItem item in this.varListView.Items)
                    {
                        if (item.Text == this._dataFiles.Columns[Convert.ToInt32(e.ClickedItem.Tag.ToString())].ColumnName)
                        {
                            this.varListView.Items.Remove(item);
                        }
                    }

                    this._dataFiles.Columns.RemoveAt(Convert.ToInt32(e.ClickedItem.Tag.ToString()));
                    break;
            }
        }

        /// <summary>
        /// Nazywanie zmiennych.kolumn
        /// </summary>
        /// <param name="columnIndex">Index kolumny</param>
        /// <param name="variableName">Nazwa zmiennej</param>
        private void NameVariable(int columnIndex = -1, string variableName = "", DataRow row = null)
        {
            if (columnIndex > -1 || variableName != "")
            {
                ColumnNameEditor columnNameEditor = new ColumnNameEditor("Nadaj nazwę kolumnie");
                columnNameEditor.ShowDialog();
                
                foreach (ListViewItem item in this.varListView.Items)
                {
                    if (item.Text == this._dataFiles.Columns[columnIndex].ColumnName)
                    {
                        this.varListView.Items[this.varListView.Items.IndexOf(item)].Text = columnNameEditor.GetName;
                        this._dataFiles.Columns[columnIndex].ColumnName = columnNameEditor.GetName;
                        break;
                    }
                }
            }

            if (row != null)
            {
                foreach (ListViewItem item in this.varListView.Items)
                {
                    for (int i = 0; i < this.dataGridView.Columns.Count; i++)
                    {
                        if (item.Text == this._dataFiles.Columns[i].ColumnName)
                        {
                            this.varListView.Items[this.varListView.Items.IndexOf(item)].Text = row[i].ToString();
                            this._dataFiles.Columns[columnIndex].ColumnName = row[i].ToString();
                            break;
                        }
                    }
                }
            }
        }

        private void NameVariable(int rowIndex, DataRow row)
        {
            if (row != null)
            {
                string[] _names = new string[this._dataFiles.Columns.Count];

                for (int i = 0; i < this._dataFiles.Columns.Count; i++)
                {
                    _names[i] = row[i].ToString();
                }

                this._dataFiles.Rows.RemoveAt(rowIndex);
                foreach (ListViewItem item in this.varListView.Items)
                {
                    for (int i = 0; i < this.dataGridView.Columns.Count; i++)
                    {
                        if (item.Text == this._dataFiles.Columns[i].ColumnName)
                        {
                            this.varListView.Items[this.varListView.Items.IndexOf(item)].Text = _names[i];
                            break;
                        }
                    }
                }

                for (int i = 0; i < this.dataGridView.Columns.Count; i++)
                {
                    try
                    {
                        this._dataFiles.Columns[i].ColumnName = _names[i];
                    }
                    catch (Exception e)
                    {
                        this._dataFiles.Columns[i].ColumnName = _names[i] + "2";
                    }
                }
            }
        }

        /// <summary>
        /// Dodaj zmienną do listy
        /// </summary>
        /// <param name="tag">Nazwa kolumny</param>
        private void AddVar(string tag)
        {
            bool f = false;

            foreach (ListViewItem item in this.varListView.Items)
            {
                if (item.Text == tag)
                {
                    f = true;
                    break;
                }
            }

            if (!f)
            {
                this.varListView.Items.Add(new ListViewItem(tag));
            }
        }

        /// <summary>
        /// Wczytanie pliku z danymi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|csv files (*csv)|*.csv|xlsx files (*xlsx)|*.xlsx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (this._filePath.Count == 0 || this._filePath.Equals(openFileDialog.FileName))
                    {
                        this._filePath.Add(openFileDialog.FileName);

                        if (!this.AverageCheckBox.Checked)
                        {
                            this.openButton.Enabled = false;
                        }

                        this.pathListView.Items.Clear();
                        foreach (string s in _filePath)
                        {
                            this.pathListView.Items.Add(new ListViewItem(s));
                        }

                        this._dataFiles.Clear();
                        this._dataFiles.Columns.Clear();
                        this.PrepareData(this._filePath.Last());
                    }
                }
            }
        }

        /// <summary>
        /// Przygotowanie datagrid dla wczytanych danych
        /// </summary>
        /// <param name="_path"></param>
        private void PrepareData(string _path)
        {
            try
            {
                if (this.delimiterComboBox.SelectedIndex > -1)
                {
                    if (_path.Split('.').Last().Contains("csv") || _path.Split('.').Last().Contains("txt"))
                    {
                        using (FileStream fs = new FileStream(_path, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                var _firstLine = sr.ReadLine().Split(Convert.ToChar(this.delimiterComboBox.SelectedItem.ToString()));

                                for (int i = 0; i < _firstLine.Count(); i++)
                                {
                                    this._dataFiles.Columns.Add(_firstLine[i].ToString());

                                    if (this._dataFiles.Columns[_firstLine[i].ToString()] != null)
                                    {
                                        this._dataFiles.Columns[_firstLine[i].ToString()].ReadOnly = true;
                                    }
                                }

                                if (this._dataFiles.Columns.Count <= 4)
                                {
                                    this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                }

                                while (!sr.EndOfStream)
                                {
                                    var _line = sr.ReadLine().Split(Convert.ToChar(this.delimiterComboBox.SelectedItem.ToString()));
                                    DataRow row = this._dataFiles.NewRow();

                                    for (int i = 0; i < _line.Count(); i++)
                                    {
                                        row[i] = _line[i];
                                    }
                                    this._dataFiles.Rows.Add(row);
                                }
                            }
                        }

                        this.dataGridView.DataSource = this._dataFiles;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wybrany separator jest niepoprawnym wybierz inny", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Czy liczyć średnią
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AverageCheckBox.Checked)
            {
                this.openButton.Enabled = true;
            }
        }

        /// <summary>
        /// Wybór separatora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delimiterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_filePath.Count > 0)
            {
                this._dataFiles.Clear();
                this._dataFiles.Columns.Clear();
                this.PrepareData(this._filePath.Last());
            }
        }
    }
}
