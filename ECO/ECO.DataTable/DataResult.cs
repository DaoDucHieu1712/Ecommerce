namespace ECO.DataTable
{
    public class DataResult<T> where T : class
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public long RecordsFiltered { get; set; }
        public List<T>? Data { get; set; }
    }

    public class CustomDataResult<T> : DataResult<T> where T : class
    {
        public decimal GrandTotal { get; set; }
    }
}
