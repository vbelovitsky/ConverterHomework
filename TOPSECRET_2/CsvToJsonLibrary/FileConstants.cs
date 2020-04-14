using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToJsonLibrary
{
	/// <summary>
	/// Класс, хранящий распространенные в программе значения
	/// </summary>
	public static class FileConstants
	{

		static readonly char sep = Path.DirectorySeparatorChar;

		public static readonly string DEFAULT_FILE_NAME = $@"..{sep}..{sep}..{sep}parsed-news-data.csv";
		//public static readonly string DEFAULT_FILE_NAME = $@"../../../Kazantsev_1.csv";

		public static readonly string JSON_ROOT_NAME = $@"..{sep}..{sep}..{sep}";

		public static readonly string JSON_FILE_NAME = "parsed-news-data";

		public static readonly char DELIMETER = ';';

		public static readonly string DEFAULT_COLUMNS_NAMES = "id;url;title;category;date created;views;image url;post_text;add. info;number of comments";

		public static readonly int COLUMNS_NUMBER = DEFAULT_COLUMNS_NAMES.Split(DELIMETER).Length;


	}
}
