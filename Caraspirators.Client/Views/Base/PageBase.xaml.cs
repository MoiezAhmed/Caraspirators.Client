
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Caraspirators.Client.Views.Base;

public partial class PageBase : ContentPage
{

    public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
    public IList<Microsoft.Maui.IView> PageIcons => PageIconsGrid.Children;

    protected bool IsBackButtonEnabled
    {
        set => NavigateBackButton.IsEnabled = value;
    }

    #region Bindable properties
    public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
        nameof(PageTitle),
        typeof(string),
        typeof(PageBase),
        string.Empty,
        defaultBindingMode:
        BindingMode.OneWay,
        propertyChanged: OnPageTitleChanged);

    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }

    private static void OnPageTitleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
        {
            basePage.TitleLabel.Text = (string)newValue;
            basePage.TitleLabel.IsVisible = true;
        }
    }


    public static readonly BindableProperty PageModeProperty = BindableProperty.Create(
        nameof(PageMode),
        typeof(PageMode),
        typeof(PageBase),
        PageMode.None,
        propertyChanged: OnPageModePropertyChanged);

    public PageMode PageMode
    {
        get => (PageMode)GetValue(PageModeProperty);
        set => SetValue(PageModeProperty, value);
    }

    private static void OnPageModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetPageMode((PageMode)newValue);
    }

    private void SetPageMode(PageMode pageMode)
    {
        switch (pageMode)
        {
            case PageMode.Home:
                HeaderContentGrid.ColumnDefinitions.Clear();
                ColumnDefinition column1 = new ColumnDefinition { Width = GridLength.Auto };
                ColumnDefinition column2 = new ColumnDefinition { Width = GridLength.Star };
                ColumnDefinition column3 = new ColumnDefinition { Width = GridLength.Auto };
                // Add new column definitions to the Grid
                HeaderContentGrid.ColumnDefinitions.Add(column1);
                HeaderContentGrid.ColumnDefinitions.Add(column2);
                HeaderContentGrid.ColumnDefinitions.Add(column3);
                SearchViewEntry.Margin= new Thickness(50, 0, 50, 80);
                HeaderBoarder.StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(0, 0, 0, 80)
                };
                HamburgerButton.IsVisible = true;
                SearchViewEntry.IsVisible = true;

                CloseButton.IsVisible = false;
                TitleLabel.IsVisible = false;
                PageContentGrid.Margin = new Thickness(0, -60, 0, 0);
                break;
            case PageMode.Menu:
                HamburgerButton.IsVisible = true;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = false;
                break;
            case PageMode.Navigate:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = true;
                CloseButton.IsVisible = false;
                break;
            case PageMode.Modal:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = true;
                break;
            default:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = false;
                break;
        }
    }


    public static readonly BindableProperty ContentDisplayModeProperty = BindableProperty.Create(
        nameof(ContentDisplayMode),
        typeof(ContentDisplayMode),
        typeof(PageBase),
        ContentDisplayMode.NoNavigationBar,
        propertyChanged: OnContentDisplayModePropertyChanged);

    public ContentDisplayMode ContentDisplayMode
    {
        get => (ContentDisplayMode)GetValue(ContentDisplayModeProperty);
        set => SetValue(ContentDisplayModeProperty, value);
    }

    private static void OnContentDisplayModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetContentDisplayMode((ContentDisplayMode)newValue);
    }

    private void SetContentDisplayMode(ContentDisplayMode contentDisplayMode)
    {
        switch (contentDisplayMode)
        {
            case ContentDisplayMode.NavigationBar:
                Grid.SetRow(PageContentGrid, 2);
                Grid.SetRowSpan(PageContentGrid, 1);
                break;
            case ContentDisplayMode.NoNavigationBar:
                Grid.SetRow(PageContentGrid, 0);
                Grid.SetRowSpan(PageContentGrid, 3);
                break;
            default:
                //Do Nothing
                break;
        }
    }
    #endregion


    public PageBase()
    {
        InitializeComponent();

        //Hide the Xamarin Forms build in navigation header
        NavigationPage.SetHasNavigationBar(this, false);

        //Set Page Mode
        SetPageMode(PageMode.None);

        //Set Content Display Mode
        SetContentDisplayMode(ContentDisplayMode.NoNavigationBar);
    }
}