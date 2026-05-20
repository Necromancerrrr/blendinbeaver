using UnityEngine;

public class StickSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRatePerSecond = 1f;

    [SerializeField] private int spawnBoundsAroundTree = 5;

    [SerializeField] private GameObject[] sticks;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private int maxSticks = 10;
    public int numberOfSticks;

    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnRatePerSecond) // every x seconds a stick will spawn
        {
            if (numberOfSticks != maxSticks) // if we aren't at max sticks spawn more
            {
                Instantiate(RandomStick(), RandomSpawnPoint(), RandomAngle());
                numberOfSticks += 1;
            }
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private GameObject RandomStick() // gets a random stick from the sticks array
    {
        return sticks[Random.Range(0, sticks.Length)];
    }

    private Vector3 RandomSpawnPoint()
    {
        Transform randPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        float randXPos = Random.Range(-spawnBoundsAroundTree, spawnBoundsAroundTree);
        float randZPos = Random.Range(-spawnBoundsAroundTree, spawnBoundsAroundTree);

        return new Vector3(randPoint.position.x + randXPos, 20, randPoint.position.z + randZPos);
    }

    private Quaternion RandomAngle()
    {
        return Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
    }

    /*
    private Vector3 RandomPosition() // gets a random pos based on the bounds float
    {
        float xPos = Random.Range(-bounds, bounds);
        float zPos = Random.Range(-bounds, bounds);

        return new Vector3(xPos, 20, zPos);
    }
    */
}
