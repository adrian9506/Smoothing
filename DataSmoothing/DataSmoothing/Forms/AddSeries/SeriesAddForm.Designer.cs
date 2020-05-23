namespace DataSmoothing.Forms.AddSeries
{
    partial class SeriesAddForm
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
            this.openButton = new System.Windows.Forms.Button();
            this.AverageCheckBox = new System.Windows.Forms.CheckBox();
            this.pathListView = new System.Windows.Forms.ListView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.delimiterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Otwórz plik";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // AverageCheckBox
            // 
            this.AverageCheckBox.AutoSize = true;
            this.AverageCheckBox.Location = new System.Drawing.Point(104, 16);
            this.AverageCheckBox.Name = "AverageCheckBox";
            this.AverageCheckBox.Size = new System.Drawing.Size(91, 17);
            this.AverageCheckBox.TabIndex = 2;
            this.AverageCheckBox.Text = "Uśrednij dane";
            this.AverageCheckBox.UseVisualStyleBackColor = true;
            this.AverageCheckBox.CheckedChanged += new System.EventHandler(this.AverageCheckBox_CheckedChanged);
            // 
            // pathListView
            // 
            this.pathListView.HideSelection = false;
            this.pathListView.Location = new System.Drawing.Point(12, 41);
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(223, 397);
            this.pathListView.TabIndex = 3;
            this.pathListView.UseCompatibleStateImageBehavior = false;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(241, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(426, 397);
            this.dataGridView.TabIndex = 4;
            // 
            // delimiterComboBox
            // 
            this.delimiterComboBox.FormattingEnabled = true;
            this.delimiterComboBox.Location = new System.Drawing.Point(285, 14);
            this.delimiterComboBox.Name = "delimiterComboBox";
            this.delimiterComboBox.Size = new System.Drawing.Size(76, 21);
            this.delimiterComboBox.TabIndex = 5;
            this.delimiterComboBox.SelectedIndexChanged += new System.EventHandler(this.delimiterComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Separator";
            // 
            // varListView
            // 
            this.varListView.HideSelection = false;
            this.varListView.Location = new System.Drawing.Point(673, 41);
            this.varListView.Name = "varListView";
            this.varListView.Size = new System.Drawing.Size(223, 397);
            this.varListView.TabIndex = 7;
            this.varListView.UseCompatibleStateImageBehavior = false;
            // 
            // SeriesAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 439);
            this.Controls.Add(this.varListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delimiterComboBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.AverageCheckBox);
            this.Controls.Add(this.openButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeriesAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj nową serię";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.CheckBox AverageCheckBox;
        private System.Windows.Forms.ListView pathListView;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox delimiterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView varListView;
    }
}