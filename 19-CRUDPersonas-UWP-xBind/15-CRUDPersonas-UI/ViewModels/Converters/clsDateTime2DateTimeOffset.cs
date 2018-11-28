using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _15_CRUDPersonas_UI.ViewModels.Converters
{
    public class clsDateTime2DateTimeOffset : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

			DateTimeOffset dt = DateTimeOffset.Parse(value.ToString());
			return dt.ToString("dd/MM/yyyy");
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			DateTimeOffset fecha = (DateTimeOffset) value;

			return fecha.DateTime;
		}
	}
}
