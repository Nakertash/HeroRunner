using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    private static TerrainController instance;
    [Header("Части ландшафта")]
    [SerializeField] private List<Terrain> Terrains = new List<Terrain>();
    [Header("---------------")]
    [SerializeField] private float SpawnDelay=1;
    [SerializeField] private float SwitchDelayMin = 3;
    [SerializeField] private float SwitchDelayMax = 5;
    [SerializeField] private float SwitchDelay = 4;
    [SerializeField] private Transform SpawnPosition;
    [SerializeField] private int Speed = 10;
    [SerializeField] private List<GameObject> TerrainObjects = new List<GameObject>();
    private float SpawnTimer = 0;
    private int Height=0;
    private void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            if(this!=instance)
            {
                Destroy(this.gameObject);
            }
        }

        SpawnTimer = SpawnDelay;

    }

    private void FixedUpdate()
    {

        SpawnTimer -= Time.fixedDeltaTime;
        
        if(SpawnTimer<=0)
        {
            SpawnTimer = SpawnDelay;
            SpawnTerrainObject();
        }

        for(int i=0;i< TerrainObjects.Count;i++)
        {
            TerrainObjects[i].transform.position = Vector3.MoveTowards(TerrainObjects[i].transform.position, TerrainObjects[i].transform.position + Vector3.left, Speed * Time.fixedDeltaTime);
        }
    }

    private void SpawnTerrainObject()
    {
        GameObject TO= Instantiate(Terrains[0].Plain,SpawnPosition.position,Quaternion.identity);
        TerrainObjects.Add(TO);
        SwitchDelay -= 1;
        if(SwitchDelay<=0)
        {
            System.Random rnd = new System.Random();
            SwitchDelay = UnityEngine.Random.Range(SwitchDelayMin, SwitchDelayMax);
            //Переключение высот
        }
    }

    public static void DestroyTerrainObject(GameObject terrainObject)
    {
        if(instance!=null)
        {
            instance._DestroyTerrainObject(terrainObject);
        }
        else
        {
            Debug.LogError("[TerrainController] ERROR instance is null");
        }
    }

    private void _DestroyTerrainObject(GameObject terrainObject)
    {
        TerrainObjects.Remove(terrainObject);
        Destroy(terrainObject);
        //Debug.Log($"{terrainObject.name} was deleted");
    }
}


[System.Serializable]
public class Terrain
{
    public GameObject Plain;
    public GameObject Downhill;
    public GameObject Uphill;
}