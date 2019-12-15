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
		public ICommand SaveCommand { get; private set; }

		public MainWindowViewModel()
		{
			ViewKategorieCommand = new RelayCommand(ViewKategorie);
			context = new Arkusz_WydatkiEntities();
			Task.Run(() =>
			{
				Transakcje = new ObservableCollection<Transakcje>(context.Transakcje);
				Kategorie = new ObservableCollection<Kategorie>(context.Kategorie);
			}
					);
			Task.Run(() => Init());
		}
		internal void Init()
		{
			this.OdswiezTransakcje();
			this.OdswiezKategorie();
		}

		private IEnumerable<Transakcje> transakcje { get; set; }
		public IEnumerable<Transakcje> Transakcje
		{
			get { return transakcje; }
			set
			{
				this.transakcje = value;
				OnPropertyChanged();
			}
		}
		private void OdswiezTransakcje()
		{
			this.Transakcje = null;
			this.Transakcje = this.WybraneKategorie?.Transakcje;
		}

		private IEnumerable<Kategorie> kategorie;
		public IEnumerable<Kategorie> Kategorie
		{
			get
			{
				return this.kategorie;
				this.OnPropertyChanged();
			}
			set
			{
				this.kategorie = value;
				this.OnPropertyChanged(nameof(Kategorie));
			}
		}

		private void OdswiezKategorie()
		{
			this.Kategorie = this.Kategorie;
		}
		private Kategorie wybraneKategorie;
		public Kategorie WybraneKategorie
		{
			get
			{
				return this.wybraneKategorie;
			}
			set
			{
				this.wybraneKategorie = value;
				this.OnPropertyChanged();
				this.OdswiezTransakcje();  // dodane ponizej
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
