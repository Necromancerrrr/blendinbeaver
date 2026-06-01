using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int highScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
