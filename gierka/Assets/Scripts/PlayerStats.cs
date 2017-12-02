using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
   [Range(0, 20)] public float PlJoy = 20;
   [Range(0, 20)] public float PlHunger = 20;
   [Range(0, 20)] public float PlTired = 20;
   [Range(0, 20)] public float PlKnow = 20;
   [Range(0, 20)] public float PlLuck = 20;
   private const float MinSpeed = 1;
   private const float DtHunger = 0.01f;
   private const float DtTired = 0.01f;

   void UpdateStats()
   {
       PlHunger -= DtHunger * Time.deltaTime;
       if (PlHunger < 0) PlHunger = 0;
       PlTired -= DtTired * Time.deltaTime;
       if (PlTired < 0) PlTired = 0;
   }

   public float GetSpeed()
   {
       return MinSpeed * (1 + PlHunger / 100) * (1 + PlTired / 100);
   }

   public float GetGrade(string subject)
   {
       float randLuck = Random.Range(PlLuck/4, PlLuck);
       return 2 * (1 + PlHunger/100) * (1 + PlTired/100) * (1 + PlJoy/100) * (1 + PlKnow/100) * (1 + randLuck / 100);
   }
}