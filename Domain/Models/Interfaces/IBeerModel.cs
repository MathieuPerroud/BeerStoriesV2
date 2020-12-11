namespace Domain.Models.Interfaces
{
    public interface IBeerModel
    {
        void IncreaseStock(int amount);

        void DecreaseStock(int amount);
    }
}