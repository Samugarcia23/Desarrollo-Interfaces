using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _15_CRUDPersonas_UI.ViewModels.Converters
{
	public class clsConverterFechaCorta : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

			DateTime dt = DateTime.Parse(value.ToString());
			return dt.ToString("dd/MM/yyyy");
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			DateTime fecha;
			DateTime.TryParse((String)value, out fecha);
			return fecha;
		}
	}
}
