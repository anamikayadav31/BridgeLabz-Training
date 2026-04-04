
using System;
namespace OceanFleetApp;


class Vessel
{
    public string VesselId { get; set; }
    public string VesselName { get; set; }
    public double AverageSpeed { get; set; }
    public string VesselType { get; set; }

    // Constructor to assign values
    public Vessel(string id, string name, double speed, string type)
    {
        VesselId = id;
        VesselName = name;
        AverageSpeed = speed;
        VesselType = type;
    }
}