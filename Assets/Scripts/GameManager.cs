using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string expectedTea;
    public string resultNodeAfterMinigame;
    public SpriteRenderer character;
    public int currentDay = 1;

    private DialogueRunner runner;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(character.gameObject);
        SceneTransitionManager.Instance.TransitionToScene("Story");
        // Register to listen for scene load events after the menu (for now)
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Gets called every time a new scene finishes loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // We wait a single frame to ensure DialogueRunner is initialized
        if (scene.name == "Story")
        {
            character.gameObject.SetActive(true);
            StartCoroutine(StartDialogueAfterSceneReady());
        }
        else if (scene.name == "Minigame")
        {
            character.gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator StartDialogueAfterSceneReady()
    {
        // Wait one frame to ensure all scene Start() methods have run
        yield return null;

        runner = FindFirstObjectByType<DialogueRunner>();
        if (runner != null && string.IsNullOrEmpty(resultNodeAfterMinigame))
        {
            runner.StartDialogue($"Day{currentDay}");
        }
        else if (runner != null && !string.IsNullOrEmpty(resultNodeAfterMinigame))
        {
            runner.StartDialogue(resultNodeAfterMinigame);
            resultNodeAfterMinigame = null;
        }
    }

    public void EndDay()
    {
        resultNodeAfterMinigame = $"Day{currentDay}Post";
        currentDay++;
    }

    public void SetCharacter(string c)
    {
        Sprite sprite = Resources.Load<Sprite>($"Characters/{c}");

        if (sprite != null)
            character.sprite = sprite;
        else
            Debug.LogWarning($"Character sprite '{c}' not found.");
    }
}
