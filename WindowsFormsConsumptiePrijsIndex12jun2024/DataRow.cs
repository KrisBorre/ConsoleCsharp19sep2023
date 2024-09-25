namespace WindowsFormsConsumptiePrijsIndex12jun2024
{
    internal class DataRow
    {
        public string Date { get; set; }
        public string CpiIndex { get; set; }
        public string WithoutEnergyIndex { get; set; }
        public string WithoutPetroleumIndex { get; set; }
        public string Inflation { get; set; }
        public string HealthIndex { get; set; }
        public string BasisJaar { get; set; }

        public DataRow(string date, string cpiIndex, string withoutEnergyIndex, string withoutPetroleumIndex, string inflation, string healthIndex, string basisJaar)
        {
            Date = date;
            CpiIndex = cpiIndex;
            WithoutEnergyIndex = withoutEnergyIndex;
            WithoutPetroleumIndex = withoutPetroleumIndex;
            Inflation = inflation;
            HealthIndex = healthIndex;
            BasisJaar = basisJaar;
        }
    }
}
