using TMPro;
using UnityEngine;
using DG.Tweening;

public class StickBag : MonoBehaviour
{
    // reference to player
    [SerializeField] private Transform playerCameraPosition;

    [SerializeField] private Player player;

    [SerializeField] private TMP_Text leftHandScore;
    [SerializeField] private TMP_Text rightHandScore;

    [SerializeField] private GameObject stick1;
    [SerializeField] private GameObject stick2;
    [SerializeField] private GameObject stick3;


    [SerializeField] private StickSpawner stickSpawner;

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
            if (collision.gameObject.name[0] == 'L') // Low
            {
                player.score += 10;
            }
            else if (collision.gameObject.name[0] == 'M') // Medium
            {
                player.score += 20;
            }
            else if (collision.gameObject.name[0] == 'H') // High
            {
                player.score += 30;
            }

            leftHandScore.text = player.score.ToString();
            rightHandScore.text = player.score.ToString();

            DOTween.Kill("killStick");

            collision.gameObject.transform.DOMove(transform.position, 0.5f).SetId("killStick");
            collision.gameObject.transform.DOScale(0f, 0.5f).SetEase(Ease.InCubic).SetId("killStick").OnComplete(() =>
            {
                Destroy(collision.gameObject);
            });

            stickSpawner.numberOfSticks -= 1;
        }
    }
}
