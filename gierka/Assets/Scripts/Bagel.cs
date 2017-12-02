using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Bagel : MonoBehaviour
{
    public static PlayerController Player;
    public static float Value = 2;
    public static float FreshTime = 100;
    private float expiryTime;

    public static void Eat(GameObject obj)
    {
        Player.PlayerStats.Eat(Bagel.Value);
        Destroy(obj);
    }

    void Start()
    {
        //transform.rotation = Player.transform.rotation;
        Debug.Log(this.transform.position);
        expiryTime = Time.time + FreshTime;
    }

    void Update()
    {
        if (Time.time > expiryTime) Destroy(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            transform.position += (collision.gameObject.transform.position - transform.position);
        }
    }
}