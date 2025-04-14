namespace Soccer.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Items { get; }
        public PageViewModel PageViewModel { get; }
        public IndexViewModel(IEnumerable<T> items, PageViewModel viewModel)
        {
            Items = items;
            PageViewModel = viewModel;
        }
    }
}
