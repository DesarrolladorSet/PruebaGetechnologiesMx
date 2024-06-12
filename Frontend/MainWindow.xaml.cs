using Frontend.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Guardar_Click(object sender, RoutedEventArgs e)
		{
			Boolean isValid = true;
			if (Nombre.Text == "")
			{
				Nombre.BorderBrush = System.Windows.Media.Brushes.Red;
				isValid = false;
			}
			else
				Nombre.BorderBrush = System.Windows.Media.Brushes.Gray;

			if (ApellidoPaterno.Text == "")
			{
				ApellidoPaterno.BorderBrush = System.Windows.Media.Brushes.Red;
				isValid = false;
			}
			else
				ApellidoPaterno.BorderBrush = System.Windows.Media.Brushes.Gray;

			if (Identificacion.Text == "")
			{
				Identificacion.BorderBrush = System.Windows.Media.Brushes.Red;
				isValid = false;
			}
			else
				Identificacion.BorderBrush = System.Windows.Media.Brushes.Gray;


			if (isValid)
			{
				try
				{
					var persona = new Models.Persona { Nombre = Nombre.Text, ApellidoMaterno = ApellidoMaterno.Text, ApellidoPaterno = ApellidoPaterno.Text, Identificacion = Identificacion.Text };

					var resp = await new Service().CreatePersona(persona);
					if (resp.StatusCode == System.Net.HttpStatusCode.OK)
					{
						Nombre.Text = "";
						ApellidoMaterno.Text = "";
						ApellidoPaterno.Text = "";
						Identificacion.Text = "";
						System.Windows.MessageBox.Show("Persona agregada correctamente!");
					}
					else
					{
						throw new Exception("Error agregar Persona, Error:" + resp.Content.ToString());
					}
				}
				catch (Exception ex)
				{
					System.Windows.MessageBox.Show(ex.Message);
				}
				
			}
		}
	}
}