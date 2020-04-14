using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CsvToJsonLibrary
{
	/// <summary>
	/// Класс для записи данных в Json-файл
	/// </summary>
	public class JsonWriter
	{
		public string FilePath { get; private set; } = FileConstants.JSON_FILE_NAME;

		public event Error onError;

		public JsonWriter() { }

		public JsonWriter(string filePath)
		{
			FilePath = filePath;
		}

		public void WriteToJson(List<FileRecord> recordsToWrite)
		{
			try
			{
				DataContractJsonSerializer formater = new DataContractJsonSerializer(typeof(List<FileRecord>));
				using (FileStream fs = new FileStream(FilePath, FileMode.Create))
				{
					formater.WriteObject(fs, recordsToWrite);
				}
			}
			catch(SerializationException e)
			{
				onError?.Invoke(e.Message);
			}
			catch (IOException e)
			{
				onError?.Invoke(e.Message);
			}
			catch (UnauthorizedAccessException e)
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
		}
	}
}
