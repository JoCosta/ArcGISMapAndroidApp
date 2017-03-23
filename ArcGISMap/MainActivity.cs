using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.ArcGISServices;

namespace ArcGISMap
{
    [Activity (Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/map", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        MapView mapView;
       

        static Uri arcGISaerealMapUri = new Uri("https://adapter.caymanlandinfo.ky/ngis/rest/services/Basemap_Aerial_2013/MapServer");
        static Uri arcGISnavigationMapUri = new Uri("https://adapter.caymanlandinfo.ky/ngis/rest/services/Basemap_Navigation_WebMAS_FA/MapServer");
       
        ArcGISMapImageLayer arcGISMapImageAerealLayer = new ArcGISMapImageLayer(arcGISaerealMapUri);
        ArcGISMapImageLayer arcGISMapImageNavigationLayer = new ArcGISMapImageLayer(arcGISnavigationMapUri);
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set the view from the "Main" layout resource
            SetContentView(Resource.Layout.Main);

            
            // Get MapView from the view and assign map from view-model
            mapView = FindViewById<MapView>(Resource.Id.MyMapView);

                        
            // Create a new Map instance with a default basemap 
            Map myMap = new Map(BasemapType.ImageryWithLabels, 19.313299, -81.254601, 11);

            // Add arcGISMapImageLager to the map
           myMap.OperationalLayers.Add(arcGISMapImageNavigationLayer);

            // Provide used Map to the MapView
            mapView.Map = myMap;
       
        }

    }
}