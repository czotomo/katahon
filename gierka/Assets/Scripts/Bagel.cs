using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Bagel : MonoBehaviour
{
    public PlayerController Player;
    public static float Value = 2;
    public static float FreshTime = 100;
    private float expiryTime;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == Player)
        {
            Player.PlayerStats.Eat(Value);
            Destroy(this, 0.5f);
        }
    }

    void Start()
    {
        transform.rotation = Player.transform.rotation;
        expiryTime = Time.time + FreshTime;
    }

    void Update()
    {
        if (Time.time > expiryTime) Destroy(this);
    }
}