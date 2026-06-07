using UnityEngine;

public class Beehive : MonoBehaviour
{
    [SerializeField] private GameObject honeySplatParticles;

    [SerializeField] private Rigidbody rb;

    private AgentBehaviour bear;
    private BeeHiveSpawner beehiveSpawner;

    [HideInInspector] public int hiveNumber;

    [SerializeField] private bool tutorial = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        bear = FindAnyObjectByType<AgentBehaviour>();
        beehiveSpawner = FindAnyObjectByType<BeeHiveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnDestroy()
    {
        if (!tutorial)
        {
            beehiveSpawner.OnBeehiveDestroyed(hiveNumber);
        }
        
        Instantiate(honeySplatParticles, transform.position, Quaternion.identity);
    }
}
