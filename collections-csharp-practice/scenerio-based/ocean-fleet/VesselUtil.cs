using System;
using System.Collections.Generic;
namespace OceanFleetApp;


class VesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();

    // Add vessel to list
    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    // Search vessel by ID
    public Vessel GetVesselById(string vesselId)
    {
        foreach (Vessel v in vesselList)
        {
            if (v.VesselId == vesselId) // case sensitive
                return v;
        }
        return null;
    }

    // Get vessels with highest speed
    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();

        if (vesselList.Count == 0)
            return result;

        double maxSpeed = vesselList[0].AverageSpeed;

        // find max speed
        foreach (Vessel v in vesselList)
        {
            if (v.AverageSpeed > maxSpeed)
                maxSpeed = v.AverageSpeed;
        }

        // collect vessels with max speed
        foreach (Vessel v in vesselList)
        {
            if (v.AverageSpeed == maxSpeed)
                result.Add(v);
        }

        return result;
    }
}