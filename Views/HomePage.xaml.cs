using System.Diagnostics;
using velaapp.ViewModels;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using ZXing.QrCode.Internal;
using velaapp.Models;

namespace velaapp.Views;

public partial class HomePage : ContentPage
{
    #region fields
    int count = 0;
    HomePageViewModel homePageViewModel;
    #endregion fields

    #region constructor
    public HomePage()
	{
		InitializeComponent();
        this.homePageViewModel = new HomePageViewModel();
        BindingContext = this.homePageViewModel;

        //ZXing set up
        //Asset
        assetBarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = false,
            Multiple = false,
        };
        assetBarcodeReader.IsVisible = false;
        assetBarcodeReader.IsDetecting = false;
        //Location
        locationBarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = false,
            Multiple = false
        };
        locationBarcodeReader.IsVisible = false;
        locationBarcodeReader.IsDetecting = false;
    }
    #endregion constructor

    #region methods

    //Asset section
    private void OnAssetBtnClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("assetBarcodeReaderBtn clicked");
        assetBarcodeReader.IsVisible = !assetBarcodeReader.IsVisible;
        assetBarcodeReader.IsDetecting = !assetBarcodeReader.IsDetecting;
    }

    protected void AssetBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
        {
            Debug.WriteLine($"Asset Barcode: {barcode.Format} -> {barcode.Value}");
            assetBarcodeReader.IsVisible = false; //Close the reader when barcode is scanned
            homePageViewModel.IsAssetLabelsVisible = true;
        }
            
    }

    void OnAssetInputCompleted(object sender, EventArgs e)
    {
        string assetCode = ((Entry)sender).Text;
        Dictionary<string, AssetStructure> assetMapping = homePageViewModel.AssetMapping;
        if (assetMapping.ContainsKey(assetCode)) {
            homePageViewModel.IsAssetLabelsVisible = true;
            homePageViewModel.AssetName = assetMapping[assetCode].AssetName;
            homePageViewModel.AssetType = assetMapping[assetCode].AssetType;
            homePageViewModel.AssetCategory = assetMapping[assetCode].AssetCategory;
        } else
        {
            DisplayAlert("Attenzione!", "Bene non trovato.", "OK");
        }
    }

    void OnLocationInputCompleted(object sender, EventArgs e)
    {
        string locationCode = ((Entry)sender).Text;
        Dictionary<string, LocationStructure> locationMapping = homePageViewModel.LocationMapping;
        if (locationMapping.ContainsKey(locationCode))
        {
            homePageViewModel.IsLocationLabelsVisible = true;
            homePageViewModel.LocationName = locationMapping[locationCode].LocationName;
            homePageViewModel.LocationArea = locationMapping[locationCode].LocationArea;
            homePageViewModel.LocationZone = locationMapping[locationCode].LocationZone;
        }
        else
        {
            DisplayAlert("Attenzione!", "Ubicazione non trovata.", "OK");
        }
    }

    //Location section
    private void OnLocationBtnClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("locationBarcodeReaderBtn clicked");
        locationBarcodeReader.IsVisible = !locationBarcodeReader.IsVisible;
        locationBarcodeReader.IsDetecting = !locationBarcodeReader.IsDetecting;
    }

    protected void LocationBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
        {
            Debug.WriteLine($"Location Barcode: {barcode.Format} -> {barcode.Value}");
            locationBarcodeReader.IsVisible = false; //Close the reader when barcode is scanned
            homePageViewModel.IsLocationLabelsVisible = true;
        }

    }

    #endregion methods

    #region obsolete
    //From sample app, moved to VM
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }
    #endregion obsolete
}
