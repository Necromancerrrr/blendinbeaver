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

    [SerializeField] private GameObject stick1;
    [SerializeField] private GameObject stick2;
    [SerializeField] private GameObject stick3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, playerCameraPosition.position.y / 3, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            //replace this if else with a for loop and have all sticks in a list/array
            if (collision.gameObject.name[0] == 'L')
            {
                player.score += 10;
            }
            else if (collision.gameObject.name[0] == 'M')
            {
                player.score += 20;
            }
            else if (collision.gameObject.name[0] == 'H')
            {
                player.score += 30;
            }

            leftHandScore.text = player.score.ToString();
            rightHandScore.text = player.score.ToString();

            //animate it getting smaller?
            Destroy(collision.gameObject);
        }
    }
}
