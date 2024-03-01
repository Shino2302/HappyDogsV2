using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

namespace HappyDogsV2.Views.MainMenu.PetProfiles;

public partial class PetCamera : ContentPage
{
	//References to my ESP32CAM
	private const string _ioTEndPoint = "a2zqvo2m9sdrkn-ats.iot.us-east-1.amazonaws.com";
	private const string _thingName = "ESP32_CAM";
	private const string _clientId = "sdk-dotnet";

	private const int _brokerPort = 8883;
	private const string _topic = "sdk/test/dotnet";
	private static MqttClient? _client;

	public PetCamera()
	{
		InitializeComponent();

        var caCert = X509Certificate.CreateFromCertFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates/root-CA.crt"));
        var certPem = File.ReadAllText(string.Format("Certificates/ESP32_CAM.cert.pem", _thingName));
        var eccPem = File.ReadAllText(string.Format("Certificates/ESP32_CAM.private.key", _thingName));
        var clientCert = X509Certificate2.CreateFromPem(certPem, eccPem);
        // Set up the cline to connect to AWS
        _client = new MqttClient(_ioTEndPoint, _brokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
        _client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
        _client.ConnectionClosed += Client_ConnectionClosed;

        try
        {
            // Try connecting to AWS IoT Core
            _client.Connect(_clientId);
            // Subscribe to the topics to receive echo messages.
            // You would not normally do this in a client, we are just doing it here for testing.
            _client.Subscribe(new string[] { _topic }, new byte[] { 0 });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting... " + ex.ToString());
            return;
        }
        
    }

    private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
    {
        var sb = new StringBuilder();
        foreach (var b in e.Message)
        {
            sb.Append(Convert.ToChar(b));
        }

        var message = sb.ToString();
        Straemsss.Text = message.ToString();
        //Console.WriteLine("Message Received: " + message);
    }

    private static void Client_ConnectionClosed(object sender, EventArgs e)
    {
        // Reconnect the client.
        _client?.Connect(_thingName);
        _client?.Subscribe(new string[] { _topic }, new byte[] { 0 });
    }

}