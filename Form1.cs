using NLog;
using NLog.Config;
using PortsApp.Entity;
using PortsApp.Exception;
using System.Globalization;
using System.IO.Ports;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Double;

namespace PortsApp
{
    public partial class Form1 : Form
    {
        private static SerialPort? _serialPort;

        private static Logger? logger;

        public Form1()
        {
            InitializeComponent();
            FillPortsComboBox();
            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
            logger = LogManager.GetCurrentClassLogger();
        }

        private void FillPortsComboBox()
        {
            string[] ports = SerialPort.GetPortNames();
            portsCB.Items.Clear();
            portsCB.Items.AddRange(ports);
            if (portsCB.Items.Count != 0)
            {
                portsCB.SelectedIndex = 0;
            }
        }

        private void SerialPortDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                return;
            }

            const string SensorName = "WMT700";

            string messageFromSensor = _serialPort.ReadLine();
            try
            {
                ParseSensorMessage(messageFromSensor, out double windSpeed, out double windDirection);
                var windInfo = new WindInfo(DateTime.Now, SensorName, windSpeed, windDirection);

                string filePath = tbFilePath.Text;

                string? jsonData = null;
                List<WindInfo>? windInfoList = null;
                if (File.Exists(filePath))
                {
                    jsonData = File.ReadAllText(filePath);
                    try
                    {
                        windInfoList = JsonSerializer.Deserialize<List<WindInfo>>(jsonData) ?? new List<WindInfo>();
                    }
                    catch (JsonException)
                    {
                        windInfoList = new List<WindInfo>();
                    }
                }
                else
                {
                    windInfoList = new List<WindInfo>();
                }
                windInfoList.Add(windInfo);
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                jsonData = JsonSerializer.Serialize(windInfoList, options);
                File.WriteAllText(filePath, jsonData);
            }
            catch (InvalidMessageFormatException ex)
            {
                MessageBox.Show(ex.Message);
                logger?.Warn($"Format of message {messageFromSensor} from port {_serialPort.PortName} is invalid. Exception: {ex.GetType().Name}.");
            }
        }

        private static bool IsValidSensorMessage(string message)
        {
            const string RegexPattern = @"^([$])\d{2}[.]\d{2},\d{3}[.]\d{2}";

            var regex = new Regex(RegexPattern, RegexOptions.Compiled);
            return regex.IsMatch(message);
        }

        private static void ParseSensorMessage(string message, out double windSpeed, out double windDirection)
        {
            if (IsValidSensorMessage(message))
            {
                const char delimiterChar = ',';
                string[] windParamsStr = message.Substring(1).Split(delimiterChar);
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

                windSpeed = Parse(windParamsStr[0], formatter);
                windDirection = Parse(windParamsStr[1], formatter);
            }
            else
            {
                throw new InvalidMessageFormatException("Message format is invalid");
            }
        }

        private void BtnStartCheckedChangedEventHandler(object sender, EventArgs e)
        {
            if (btnStart.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbFilePath.Text))
                {
                    btnStart.Checked = false;
                    MessageBox.Show("The path of the result file cannot be empty");
                    return;
                }
                var selectedCBItem = portsCB.SelectedItem;
                if (selectedCBItem == null)
                {
                    btnStart.Checked = false;
                    return;
                }
                string? portName = selectedCBItem.ToString();
                if (portName != null)
                {
                    const Int32 DataBits = 8;

                    _serialPort = new SerialPort(portName, 2400, Parity.Space, DataBits, StopBits.One);
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceivedEventHandler);
                    try
                    {
                        _serialPort.Open();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error while connecting to port");
                        FillPortsComboBox();
                        logger?.Error($"Connot connect to port {portName}. Exception: {ex.GetType().Name}. Message: {ex.Message}");
                    }
                }
                else
                {
                    btnStart.Checked = false;
                }
            }
            else
            {
                _serialPort?.Close();
            }
        }

        private void PortsCBSelectedIndexChangedEventHandler(object sender, EventArgs e)
        {
            btnStart.Checked = false;
        }

        private void BtnBrowseClickEventHandler(object sender, EventArgs e)
        {
            const string DefaultFileName = "WindInfo";
            const string DefaultFileFilter = "JSON (*.json)|*.json";

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DefaultFileFilter;
            saveFileDialog.FileName = DefaultFileName;
            saveFileDialog.OverwritePrompt = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = saveFileDialog.FileName;
            }
        }

        private void BtnRefreshClickEventHandler(object sender, EventArgs e)
        {
            btnStart.Checked = false;
            FillPortsComboBox();
        }
    }
}