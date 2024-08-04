
using MvvmHelpers;
using Caraspirators.Client.Framework.Extensions;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.Input;

namespace Caraspirators.Client.ViewModels;

public partial class HomePageViewModel : AppViewModelBase
{
    private bool _isSearchBarVisible = true;
    private double _lastScrollY = 0; //
    //   public IRelayCommand<ScrolledEventArgs> OnScrolledCommand { get; }

    [ObservableProperty]
    public double _scrolly;

    [ObservableProperty]
    private ObservableRangeCollection<Category> _categories;

    [ObservableProperty]
    private ObservableRangeCollection<Category> _ads;

    [ObservableProperty]
    private ObservableRangeCollection<Category> _popularproduct;
    
    [ObservableProperty]
    private ObservableRangeCollection<Category> _recentlyorderdproduct;
    public HomePageViewModel(ICategoryService categoriesService) : base(categoriesService)
    {

      //  OnScrolledCommand = new RelayCommand<ScrolledEventArgs>(OnScrolled);

    }


    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    private async Task Search()
    {
        SetDataLodingIndicators(true);
        LoadingText = "Hold on while loading...";

        Categories = new();
        Ads= new ();
        Popularproduct = new ();


        try
        {
            //Search for videos
            await GetData();

           this.DataLoaded = true;
        }
        catch (InternetConnectionException iex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "icwarning.svg";
        }
        catch (Exception ex)
        {
            this.IsErrorState = true;
          //  this.ErrorMessage = $"Something went wrong. If the problem persists, plz contact support at {Constants.EmailAddress} with the error message:" + Environment.NewLine + Environment.NewLine + ex.Message;
            ErrorImage = "icwarning.svg";
        }
        finally
        {
            SetDataLodingIndicators(false);
        }
    }
    private async Task GetData()
    {
        //Search the categories
        var categories = await _appApiService.GetCategoriesAsync();
        Categories?.Clear();
        //Categories?.AddRange(categories);
       
        //Search the popualr products
        var popualrs = await _appApiService.GetCategoriesAsync();
        Popularproduct?.Clear();
       // Popularproduct?.AddRange(popualrs);

        //Search the ads
        var ads = await _appApiService.GetCategoriesAsync();
        Ads?.Clear();
       // Ads?.AddRange(ads);

        //Search the recently order
        var recentlyproduct = await _appApiService.GetCategoriesAsync();
        Recentlyorderdproduct?.Clear();
      //  Recentlyorderdproduct?.AddRange(recentlyproduct);
       
    }

    [RelayCommand]
    private async  Task WhenScrolledStart()
    {
     
    }

    public void OnScrolled(double scrollY)
    {
        if (scrollY == 0) // Check for downward scrolling
        {
          this.IssearchbarVisiable= true;

        }
        else
        {
            this.IssearchbarVisiable = false;
        }
        _lastScrollY = scrollY; // Update last scroll position
}
  


    //async void GetProducts()
    //{
    //    try
    //    {
    //        _categoriesService=new CategoryService();
    //        Categories = new ObservableCollection<Category>();
    //        var categories = await _appApiService.GetCategoriesAsync();
    //        //var getcategories = await _categoriesService.GetCategoriesAsync();
    //        if (categories is null)
    //            return;

    //        if (Categories.Count() > 0)
    //            Categories.Clear();

    //        foreach (var category in categories)
    //            Categories.Add(category);
    //    }

    //    catch (Exception ex)
    //    {
    //        await PageService.DisplayAlert("Setting", ex.ToString(), "Got it!");
    //    }
    //    finally
    //    {

    //    }



    //}

}
