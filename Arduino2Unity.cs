using System.IO.Ports;
using System.Threading;

public class ArduinoCommunication
{
	//***********************************************************************************************************
	// Variables
	//***********************************************************************************************************

	private SerialPort _port;

	private string _latestReading;

	private Thread _thread;

	//***********************************************************************************************************
	// Getter & Setters
	//***********************************************************************************************************

	
	public SerialPort Port {
		get { return _port; }
		set { _port = value; }
	}

	public string LatestReading {
		get { return _latestReading; }
		set { _latestReading = value; }
	}

	public Thread Thread {
		get {
			return _thread;
		}
		set {
			_thread = value;
		}
	}

	//***********************************************************************************************************
	// Functions
	//***********************************************************************************************************

	public ArduinoCommunication (int baudRate, string commPort)
	{
	    _port = new SerialPort (commPort, baudRate, Parity.None, 8, StopBits.One);
		Port.Open ();
		Thread = new Thread (ReadSerialData) { IsBackground = true };
		Thread.Start ();
	}

	private void ReadSerialData ()
	{
		while (Thread.IsAlive) {
			var reading = Port.ReadLine ();
			LatestReading = reading;
		}
	}

	public void StopThread() {
		Thread.Abort ();
		Port.Close();
	}

}