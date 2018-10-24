using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
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
	public sealed partial class citaView : Page
	{
		public citaView()
		{
			this.InitializeComponent();
			MapService.ServiceToken = "6mLJjsZcXXvJfJrFkd7d~hg9t2mShAf8JYxbMZAkUFA~AhD_b_cUSyP6KUYf9XcYvpbAFmEe4LtR7SUBGjAbYH1Eu48YXaTr3TYyBtfmxaTy ";
		}

		/// <summary>
		/// Metodo para iniciar el mapa en la ubicacion especificada
		/// </summary>
		/// <param name="e"></param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			// Specify a known location.
			BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 37.3914105, Longitude = -5.9591776 };
			Geopoint cityCenter = new Geopoint(cityPosition);

			// Set the map location.
			MapControl1.ZoomLevel = 13;
			MapControl1.LandmarksVisible = true;
			AddLandMark();
		}

		/// <summary>
		/// Metodo para añadir landmarks a nuestro mapa
		/// </summary>
		public void AddLandMark()
		{
			var MyLandmarks = new List<MapElement>();

			BasicGeoposition snPosition = new BasicGeoposition { Latitude = 37.390890, Longitude = -5.973330 };
			Geopoint snPoint = new Geopoint(snPosition);

			BasicGeoposition snPosition2 = new BasicGeoposition { Latitude = 37.386983, Longitude = -5.973757 };
			Geopoint snPoint2 = new Geopoint(snPosition2);

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
				Title = "Tu ubicacion"
			};

			MyLandmarks.Add(icono1);
			MyLandmarks.Add(icono2);

			var LandmarksLayer = new MapElementsLayer
			{
				ZIndex = 1,
				MapElements = MyLandmarks
			};

			MapControl1.Layers.Add(LandmarksLayer);

			MapControl1.Center = snPoint;

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			mostrarRuta();
		}

		/// <summary>
		/// Metodo para mostrar la ruta entr 2 puntos del mapa
		/// </summary>
		private async void mostrarRuta()
		{
			// Ubicacion del cliente
			BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 37.390890, Longitude = -5.973330 };

			// Tu ubicacion
			BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 37.386983, Longitude = -5.973757 };

			// Ruta entre los puntos
			MapRouteFinderResult routeResult =
				  await MapRouteFinder.GetDrivingRouteAsync(
				  new Geopoint(startLocation),
				  new Geopoint(endLocation),
				  MapRouteOptimization.Time,
				  MapRouteRestrictions.None);

			if (routeResult.Status == MapRouteFinderStatus.Success)
			{
				// Utilizar la ruta para inicializar MapRouteView
				MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
				viewOfRoute.RouteColor = Colors.Yellow;
				viewOfRoute.OutlineColor = Colors.Black;

				// Añade el nuevo MapRouteView a la coleccion de rutas del mapa
				MapControl1.Routes.Add(viewOfRoute);

				// Adapta el mapa a la ruta
				await MapControl1.TrySetViewBoundsAsync(
				  routeResult.Route.BoundingBox,
				  null,
				  Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
			}
			else { MapControl1.ZoomLevel = 10; }
		}
	}
}
