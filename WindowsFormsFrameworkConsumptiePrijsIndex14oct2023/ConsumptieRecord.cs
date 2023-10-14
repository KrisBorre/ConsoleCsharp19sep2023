using System;
using System.Globalization;

namespace WindowsFormsFrameworkConsumptiePrijsIndex14oct2023
{
    internal class ConsumptieRecord
    {
        public string StringJaar { private get; set; }

        public int Jaar
        {
            get
            {
                int result = Convert.ToInt32(StringJaar);
                return result;
            }
        }

        public string StringMaand { private get; set; }

        public int Maand
        {
            get
            {
                int result = Convert.ToInt32(StringMaand);
                return result;
            }
        }

        /// <summary>
        /// is overal ingevuld
        /// </summary>
        public string StringConsumptieprijsindex { private get; set; }

        public double Consumptieprijsindex
        {
            get
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                double result = Convert.ToDouble(StringConsumptieprijsindex, provider);
                return result;
            }
        }

        /// <summary>
        /// is ingevuld vanaf 2006
        /// </summary>
        public string Index_zonder_energetische_producten { get; set; }

        /// <summary>
        /// is ingevuld vanaf 1997
        /// </summary>
        public string Index_zonder_petroleum_producten { get; set; }

        public string StringWeging { private get; set; }

        public int Weging
        {
            get
            {
                int result = Convert.ToInt32(StringWeging);
                return result;
            }
        }


        /// <summary>
        /// is overal ingevuld.
        /// </summary>
        public string Inflatie { get; set; }

        /// <summary>
        /// is ingevuld vanaf 1994
        /// </summary>
        public string Gezondheidsindex { get; set; }

        public string Afgevlakte_gezondheidsindex { get; set; }

        public string StringBasisjaar { get; set; }

        public int Basisjaar
        {
            get
            {
                int result = Convert.ToInt32(StringBasisjaar);
                return result;
            }
        }
    }
}

