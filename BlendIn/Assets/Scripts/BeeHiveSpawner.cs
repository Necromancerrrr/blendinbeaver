using UnityEngine;

public class BeeHiveSpawner : MonoBehaviour
{
    [SerializeField] GameObject beehiveObject;

    [SerializeField] GameObject[] beehiveSpawnPoints = new GameObject[6]; // will be the points the bear travels to
    private bool[] beeHiveSpawnPointsTaken = new bool[6];

    void Start()
    {
        for (int i = 0; i < 4; i++) // spawn 4 beehives at random locations
        {
            SpawnBeehive();
        }
    }

    private void SpawnBeehive()
    {
        int randSpawnPoint = Random.Range(0, 6);

        while (beeHiveSpawnPointsTaken[randSpawnPoint] == true)
        {
            randSpawnPoint = Random.Range(0, 6);
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
