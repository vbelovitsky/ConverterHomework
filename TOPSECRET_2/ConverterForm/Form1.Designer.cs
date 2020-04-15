namespace ConverterForm
{
	partial class Form1
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
            this.recordGridView = new System.Windows.Forms.DataGridView();
            this.csvPathButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.csvPathBox = new System.Windows.Forms.TextBox();
            this.setDataButton = new System.Windows.Forms.Button();
            this.convertAllButton = new System.Windows.Forms.Button();
            this.jsonPathButton = new System.Windows.Forms.Button();
            this.jsonPathBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.jsonNameBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pageBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.recordGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // recordGridView
            // 
            this.recordGridView.AllowUserToAddRows = false;
            this.recordGridView.AllowUserToDeleteRows = false;
            this.recordGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.recordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordGridView.Location = new System.Drawing.Point(8, 92);
            this.recordGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recordGridView.MultiSelect = false;
            this.recordGridView.Name = "recordGridView";
            this.recordGridView.ReadOnly = true;
            this.recordGridView.RowTemplate.Height = 28;
            this.recordGridView.Size = new System.Drawing.Size(759, 326);
            this.recordGridView.TabIndex = 0;
            this.recordGridView.VirtualMode = true;
            this.recordGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.recordGridView_DataError);
            // 
            // csvPathButton
            // 
            this.csvPathButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.csvPathButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.csvPathButton.Location = new System.Drawing.Point(8, 8);
            this.csvPathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.csvPathButton.Name = "csvPathButton";
            this.csvPathButton.Size = new System.Drawing.Size(102, 30);
            this.csvPathButton.TabIndex = 1;
            this.csvPathButton.Text = "Выбрать путь";
            this.csvPathButton.UseVisualStyleBackColor = true;
            this.csvPathButton.Click += new System.EventHandler(this.csvPathButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.convertButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.convertButton.Location = new System.Drawing.Point(574, 8);
            this.convertButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(95, 30);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Выгрузить";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.sortButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sortButton.Location = new System.Drawing.Point(304, 8);
            this.sortButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(123, 30);
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Упорядочить";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // csvPathBox
            // 
            this.csvPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csvPathBox.Location = new System.Drawing.Point(87, 44);
            this.csvPathBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.csvPathBox.Name = "csvPathBox";
            this.csvPathBox.ReadOnly = true;
            this.csvPathBox.Size = new System.Drawing.Size(681, 13);
            this.csvPathBox.TabIndex = 4;
            // 
            // setDataButton
            // 
            this.setDataButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.setDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setDataButton.Location = new System.Drawing.Point(114, 8);
            this.setDataButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.setDataButton.Name = "setDataButton";
            this.setDataButton.Size = new System.Drawing.Size(107, 30);
            this.setDataButton.TabIndex = 5;
            this.setDataButton.Text = "Загрузить";
            this.setDataButton.UseVisualStyleBackColor = true;
            this.setDataButton.Click += new System.EventHandler(this.setDataButton_Click);
            // 
            // convertAllButton
            // 
            this.convertAllButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.convertAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.convertAllButton.Location = new System.Drawing.Point(673, 8);
            this.convertAllButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.convertAllButton.Name = "convertAllButton";
            this.convertAllButton.Size = new System.Drawing.Size(95, 30);
            this.convertAllButton.TabIndex = 6;
            this.convertAllButton.Text = "Выгрузить всё";
            this.convertAllButton.UseVisualStyleBackColor = true;
            this.convertAllButton.Click += new System.EventHandler(this.convertAllButton_Click);
            // 
            // jsonPathButton
            // 
            this.jsonPathButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.jsonPathButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jsonPathButton.Location = new System.Drawing.Point(468, 8);
            this.jsonPathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jsonPathButton.Name = "jsonPathButton";
            this.jsonPathButton.Size = new System.Drawing.Size(102, 30);
            this.jsonPathButton.TabIndex = 7;
            this.jsonPathButton.Text = "Выбрать путь";
            this.jsonPathButton.UseVisualStyleBackColor = true;
            this.jsonPathButton.Click += new System.EventHandler(this.jsonPathButton_Click);
            // 
            // jsonPathBox
            // 
            this.jsonPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jsonPathBox.Location = new System.Drawing.Point(87, 60);
            this.jsonPathBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jsonPathBox.Name = "jsonPathBox";
            this.jsonPathBox.ReadOnly = true;
            this.jsonPathBox.Size = new System.Drawing.Size(483, 13);
            this.jsonPathBox.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(8, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 13);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Файл CSV:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(8, 60);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(75, 13);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Файл JSON:";
            // 
            // jsonNameBox
            // 
            this.jsonNameBox.Location = new System.Drawing.Point(574, 58);
            this.jsonNameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jsonNameBox.Name = "jsonNameBox";
            this.jsonNameBox.Size = new System.Drawing.Size(96, 20);
            this.jsonNameBox.TabIndex = 11;
            this.jsonNameBox.Text = "fileData";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(673, 58);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(68, 20);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = ".json";
            // 
            // previousButton
            // 
            this.previousButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.previousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousButton.Location = new System.Drawing.Point(574, 425);
            this.previousButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(95, 31);
            this.previousButton.TabIndex = 13;
            this.previousButton.Text = "Предыдущая";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackgroundImage = global::ConverterForm.Properties.Resources.Change;
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextButton.Location = new System.Drawing.Point(673, 425);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 31);
            this.nextButton.TabIndex = 14;
            this.nextButton.Text = "Следующая";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pageBox
            // 
            this.pageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pageBox.Location = new System.Drawing.Point(506, 434);
            this.pageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageBox.Name = "pageBox";
            this.pageBox.ReadOnly = true;
            this.pageBox.Size = new System.Drawing.Size(52, 13);
            this.pageBox.TabIndex = 15;
            this.pageBox.Text = "-/-";
            this.pageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(775, 461);
            this.Controls.Add(this.pageBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.jsonNameBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.jsonPathBox);
            this.Controls.Add(this.jsonPathButton);
            this.Controls.Add(this.convertAllButton);
            this.Controls.Add(this.setDataButton);
            this.Controls.Add(this.csvPathBox);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.csvPathButton);
            this.Controls.Add(this.recordGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recordGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView recordGridView;
		private System.Windows.Forms.Button csvPathButton;
		private System.Windows.Forms.Button convertButton;
		private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.TextBox csvPathBox;
		private System.Windows.Forms.Button setDataButton;
		private System.Windows.Forms.Button convertAllButton;
		private System.Windows.Forms.Button jsonPathButton;
		private System.Windows.Forms.TextBox jsonPathBox;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox jsonNameBox;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button previousButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.TextBox pageBox;
	}
}

