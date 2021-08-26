using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public Transform SpawnPosition;

    public float Timer = 0;

    public float SpawnTime = 1;

    public List<MyOwnObstacle> myOwnObstacles= new List<MyOwnObstacle>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer<=0)
        {
            Timer = SpawnTime;
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        System.Random rnd = new System.Random();
        int chance = rnd.Next(0,100);
        MyOwnObstacle obstacle = null;

        foreach(var obs in myOwnObstacles)
        {
            if(obs.Chance>=chance)
            {
                obstacle = obs;
                break;
            }
        }
        if(obstacle!=null)
        {
            Instantiate(obstacle.Prefab, SpawnPosition.position, Quaternion.identity);

        }
        else
        {
            Debug.Log("Obstacle is not found");
        }

    }
}

[System.Serializable]
public class MyOwnObstacle
{
    public int Chance;
    public GameObject Prefab;
}