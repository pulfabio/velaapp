using System;
using DFMasterApp.ViewModels;
using velaapp.Models;

namespace velaapp.ViewModels
{
	public class HomePageViewModel : BaseViewModel
    {
        #region fields

        int count = 0;
        string counterClickedText = "Click me!";
        bool isAssetLabelsVisible = false;
        bool isLocationLabelsVisible = false;
        string assetName = "";
        string assetType = "";
        string assetCategory = "";
        string locationName = "";
        string locationArea = "";
        string locationZone = "";

        #endregion fields

        #region constructor
        public HomePageViewModel()
		{
            this.CounterButtonCommand = new Command(CommandButtonClicked);

            //Set up mockup data
            this.AssetMapping = new Dictionary<string, AssetStructure>();
            this.LocationMapping = new Dictionary<string, LocationStructure>();
            SetUpMappings();
        }
        #endregion Constructor

        #region public properties

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the counter clicked times.
        /// </summary>
        public string CounterClickedText
        {
            get
            {
                return this.counterClickedText;
            }

            set
            {
                if (this.counterClickedText == value)
                {
                    return;
                }

                this.counterClickedText = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with the asset labels visibility.
        /// </summary>
        public bool IsAssetLabelsVisible
        {
            get
            {
                return this.isAssetLabelsVisible;
            }

            set
            {
                if (this.isAssetLabelsVisible == value)
                {
                    return;
                }

                this.isAssetLabelsVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with the location labels visibility.
        /// </summary>
        public bool IsLocationLabelsVisible
        {
            get
            {
                return this.isLocationLabelsVisible;
            }

            set
            {
                if (this.isLocationLabelsVisible == value)
                {
                    return;
                }

                this.isLocationLabelsVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the asset name.
        /// </summary>
        public string? AssetName
        {
            get
            {
                return this.assetName;
            }

            set
            {
                if (this.assetName == value)
                {
                    return;
                }

                this.assetName = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the asset type.
        /// </summary>
        public string? AssetType
        {
            get
            {
                return this.assetType;
            }

            set
            {
                if (this.assetType == value)
                {
                    return;
                }

                this.assetType = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the asset name.
        /// </summary>
        public string? AssetCategory
        {
            get
            {
                return this.assetCategory;
            }

            set
            {
                if (this.assetCategory == value)
                {
                    return;
                }

                this.assetCategory = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the location name.
        /// </summary>
        public string? LocationName
        {
            get
            {
                return this.locationName;
            }

            set
            {
                if (this.locationName == value)
                {
                    return;
                }

                this.locationName = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the location area.
        /// </summary>
        public string? LocationArea
        {
            get
            {
                return this.locationArea;
            }

            set
            {
                if (this.locationArea == value)
                {
                    return;
                }

                this.locationArea = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the location zone.
        /// </summary>
        public string? LocationZone
        {
            get
            {
                return this.locationZone;
            }

            set
            {
                if (this.locationZone == value)
                {
                    return;
                }

                this.locationZone = value;
                this.NotifyPropertyChanged();
            }
        }

        //Dictionaries used to map asset and location data - mocked version of api service (WIP)
        public Dictionary<string, AssetStructure> AssetMapping { get; set; }

        public Dictionary<string, LocationStructure> LocationMapping { get; set; }

        #endregion public properties

        #region commands

        /// <summary>
        /// Gets or sets the command that will be executed when the Counter button is clicked.
        /// </summary>
        public Command CounterButtonCommand { get; set; }

        #endregion commands

        #region methods

        //Set up mockup data
        private void SetUpMappings()
        {
            //Asset section
            AssetStructure assetStructure = new AssetStructure()
            {
                AssetName = "Bene 1",
                AssetType = "Tipo bene A",
                AssetCategory = "Categoria bene 00"
            };
            this.AssetMapping.Add("bene_1", assetStructure);

            //Location section
            LocationStructure locationStructure = new LocationStructure()
            {
                LocationName = "Ubicazione 1",
                LocationArea = "Area A1",
                LocationZone = "Zona 001"
            };
            this.LocationMapping.Add("ubicazione_1", locationStructure);
        }

        //USED IN THE MAUI SAMPLE, OBSOLETE!
        /// <summary>
        /// Invoked when the Counter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void CommandButtonClicked(object obj)
        {
            count++;

            if (count == 1)
                this.CounterClickedText = $"Clicked {count} time - Fabs!";
            else
                this.CounterClickedText = $"Clicked {count} times - Fabs!";

            SemanticScreenReader.Announce(this.CounterClickedText);
        }

        #endregion methods
    }
}

