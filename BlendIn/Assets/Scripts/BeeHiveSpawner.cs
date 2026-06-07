using UnityEngine;

public class BeeHiveSpawner : MonoBehaviour
{
    [SerializeField] GameObject beehiveObject;

    [SerializeField] GameObject[] beehiveSpawnPoints = new GameObject[6]; // will be the points the bear travels to
    [SerializeField] private bool[] beeHiveSpawnPointsTaken = new bool[6];

    [SerializeField] int numberOfBeehiveSpawnPoints = 6;
    [SerializeField] int initialBeehivesSpawned = 4;

    private void Awake()
    {
        
    }

    void Start()
    {
        for (int i = 0; i < initialBeehivesSpawned; i++) // spawn x beehives at random locations
        {
            SpawnBeehive();
        }
    }

    private void SpawnBeehive()
    {
        int randSpawnPoint = Random.Range(0, numberOfBeehiveSpawnPoints);

        while (beeHiveSpawnPointsTaken[randSpawnPoint] == true)
        {
            randSpawnPoint = Random.Range(0, numberOfBeehiveSpawnPoints);
        }

        Instantiate(beehiveObject, beehiveSpawnPoints[randSpawnPoint].transform.position, Quaternion.identity).GetComponent<Beehive>().hiveNumber = randSpawnPoint; // assign number to beehive

        beeHiveSpawnPointsTaken[randSpawnPoint] = true;
    }

    public void OnBeehiveDestroyed(int hiveNumber)
    {
        SpawnBeehive();

        beeHiveSpawnPointsTaken[hiveNumber] = false;
    }


    // on start choose half of the points to spawn beehives

    // then whenever a beehive is destroyed

    // randomly choose another spot to spawn another
}
