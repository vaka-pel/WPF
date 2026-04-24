using System;
using System.Collections.Generic;
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

namespace CustomTextBoxControl.View.UserControls
{
	/// <summary>
	/// Interaction logic for ClearableTextBox.xaml
	/// </summary>
	public partial class ClearableTextBox : UserControl
	{
		string placeholder;
		public string Placeholder 
		{
			get => placeholder;
			set => placeholder = tbPlaceholder.Text = value;
		}
		public ClearableTextBox()
		{
			InitializeComponent();
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			txtInput.Text = "";
        }

		private void TxtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Window window = Window.GetWindow(this);
				e.Handled = true;
				UIElement tb = sender as UIElement;
				tb?.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
			if (e.Key == Key.Escape)
			{
				btnClear_Click(sender, e);
			}
		}

		private void txtInput_TextChanged(object sender, TextChangedEventArgs e)=>
			tbPlaceholder.Visibility = txtInput.Text == "" ? Visibility.Visible : Visibility.Hidden;
		
	}
}
