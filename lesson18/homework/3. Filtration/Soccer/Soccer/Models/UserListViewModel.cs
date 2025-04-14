using Microsoft.AspNetCore.Mvc.Rendering;

namespace Soccer.Models
{
    public class UserListViewModel<T>
    {
        public IEnumerable<T> Item { get; set; } = new List<T>();
        public SelectList PlayersSelectList { get; set; } = new SelectList(new List<Teams>(), "Id", "Name");
        public string? Position { get; set; }
    }
}
