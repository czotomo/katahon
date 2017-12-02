using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelSpawner : MonoBehaviour
{
    public static GameObject BagelPrefab;

    public static void CreateBagel(Vector2 position)
    {
        Instantiate(BagelPrefab, position, new Quaternion());
    }
}
