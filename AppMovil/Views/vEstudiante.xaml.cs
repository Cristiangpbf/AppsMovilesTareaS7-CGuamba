
using cGuambaS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace cGuambaS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string urlWS = "http://127.0.0.1/wsestudiantes/estudiantews.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;

    public vEstudiante()
	{
		InitializeComponent();
		Obtener();
	}

    private async void Obtener()
    {
		var content = await cliente.GetStringAsync(urlWS);
		List<Estudiante> listaEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estudiantes = new ObservableCollection<Estudiante>(listaEstudiantes);
        lvEstudiantes.ItemsSource = estudiantes;

    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgregar());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante) e.SelectedItem;
        Navigation.PushAsync(new vActualizarEliminar(objEstudiante));
    }
}