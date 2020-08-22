namespace EfConcurrency.ServicesLayer.ViewModels.BaseViewModel
{
    public interface IBaseViewModel<TKey>
    {
        TKey Id { get; set; }
    }
}
