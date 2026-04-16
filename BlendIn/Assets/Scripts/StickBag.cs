using UnityEngine;

public class StickBag : MonoBehaviour
{
    // reference to player
    [SerializeField] private Transform playerCameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, playerCameraPosition.position.y/3, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {

            //animate it getting smaller?
            Destroy(collision.gameObject);
            Instantiate(collision.gameObject, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
