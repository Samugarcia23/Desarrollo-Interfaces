using _21_GameTest_Test.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_GameTest_Test.ViewModel
{
	public class MiViewModel : clsVMBase
	{
		#region Propiedades Privadas

		private clsPlayer _player;
		private int _counter;
		private int _points;
		private int _jugadoresConectados;

		#endregion

		#region Propiedades Publicas

		public clsPlayer player
		{
			get { return _player;}
			set { _player = value; NotifyPropertyChanged("player"); }
		}

		public int jugadoresConectados
		{
			get { return _jugadoresConectados; }
			set
			{
				_jugadoresConectados = value;
				NotifyPropertyChanged("jugadoresConectados");
			}
		}

		public int counter
		{
			get { return _counter; }
			set { _counter = value; NotifyPropertyChanged("counter"); }
		}

		public int points
		{
			get { return _points; }
			set { _points = value; NotifyPropertyChanged("points"); }
		}

		#endregion

		#region Constructores

		public MiViewModel()
		{
			_player = new clsPlayer();
			_counter = 0;
			_jugadoresConectados = 0;
			_points = 0;
		}

		#endregion
		

	}
}
