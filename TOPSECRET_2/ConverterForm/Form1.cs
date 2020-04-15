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
		/// <summary>
		/// Загруженные данные
		/// </summary>
		List<FileRecord> records;

		string csvPath = FileConstants.DEFAULT_FILE_NAME;

		string jsonDefaultPath = FileConstants.JSON_FILE_NAME;
		string jsonPathRoot = FileConstants.JSON_ROOT_NAME;
		string jsonFileName = FileConstants.JSON_FILE_NAME;

		const int ITEMS_PER_PAGE = 30;
		int CURRENT_PAGE = 0;
		int MAX_PAGE = 0;

		/// <summary>
		/// Текущие отображаемые данные
		/// </summary>
		List<FileRecord> CURRENT_DATA;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadDesign();
		}

		/// <summary>
		/// Предлагает указать путь до CSV-файла
		/// </summary>
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

		/// <summary>
		/// Предлагает указать папку для JSON-файла
		/// </summary>
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

		/// <summary>
		/// Загружает данные в DataGridView
		/// </summary>
		private void setDataButton_Click(object sender, EventArgs e)
		{
			CSVReader reader = new CSVReader(csvPath);
			reader.onError += ErrorHandler;

			records = reader.Read();
			if(records == null)
			{
				return;
			}

			MAX_PAGE = Math.DivRem(records.Count, ITEMS_PER_PAGE, out int remainder) + (remainder == 0 ? 0 : 1);
			MAX_PAGE--;
			UpdatePageText();

			int itemCount = Math.Min(ITEMS_PER_PAGE, records.Count);
			CURRENT_DATA = records.GetRange(0, itemCount);
			FillGridView(CURRENT_DATA);
			// Альтернативное решение: FillWithBindingList();
		}

		/// <summary>
		/// Записывает отображаемые данные в файл
		/// </summary>
		private void convertButton_Click(object sender, EventArgs e)
		{
			WriteToJson(CURRENT_DATA);
		}

		/// <summary>
		/// Записывает все выгруженные данные в файл
		/// </summary>
		private void convertAllButton_Click(object sender, EventArgs e)
		{
			WriteToJson(records);
		}

		/// <summary>
		/// Сортирует таблицу по убыванию по выделенной клетке (т.е. колонке)
		/// </summary>
		private void sortButton_Click(object sender, EventArgs e)
		{
			if (records != null && recordGridView.SelectedCells.Count != 0)
			{
				DataTable dt = recordGridView.DataSource as DataTable;
				dt.DefaultView.Sort = $"{recordGridView.Columns[recordGridView.SelectedCells[0].ColumnIndex].Name} desc";
				dt = dt.DefaultView.ToTable();
				recordGridView.DataSource = dt;
			}
		}

		private void recordGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
		{
			MessageBox.Show($"Недопустимое значение в ячейке [{anError.RowIndex + 1}, {anError.ColumnIndex + 1}].");
		}

		/// <summary>
		/// Обработчик ошибки чтения/записи
		/// </summary>
		private void ErrorHandler(string message)
		{
			MessageBox.Show(message,
				"Ошибка",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

		/// <summary>
		/// Заполняет данными DataGridView с помощью DataTable
		/// </summary>
		private void FillGridView(List<FileRecord> recordsToDisplay)
		{
			DataTable table = new DataTable();
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

		/// <summary>
		/// Заполняет данными DataGridView с помощью BindingList (альтернатива, не используется)
		/// </summary>
		private void FillWithBindingList()
		{
			BindingList<FileRecord> dataSource= new BindingList<FileRecord>();
			recordGridView.DataSource = dataSource;
			foreach (FileRecord record in records)
			{
				dataSource.Add(record);
			}
		}

		/// <summary>
		/// Записывает данные в JSON файл
		/// </summary>
		private void WriteToJson(List<FileRecord> recordsToWrite)
		{
			string name = jsonNameBox.Text;
			if (name.Length != 0 && !new Regex($"[{Regex.Escape(string.Join("", Path.GetInvalidFileNameChars()))}]").IsMatch(name))
			{
				if (recordsToWrite != null)
				{
					JsonWriter writer = new JsonWriter($"{jsonPathRoot}{Path.DirectorySeparatorChar}{name}.json");
					writer.onError += ErrorHandler;
					writer.WriteToJson(recordsToWrite);
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

		/// <summary>
		/// Устанавливает текст в элементы интерфейса
		/// </summary>
		private void LoadDesign()
		{
			csvPathBox.Text = csvPath;
			jsonPathBox.Text = jsonPathRoot;
			jsonNameBox.Text = jsonFileName;
		}

		/// <summary>
		/// Обновляет номер страницы
		/// </summary>
		private void UpdatePageText()
		{
			pageBox.Text = $"{CURRENT_PAGE + 1}/{MAX_PAGE + 1}";
		}

		/// <summary>
		/// Переходит на предыдущую страницу
		/// </summary>
		private void previousButton_Click(object sender, EventArgs e)
		{
			if(CURRENT_PAGE > 0)
			{
				--CURRENT_PAGE;
				CURRENT_DATA = records.GetRange(ITEMS_PER_PAGE * CURRENT_PAGE, ITEMS_PER_PAGE);
				FillGridView(CURRENT_DATA);
				
				UpdatePageText();
			}
		}

		/// <summary>
		/// Переходит на следующую страницу
		/// </summary>
		private void nextButton_Click(object sender, EventArgs e)
		{
			if (CURRENT_PAGE < MAX_PAGE)
			{
				++CURRENT_PAGE;
				int itemCount = Math.Min(ITEMS_PER_PAGE, records.Count - ITEMS_PER_PAGE * CURRENT_PAGE);

				CURRENT_DATA = records.GetRange(ITEMS_PER_PAGE * CURRENT_PAGE, itemCount);
				FillGridView(CURRENT_DATA);

				UpdatePageText();
			}
		}
	}
}
