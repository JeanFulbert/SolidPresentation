namespace SolidPresentation.DIP._Good.Interfaces
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Model;

    public interface IReservationService
    {
        void ReserveInventory(IReadOnlyCollection<OrderLine> items);
    }
}