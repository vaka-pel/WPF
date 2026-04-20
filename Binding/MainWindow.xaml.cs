using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace Binding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public MainWindow()
		{
			DataContext = this;
			InitializeComponent();
		}
		public event PropertyChangedEventHandler PropertyChanged;
		string boundText;
		public string BoundText
		{
			get => boundText;
			set
			{
				boundText = value;
				OnPropertyChanged();
			}
		}
		void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			// ? (Null-conditional operator) - используется при доступе к полям объектаб или элементам
			// obj?.member - если (obj == null), оператор '?' вернет 'null', в противном случае - значение поля 'member'.
		}

		private void BtnSet_Click(object sender, RoutedEventArgs e)
		{
			BoundText = "Default";
			txtInput.Focus();
		}
	}
}
