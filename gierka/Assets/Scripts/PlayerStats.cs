using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{

   [Range(0, 20)] public float PlJoy = 10;
   [Range(0, 20)] public float PlHunger = 0;
   [Range(0, 20)] public float PlTired = 0;
   [Range(0, 20)] public float PlKnow = 0;
   [Range(0, 20)] public float PlLuck = 10;
   private const float MinSpeed = 1;
   private const float DtHunger = 1f;
   private const float DtTired = 0.01f;
   private const float DtKnow = 0.01f;

    public float Score = 0f;

   public void UpdateStats()
   {
       PlHunger -= DtHunger * Time.deltaTime;
       if (PlHunger < 0) PlHunger = 0;
       PlTired -= DtTired * Time.deltaTime;
       if (PlTired < 0) PlTired = 0;
       PlKnow -= DtKnow * Time.deltaTime;
       if (PlKnow < 0) PlKnow = 0;
       Debug.Log(GetSpeed());
    }

    public void Eat(float value)
    {
        PlHunger = Mathf.Min(PlHunger + value, 20);
    }

    public void Learn(float value)
    {
        PlKnow = Mathf.Min(PlKnow + value, 20);
    }

    public void BeHappy(float value)
    {
        PlJoy = Mathf.Min(PlJoy + value, 20);
    }

    public void Rest(float value)
    {
        PlTired = Mathf.Min(PlTired + value, 20);
    }

    public float GetSpeed()
    {
        return MinSpeed * (1 + PlHunger / 100) * (1 + PlTired / 100);
    }

   public float GetGrade()
   {
       float randLuck = Random.Range(PlLuck/4, PlLuck);
       return 2 * (1 + PlHunger/100) * (1 + PlTired/100) * (1 + PlJoy/100) * (1 + PlKnow/100) * (1 + randLuck / 100);
   }
}