using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class YarnBridge_Story : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // cheeky fix lmao
    }

    [YarnCommand("loadMinigame")]
    public void LoadMinigame()
    {
        SceneManager.LoadScene("Minigame");
    }

    [YarnCommand("endDay")]
    public void EndDay()
    {
        // logic and knowledge are the personal ever-goals of a human mind, 
        // however, the strength that one cultivates was meant to be given to his fellow man.
    }
}

