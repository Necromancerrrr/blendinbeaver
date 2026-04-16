using TMPro;
using UnityEngine;

public class StickBag : MonoBehaviour
{
    // reference to player
    [SerializeField] private Transform playerCameraPosition;

    [SerializeField] private Player player;

    [SerializeField] private TMP_Text leftHandScore;
    [SerializeField] private TMP_Text rightHandScore;

    [SerializeField] private GameObject testBranch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, playerCameraPosition.position.y / 3, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            player.score += 10;
            leftHandScore.text = player.score.ToString();
            rightHandScore.text = player.score.ToString();

            //animate it getting smaller?
            Destroy(collision.gameObject);
            Instantiate(testBranch, new Vector3(1, 1, 1), Quaternion.identity);
        }
    }
}
