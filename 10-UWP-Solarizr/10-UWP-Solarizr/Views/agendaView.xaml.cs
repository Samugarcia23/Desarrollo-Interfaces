using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _10_UWP_Solarizr.Views
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class agendaView : Page
	{
		public agendaView()
		{
			this.InitializeComponent();
			MapControl1.MapServiceToken = "6mLJjsZcXXvJfJrFkd7d~hg9t2mShAf8JYxbMZAkUFA~AhD_b_cUSyP6KUYf9XcYvpbAFmEe4LtR7SUBGjAbYH1Eu48YXaTr3TYyBtfmxaTy ";

		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			// Specify a known location.
			BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 37.3914105, Longitude = -5.9591776 };
			Geopoint cityCenter = new Geopoint(cityPosition);

			// Set the map location.
			MapControl1.Center = cityCenter;
			MapControl1.ZoomLevel = 15;
			MapControl1.LandmarksVisible = true;
			AddLandMark();
		}

		public void AddLandMark()
		{
			var MyLandmarks = new List<MapElement>();

			BasicGeoposition snPosition = new BasicGeoposition { Latitude = 37.390890, Longitude = -5.973330 };
			Geopoint snPoint = new Geopoint(snPosition);

			BasicGeoposition snPosition2 = new BasicGeoposition { Latitude = 37.386983, Longitude = -5.973757 };
			Geopoint snPoint2 = new Geopoint(snPosition2);

			BasicGeoposition snPosition3 = new BasicGeoposition { Latitude = 37.391348, Longitude = -5.979934 };
			Geopoint snPoint3 = new Geopoint(snPosition3);

			BasicGeoposition snPosition4 = new BasicGeoposition { Latitude = 37.388443, Longitude = -5.969110 };
			Geopoint snPoint4 = new Geopoint(snPosition4);


			var icono1 = new MapIcon
			{
				Location = snPoint,
				NormalizedAnchorPoint = new Point(0.5, 1.0),
				ZIndex = 0,
				Title = "Calle Nueva Orleans 12, 1ºF"
			};

			var icono2 = new MapIcon
			{
				Location = snPoint2,
				NormalizedAnchorPoint = new Point(0.5, 1.0),
				ZIndex = 0,
				Title = "Avenida Circular 45, 3ºA"
			};

			var icono3 = new MapIcon
			{
				Location = snPoint3,
				NormalizedAnchorPoint = new Point(0.5, 1.0),
				ZIndex = 0,
				Title = "Calle Super Nova 12, 5ºD"
			};

			var icono4 = new MapIcon
			{
				Location = snPoint4,
				NormalizedAnchorPoint = new Point(0.5, 1.0),
				ZIndex = 0,
				Title = "Calle Asfaltada 32, Bajo B"
			};

			MyLandmarks.Add(icono1);
			MyLandmarks.Add(icono2);
			MyLandmarks.Add(icono3);
			MyLandmarks.Add(icono4);


			var LandmarksLayer = new MapElementsLayer
			{
				ZIndex = 1,
				MapElements = MyLandmarks
			};

			MapControl1.Layers.Add(LandmarksLayer);

			MapControl1.Center = snPoint;
			MapControl1.ZoomLevel = 15;

		}

		private void rpText1_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			Frame.Navigate(typeof(citaView));
		}
	}
}
