using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CsvToJsonLibrary;

namespace ConverterForm
{
	public partial class Form1 : Form
	{
		List<FileRecord> records;
		DataTable table;

		string csvPath = FileConstants.DEFAULT_FILE_NAME;

		string jsonDefaultPath = FileConstants.JSON_FILE_NAME;
		string jsonPathRoot = FileConstants.JSON_ROOT_NAME;
		string jsonFileName = FileConstants.JSON_FILE_NAME;

		const int ITEMS_PER_PAGE = 30;
		int CURRENT_PAGE = 0;
		int MAX_PAGE = 0;

		List<FileRecord> CURRENT_DATA;


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadDesign();
		}

		private void csvPathButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog
			{
				Multiselect = false,
				InitialDirectory = $@"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}{Environment.CurrentDirectory}",
				Filter = "Файлы типа csv|*csv",
				FilterIndex = 0,
				RestoreDirectory = true
			};
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				csvPath = OFD.FileName;
				csvPathBox.Text = csvPath;
			}
		}

		private void jsonPathButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog FBD = new FolderBrowserDialog {
				RootFolder = Environment.SpecialFolder.MyComputer
			};
			if (FBD.ShowDialog() == DialogResult.OK)
			{
				jsonPathRoot = FBD.SelectedPath;
				jsonPathBox.Text = jsonPathRoot;
			}

		}

		private void setDataButton_Click(object sender, EventArgs e)
		{
			CSVReader reader = new CSVReader(csvPath);
			reader.onError += ErrorHandler;

			records = reader.Read();
			if(records == null)
			{
				return;
			}

			int remainder;
			MAX_PAGE = Math.DivRem(records.Count, ITEMS_PER_PAGE, out remainder) + (remainder == 0 ? 0 : 1);
			MAX_PAGE--;
			UpdatePageText();

			CURRENT_DATA = records.GetRange(CURRENT_PAGE, ITEMS_PER_PAGE);
			FillGridView(CURRENT_DATA);
			// Альтернативное решение: FillWithBindingList();
		}

		private void convertButton_Click(object sender, EventArgs e)
		{
			WriteToJson(CURRENT_DATA);
		}

		private void convertAllButton_Click(object sender, EventArgs e)
		{
			WriteToJson(records);
		}

		private void sortButton_Click(object sender, EventArgs e)
		{

		}

		private void recordGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
		{
			MessageBox.Show($"Недопустимое значение в ячейке [{anError.RowIndex + 1}, {anError.ColumnIndex + 1}].");
		}

		private void ErrorHandler(string message)
		{
			MessageBox.Show(message);
		}

		private void FillGridView(List<FileRecord> recordsToDisplay)
		{
			table = new DataTable();
			string[] columnNames = FileConstants.DEFAULT_COLUMNS_NAMES.Split(FileConstants.DELIMETER);
			for(int i = 0; i < FileConstants.COLUMNS_NUMBER; i++)
			{
				table.Columns.Add(columnNames[i], i == 0 || i == 5 || i == 9 ? typeof(uint) : typeof(string));
			}

			for(int i = 0; i < recordsToDisplay.Count; i++)
			{
				FileRecord r = recordsToDisplay[i];
				table.Rows.Add(r.Id, r.Url, r.Title, r.Category, r.Date, r.Views, r.ImageUrl, r.PostText, r.AdditionalInfo, r.CommentsQuantity);
			}

			recordGridView.DataSource = table;
		}

		private void FillWithBindingList()
		{
			BindingList<FileRecord> dataSource= new BindingList<FileRecord>();
			recordGridView.DataSource = dataSource;
			foreach (FileRecord record in records)
			{
				dataSource.Add(record);
			}
		}

		private void WriteToJson(List<FileRecord> recordsToWrite)
		{
			string name = jsonNameBox.Text;
			if (name.Length != 0 && !new Regex($"[{Regex.Escape(string.Join("", Path.GetInvalidFileNameChars()))}]").IsMatch(name))
			{
				if (recordsToWrite != null)
				{
					JsonWriter writer = new JsonWriter($"{jsonPathRoot}{Path.DirectorySeparatorChar}{name}.json");
					writer.WriteToJson(records);
				}
				else
				{
					ErrorHandler("Отсутствуют данные для записи");
				}
			}
			else
			{
				ErrorHandler("Недопустимое название файла");
			}
		}

		private void LoadDesign()
		{
			csvPathBox.Text = csvPath;
			jsonPathBox.Text = jsonPathRoot;
			jsonNameBox.Text = jsonFileName;
		}

		private void UpdatePageText()
		{
			pageBox.Text = $"{CURRENT_PAGE + 1}/{MAX_PAGE + 1}";
		}

		private void previousButton_Click(object sender, EventArgs e)
		{
			if(CURRENT_PAGE > 0)
			{
				CURRENT_DATA = records.GetRange(ITEMS_PER_PAGE * (CURRENT_PAGE - 1), ITEMS_PER_PAGE);
				FillGridView(CURRENT_DATA);

				CURRENT_PAGE--;
				UpdatePageText();
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			if (CURRENT_PAGE < MAX_PAGE)
			{
				int itemCount = ITEMS_PER_PAGE * (CURRENT_PAGE + 1) + ITEMS_PER_PAGE - 1 <= records.Count ?
					ITEMS_PER_PAGE : records.Count - ITEMS_PER_PAGE * (CURRENT_PAGE + 1);

				CURRENT_DATA = records.GetRange(ITEMS_PER_PAGE * (CURRENT_PAGE + 1), itemCount);
				FillGridView(CURRENT_DATA);

				CURRENT_PAGE++;
				UpdatePageText();
			}
		}
	}
}
