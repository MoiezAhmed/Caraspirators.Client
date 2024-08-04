


using Caraspirators.Client.Framework.Extensions;

namespace Caraspirators.Client.ViewModels;

public partial class CategoriespageViewModel : AppViewModelBase
{

    [ObservableProperty]
    private ObservableCollection<Category> _categories;
    
  private  CategoriesService _categoriesService;
    public CategoriespageViewModel(ICategoryService categoriesService) : base(categoriesService)
    {
        Categories = new ObservableCollection<Category>();
        OnNavigatedTo();
    }

    public  async void OnNavigatedTo()
    {
        await Search();
    }

    private async Task Search()
    {
        var categories = await _appApiService.GetCategoriesAsync();
       // Categories?.Clear();
       // Categories?.AddRange(categories);
    }
}
