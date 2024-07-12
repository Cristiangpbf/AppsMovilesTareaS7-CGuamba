using cGuambaS6.Models;
using System.Net;
using System.Text;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Newtonsoft.Json;


namespace cGuambaS6.Views;

public partial class vActualizarEliminar : ContentPage
{
    private const string urlWS = "http://127.0.0.1/wsestudiantes/estudiantews.php";
    private readonly HttpClient cliente = new HttpClient();
    public vActualizarEliminar(Estudiante estudiante)
	{
		InitializeComponent();
        txtId.Text = estudiante.id.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
	}

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var estudiante = new
        {
            id = txtId.Text,
            nombre = txtNombre.Text,
            apellido = txtApellido.Text,
            edad = txtEdad.Text
        };
        var json = JsonConvert.SerializeObject(estudiante);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await cliente.PutAsync(urlWS, content);
        string respuesta = await response.Content.ReadAsStringAsync();
        Navigation.PushAsync(new vEstudiante());
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var id = txtId.Text;
        var response = await cliente.DeleteAsync($"{urlWS}?id={id}");
        string respuesta = await response.Content.ReadAsStringAsync();
        Navigation.PushAsync(new vEstudiante());
    }
}