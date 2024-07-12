using System.Net;

namespace cGuambaS6.Views;

public partial class vAgregar : ContentPage
{
    private const string urlWS = "http://127.0.0.1/wsestudiantes/estudiantews.php";
    public vAgregar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
            WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues(urlWS, "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
		}
		catch (Exception ex)
		{
			DisplayAlert("Alerta", ex.Message, "OK");			
		}
    }
}