 
namespace TestQueenApp.Client.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    public ICategoryService _categoriesService { get; set; }
    public IAuthService _authService { get; set; }
    public HomePageViewModel(ICategoryService categoriesService, IAuthService authService)
    {
        _categoriesService = categoriesService;
        _authService = authService;
        Search();
       //  Siginin();
    }

    [ObservableProperty]
    private ObservableCollection<Category> _categories;

    [ObservableProperty]
    private LoginData _siginResponse;

    [ObservableProperty]
    public string message;
    private async Task Search()
    {



        try
        {
            Categories = new();
            //Search for videos
            await GetData();


        }

        catch (Exception ex)
        {
            Message = ex.Message.ToString();
        }

    }


    private async Task GetData()
    {
        //Search the categories
        Message = string.Empty;
        var (data, succeeded, message) = await _categoriesService.GetCategoriesAsync();

        Categories?.Clear();
        foreach (var category in data)
        {
            Categories?.Add(category);
        }

    }

    private async Task Siginin()
    {
        //Search the categories
        var user = new SiginRequest();
        user.UserName = "moiez";
        user.Password = "Moiez*009";
        Message = string.Empty;
        var (data, succeeded, message) = await _authService.SigninAsync(user);

        SiginResponse = data;

    }
}
