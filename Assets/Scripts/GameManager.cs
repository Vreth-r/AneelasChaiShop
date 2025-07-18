using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string expectedTea;
    public string resultNodeAfterMinigame;

    public int currentDay = 1; // initial value

    private DialogueRunner runner;

    private void Awake()
    {
        SceneManager.LoadScene("Story");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        runner = FindFirstObjectByType<DialogueRunner>();
        StartDay();
    }

    public void StartDay()
    {
        runner.StartDialogue($"Day{currentDay}");
    }

    public void EndDay()
    {
        if (runner == null)
        {
            runner = FindFirstObjectByType<DialogueRunner>();
        }
        runner.StartDialogue($"Day{currentDay}Post");
        currentDay++;
        // Load next scene or fade out and in
        //StartDay();
    }
}