using System;

namespace SpacePark
{
    public interface IVehicle
    {
        DateTime Arrival { get; set; }
        int Id { get; set; }
        double ShipLength { get; set; }
        string StarShipModel { get; set; }
    }
}