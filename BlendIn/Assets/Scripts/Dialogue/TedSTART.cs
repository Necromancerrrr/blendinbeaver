
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TEDInstructions : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public Player BlendIn;
    public FieldOfView inFOV;
    public CharacterTextBox TedDialogue;

    public bool isTutorial = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isTutorial)
        {
            TedDialogue.SetText("Hey there, I'm Ted! Press me when you're ready to explore the real forest!", 10.0f);
        }
        else
        {
            TedDialogue.SetText("Hey! Be sure to bring me back as much wood as you can. Good luck, and don’t forget to Blend in, Beaver!", 10.0f);
        }

    }

    public void TedSelected()
    {
        SceneManager.LoadScene("BasicScene");
    }
}
