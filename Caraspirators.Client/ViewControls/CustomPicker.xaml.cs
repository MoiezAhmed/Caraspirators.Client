using System.Collections;

namespace Caraspirators.Client.ViewControls;

public partial class CustomPicker : Grid
{
    public static readonly BindableProperty PickerTitleProperty = BindableProperty.Create(
      "Title",
      typeof(string),
      typeof(CustomPicker),
      null,
      BindingMode.OneWay,
      null,
      SetIsError);

    public string Title
    {
        get => (string)this.GetValue(PickerTitleProperty);
        set => this.SetValue(PickerTitleProperty, value);
    }

    private static void SetIsError(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as CustomPicker).CutPicker.Title = (string)newValue;



    public static readonly BindableProperty PickerItemSourceProperty = BindableProperty.Create(
     "PickerItemSource",
     typeof(IEnumerable),
     typeof(CustomPicker),
     null,
     BindingMode.OneWay,
     null,
     SetItemSource);

    public IEnumerable PickerItemSource
    {
        get => (IEnumerable)this.GetValue(PickerTitleProperty);
        set => this.SetValue(PickerTitleProperty, value);
    }

    private static void SetItemSource(BindableObject bindable, object oldValue, object newValue) =>
       (bindable as CustomPicker).CutPicker.ItemsSource = (IList)newValue;
    public CustomPicker()
	{
		InitializeComponent();
	}
}