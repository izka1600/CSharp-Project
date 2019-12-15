using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arkusz_Wydatki_WPF
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		protected readonly Arkusz_WydatkiEntities context;

		public MainWindowViewModel()
		{
			ViewKategorieCommand = new RelayCommand(ViewKategorie);
			context = new Arkusz_WydatkiEntities();
			Task.Run(() =>
			{
				Transakcje = new ObservableCollection<Transakcje>(context.Transakcje);
			}
					);
		}

		private ObservableCollection<Transakcje> transakcje { get; set; }
		public ObservableCollection<Transakcje> Transakcje
		{
			get { return transakcje; }
			set
			{
				transakcje = value;
				OnPropertyChanged();
			}
		}


		private void ViewKategorie(object sender)
		{

		}
		public ICommand ViewKategorieCommand { get; private set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(
			[System.Runtime.CompilerServices.CallerMemberName]
			string propertyName = "")
		{
			PropertyChanged?.Invoke(this,
				new PropertyChangedEventArgs(propertyName));
		}
	}
}
