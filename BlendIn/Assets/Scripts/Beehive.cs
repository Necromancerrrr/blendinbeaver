using UnityEngine;

public class Beehive : MonoBehaviour
{

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
        bear.CountBeehives();
    }
}
