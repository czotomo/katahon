using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [Range(0, 20)] public float PlJoy = 20;
    [Range(0, 20)] public float PlHunger = 20;
    [Range(0, 20)] public float PlTired = 20;
    [Range(0, 20)] public float PlKnow = 20;
    [Range(0, 20)] public float PlLuck = 20;
    private float minSpeed = 10;

    public float GetSpeed()
    {
        return minSpeed * (1 + PlHunger / 100) * (1 + PlTired / 100);
    }
}