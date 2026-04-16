using TMPro;
using UnityEngine;

public class CharacterTextBox : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    private float showUntil;

    void Start()
    {
        textBox = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Time.time > showUntil)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetText (string text, float duration)
    {
        gameObject.SetActive(true);
        textBox.text = text;
        showUntil = Time.time + duration;
    }

    public void SetText (string text)
    {
        SetText(text, 600);
    }
}
