namespace Rs.Config
{
    public partial interface IDiscountSupported<T> where T : DiscountMapping
    {
        int Id { get; set; }
    }
}