namespace SolidPresentation.DIP._Good.Services
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.DIP.Common;
    using SolidPresentation.DIP.Exceptions;
    using SolidPresentation.DIP.Model;
    using SolidPresentation.DIP._Good.Interfaces;

    public class ReservationService : IReservationService
    {
        public void ReserveInventory(IReadOnlyCollection<OrderLine> items)
        {
            foreach (var item in items)
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.Sku, item.Quantity);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }
}