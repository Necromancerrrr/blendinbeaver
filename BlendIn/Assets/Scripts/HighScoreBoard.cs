using TMPro;
using UnityEngine;

public class HighScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = MainManager.Instance.highScore.ToString();
    }
}
