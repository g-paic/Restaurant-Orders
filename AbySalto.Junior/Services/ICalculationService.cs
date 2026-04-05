namespace AbySalto.Junior.Services
{
    public interface ICalculationService
    {
        public void CalculateOrderTotalPrice(int orderId);
        public void CalculateBasePrice(int orderId);
    }
}
