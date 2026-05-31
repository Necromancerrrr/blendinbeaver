using UnityEngine;

public class Beehive : MonoBehaviour
{
    [SerializeField] private GameObject honeySplatParticles;

    [SerializeField] private Rigidbody rb;

    private AgentBehaviour bear;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        bear = FindAnyObjectByType<AgentBehaviour>();
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
            gameObject.tag = "Untagged";
            bear.CountBeehives();
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnDestroy()
    {
        Instantiate(honeySplatParticles, transform.position, Quaternion.identity);
        bear.CountBeehives();
    }
}
