namespace ECO.DataTable
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public class DataRequest
	{
		public int Start { get; set; }
		public int Length { get; set; }
		public List<Column> Columns { get; set; }
		public List<OrderBy> Orders { get; set; }
		public Search? Search { get; set; }
		public List<Filter> Filters { get; set; }

		public DataRequest()
		{
			Filters = new List<Filter>();
			Orders = new List<OrderBy>();
			Columns = new List<Column>();
		}
	}

	public class Filter
	{
		public string Field { get; set; }
		public string Value { get; set; }
		public int Operand { get; set; }
	}

	public class Column
	{
		public string Field { get; set; }
		public string Name { get; set; }
		public bool Searchable { get; set; }
		public bool Orderable { get; set; }
	}

	public class OrderBy
	{
		public string Field { get; set; }
		public string Dir { get; set; }
	}

	public class Search
	{
		public string Value { get; set; }
		public bool Regex { get; set; }
	}

	public class CustomDataRequest : DataRequest
	{
		public string GrandTotalProperty { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

}
