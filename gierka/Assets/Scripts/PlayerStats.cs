using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    [Range(0, 20)] public double PlJoy = 20;
    [Range(0, 20)] public double PlHunger = 20;
    [Range(0, 20)] public double PlTired = 20;
    [Range(0, 20)] public double PlKnow = 20;
    [Range(0, 20)] public double PlLuck = 20;
    private double minSpeed = 1;

    public double GetSpeed()
    {
        return minSpeed * (1 + PlHunger / 100) * (1 + PlTired / 100);
    }
}