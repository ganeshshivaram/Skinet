namespace Infrastructure.RequestDataObjects
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize ? MaxPageSize : value);
            }
        }
        public string Sort { get; set; } = null;
        public int? BrandId { get; set; } = null;
        public int? TypeId { get; set; } = null;

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => _searchText = string.IsNullOrEmpty(value) ? string.Empty : value.ToLower();
        }

    }
}