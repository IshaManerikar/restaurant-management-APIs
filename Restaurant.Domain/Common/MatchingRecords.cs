
namespace Restaurant.Domain.Common;

public class MatchingRecords<T>
{
   public IEnumerable<T> Items { get; set; }
   public int ItemCount { get; set; }
   public int PageCount { get; set; }
   public int FromIndex { get; set; }    
   public int ToIndex { get; set; }

}
