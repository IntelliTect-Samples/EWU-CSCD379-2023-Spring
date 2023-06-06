namespace Wordle.Api.Models
{
    public class ListResult<T>
        
    {
        public ListResult(T list, int totalCount, int pageNumber)
        {
            List = list;
            TotalCount = totalCount;
            PageNumber = pageNumber;
        }

        public T List { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
    }
}
