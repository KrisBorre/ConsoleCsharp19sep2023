namespace LibraryPhysicalUnits9feb2024
{
    public interface IWeight7feb2024
    {
        double GetInKilogram();
        double GetInTon();
        double GetInPounds();
        double GetPrecisionInKilogram();
        IWeight7feb2024 MultiplyBy(double factor);
    }

}
