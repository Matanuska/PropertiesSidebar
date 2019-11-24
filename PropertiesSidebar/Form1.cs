using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PropertiesSidebar
{
    public partial class Form1 : Form
    {

        mySerialPort localport = new mySerialPort();

        SerialPort _sp = new SerialPort();
        public Form1()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = localport;

            localport.DtrEnable = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
            propertyGrid1.SelectedObject = _sp;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider<IMyInterface>))]
    public class mySerialPort : SerialPort, IMyInterface
    {


    }

    public interface IMyInterface
    {
        
        int BaudRate { get; set; }
        int DataBits { get; set; }
        Parity Parity { get; set; }
        Handshake Handshake { get; set; }
        Boolean DiscardNull { get; set; }
        Boolean DtrEnable { get; set; }            
        byte ParityReplace { get; set; }
        int ReadBufferSize { get; set; }
        int ReadTimeout { get; set; }
        int ReceivedBytesThreshold { get; set; }
        bool RtsEnable { get; set; }
        StopBits StopBits { get; set; }
        int WriteBufferSize { get; set; }
        int WriteTimeout { get; set; }
    }

    public class MyTypeDescriptionProvider<T> : TypeDescriptionProvider
    {
        public MyTypeDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(T))) { }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType,
            object instance)
        {
            return base.GetTypeDescriptor(typeof(T), instance);
        }
    }
}
