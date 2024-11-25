using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomObjectSpanner : MonoBehaviour
{
    [SerializeField] private GameObject floor1;
    [SerializeField] private GameObject floor2;
    [SerializeField] private GameObject player;

    // Obstacles
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject bookOfWisdom;
    [SerializeField] private GameObject timeAdder;
    [SerializeField] private GameObject timeReducer;

    private int maxObstacles = 10;
    private GameObject[] floorArray;
    private GameObject[] obstaclesArray;
    private static Dictionary<int, GameObject> currentObstacles;
    private System.DateTime nextWaitTime;

    void Start()
    {
        floorArray = new GameObject[2] { floor1, floor2 };
        obstaclesArray = new GameObject[5] { enemy, health, timeAdder, timeReducer, bookOfWisdom };

        currentObstacles = new Dictionary<int, GameObject>();
        nextWaitTime = System.DateTime.Now;
    }
    

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new();

        if(currentObstacles.Count >= this.maxObstacles || PlayerHealthDataStore.getInstance().isPlayerDead())
        {
            return;
        }

        if(currentObstacles.Count < 2)
        {
            for (int i = 0; i < 2 - currentObstacles.Count; i++)
            {
                GameObject defaultObstacle = Instantiate(obstaclesArray[rnd.Next(obstaclesArray.Length)]);
                defaultObstacle.transform.position = GetRandomPositionOnPlane(floorArray[Random.Range(0, 2)]);
                defaultObstacle.SetActive(true);

                currentObstacles.Add(defaultObstacle.GetInstanceID(), defaultObstacle);
            }

        }

        if (nextWaitTime > System.DateTime.Now)
        {
            return;
        }


        GameObject newObstacle = Instantiate(obstaclesArray[rnd.Next(obstaclesArray.Length)]);
        newObstacle.transform.position = GetRandomPositionOnPlane(floorArray[Random.Range(0, 2)]);
        newObstacle.SetActive(true);

        currentObstacles.Add(newObstacle.GetInstanceID(), newObstacle);
        nextWaitTime = System.DateTime.Now.AddSeconds(Random.Range(5, 10));
    }

    public static void removeObstacle(GameObject obstacle)
    {
        currentObstacles.Remove(obstacle.GetInstanceID());
        Destroy(obstacle);
    }

    private Vector3 GetRandomPositionOnPlane(GameObject planeGameObject, float minDistanceFromPlayer = 5f, float borderOffsetPercentage = 0.1f, int maxAttempts = 30)
    {
        MeshRenderer planeRenderer = planeGameObject.GetComponent<MeshRenderer>();
        Vector3 planeSize = planeRenderer.bounds.size;

        float borderOffsetX = planeSize.x * borderOffsetPercentage;
        float borderOffsetZ = planeSize.z * borderOffsetPercentage;

        for (int i = 0; i < maxAttempts; i++)
        {
            float randomX = Random.Range(-planeSize.x / 2 + borderOffsetX, planeSize.x / 2 - borderOffsetX);
            float randomZ = Random.Range(-planeSize.z / 2 + borderOffsetZ, planeSize.z / 2 - borderOffsetZ);

            Vector3 randomPosition = planeGameObject.transform.position + planeGameObject.transform.rotation * new Vector3(randomX, 0, randomZ);

            if (Vector3.Distance(randomPosition, player.transform.position) >= minDistanceFromPlayer)
            {
                return randomPosition;
            }
        }

        Debug.LogWarning("Could not find a position far enough from the player after " + maxAttempts + " attempts.");
        return planeGameObject.transform.position;
    }
}
