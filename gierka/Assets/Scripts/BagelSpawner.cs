using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagelSpawner : MonoBehaviour
{
    public GameObject BagelPrefab;
    public float BagelRespawn;
    private List<BagelSpawnArea> Terrains;

    void Start()
    {
        Terrains = new List<BagelSpawnArea>();
        Terrains.AddRange(FindObjectsOfType<BagelSpawnArea>());
    }
    
    public void CreateBagel()
    {
        int item = Random.Range(0, Terrains.Count - 1);
        BagelSpawnArea terrain = Terrains[item];
        float Xmin = terrain.transform.position.x - terrain.transform.localScale.x / 50;
        float Xmax = terrain.transform.position.x + terrain.transform.localScale.x / 50;
        float Ymin = terrain.transform.position.y - terrain.transform.localScale.y / 50;
        float Ymax = terrain.transform.position.y + terrain.transform.localScale.y / 50;
        
        Vector3 position = new Vector3(Random.Range(Xmin, Xmax), Random.Range(Ymin, Ymax), 0);
        Debug.Log(position);
        Instantiate(BagelPrefab, position, Quaternion.identity);
    }
}
