using System.Runtime.Serialization;

namespace CsvToJsonLibrary
{
	/// <summary>
	/// Класс - экземпляр данных
	/// </summary>
	[DataContract]
	public class FileRecord
	{
		[DataMember]
		public uint Id { get; set; }
		[DataMember]
		public string Url { get; set; }
		[DataMember]
		public string Title { get; set; }
		[DataMember]
		public string Category { get; set; }
		[DataMember]
		public string Date { get; set; }
		[DataMember]
		public uint Views { get; set; }
		[DataMember]
		public string ImageUrl { get; set; }
		[DataMember]
		public string PostText { get; set; }
		[DataMember]
		public string AdditionalInfo { get; set; }
		[DataMember]
		public uint CommentsQuantity { get; set; }

		public FileRecord(uint id, string url, string title, string category,
			string date, uint views, string imageurl, string posttext, string additionalInfo,
			uint commentsQuantity)
		{
			Id = id;
			Url = url;
			Title = title;
			Category = category;
			Date = date;
			Views = views;
			ImageUrl = imageurl;
			PostText = posttext;
			AdditionalInfo = additionalInfo;
			CommentsQuantity = commentsQuantity;

		}

		public override string ToString()
		{
			return $"{Id} ({Title}): url: {Url}";
		}
	}
}
