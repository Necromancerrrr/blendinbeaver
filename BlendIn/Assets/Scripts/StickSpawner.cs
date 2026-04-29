using UnityEngine;

public class StickSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private int bounds = 30;

    [SerializeField] private GameObject[] sticks;

    [SerializeField] private int maxSticks = 20;
    public int numberOfSticks;

    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnRate) // every x seconds a stick will spawn
        {
            if (numberOfSticks != maxSticks) // if we aren't at max sticks spawn more
            {
                Instantiate(RandomStick(), RandomPosition(), Quaternion.identity);
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

    private Vector3 RandomPosition() // gets a random pos based on the bounds float
    {
        float xPos = Random.Range(-bounds, bounds);
        float zPos = Random.Range(-bounds, bounds);

        return new Vector3(xPos, 10, zPos);
    }

}
