using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToJsonLibrary
{

	public delegate void Error(string message);

	/// <summary>
	/// Класс для чтения CSV-файла
	/// </summary>
	public class CSVReader
	{

		public string FilePath { get; private set; } = FileConstants.DEFAULT_FILE_NAME;

		public event Error onError;

		public CSVReader() { }

		public CSVReader(string filePath)
		{
			FilePath = filePath;
		}

		public List<FileRecord> Read()
		{
			List<FileRecord> records = new List<FileRecord>();
			try
			{
				using (StreamReader reader = new StreamReader(FilePath, Encoding.Default))
				{

					string names = reader.ReadLine();
					
					if (string.IsNullOrEmpty(names) || names != FileConstants.DEFAULT_COLUMNS_NAMES)
					{
						throw new ArgumentException("Неверные названия столбцов.");
					}

					while (!reader.EndOfStream)
					{
						string line = ReadRecordString(reader);

						FileRecord record;
						if (!Validate(line, out record))
						{
							throw new ArgumentException("Неверные данные в столбцах.");
						}
						records.Add(record);
					}
				}
				return records;
			}
			catch (IOException e)
			{
				onError?.Invoke(e.Message);
			}
			catch(UnauthorizedAccessException e)
			{
				onError?.Invoke(e.Message);
			}
			catch (ArgumentException e)
			{
				onError?.Invoke(e.Message);
			}
			catch (Exception e)
			{
				onError?.Invoke(e.Message);
			}
			return null;
		}

		/// <summary>
		/// Считывает один объект из файла. Не зависит от того, на скольких строках расположен объект
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private string ReadRecordString(StreamReader reader)
		{
			int counter = 0;
			StringBuilder lineBuilder = new StringBuilder();
			while (counter < FileConstants.COLUMNS_NUMBER - 1)
			{
				string temp = reader.ReadLine();
				counter += Array.FindAll(temp.ToArray(), x => x == FileConstants.DELIMETER).Length;

				lineBuilder.Append(temp);
			}

			return lineBuilder.ToString().Replace("    ", "");
		}

		/// <summary>
		/// Валидирует строку с данными об объекте
		/// </summary>
		/// <param name="line"></param>
		/// <param name="record"></param>
		/// <returns></returns>
		private bool Validate(string line, out FileRecord record)
		{
			record = null;
			string[] values = line.Split(FileConstants.DELIMETER);
			if (values.Length != FileConstants.COLUMNS_NUMBER)
			{
				return false;
			}

			bool checkInts = uint.TryParse(values[0], out _) && uint.TryParse(values[5], out _) && uint.TryParse(values[9], out _);
			if (checkInts)
			{
				uint id = uint.Parse(values[0]);
				string url = values[1];
				string title = values[2];
				string category = values[3];
				string date = values[4];
				uint views = uint.Parse(values[5]);
				string imageUrl = values[6];
				string postText = values[7];
				string additionalInfo = values[8];
				uint commentsQuantity = uint.Parse(values[9]); 
				record = new FileRecord(id, url, title, category, date, views, imageUrl, postText, additionalInfo, commentsQuantity);
			}
			return checkInts;
		}

	}
}
