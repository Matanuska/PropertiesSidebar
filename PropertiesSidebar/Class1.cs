using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSidebar
{
    public class Class1
    {
        public int MyProperty { get; set; }

        public int MyProperty2 { get; set; }

        [Category("Display")]
        [DisplayName("Format String")]
        [Description("Format string governing display of data values.")]
        [DefaultValue("")]
        [TypeConverter(typeof(FormatStringConverter))]
        public String FormatString { get; set; }


        private string myVar = "9600";

        [Category("Speed")]
        [DisplayName("Baud rate")]
        [Description("Format string governing display of data values.")]
        [DefaultValue("9600")]
        [TypeConverter(typeof(Baudrate))]
        public string BaudRate
        {
            get { return myVar; }
            set { myVar = value; }
        }


    }

    public class FormatStringConverter : StringConverter
    {
        public override Boolean GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override Boolean GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<String> list = new List<String>();
            list.Add("");
            list.Add("Currency");
            list.Add("Scientific Notation");
            list.Add("General Number");
            list.Add("Number");
            list.Add("Percent");
            list.Add("Time");
            list.Add("Date");
            return new StandardValuesCollection(list);
        }
    }

    public class Baudrate : StringConverter
    {
        public override Boolean GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override Boolean GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<int> list = new List<int>();
            list.Add(75);
            list.Add(9600);
            list.Add(115200);

 

            return new StandardValuesCollection(list);
        }
    }
}
