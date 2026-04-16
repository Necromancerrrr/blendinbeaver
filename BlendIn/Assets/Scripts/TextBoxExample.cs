using UnityEngine;
public class TextBoxExample : MonoBehaviour
{
    private CharacterTextBox characterTextBox;
    void Start()
    {
        characterTextBox = GetComponentInChildren<CharacterTextBox>(true);
        // Have the textbox display a message for 10 seconds.
        characterTextBox.SetText("Hello, nice to meet you!", 10.0f);
    }
}