using UnityEngine;
using Yarn.Unity;

public class ResumeDialogueOnReturn : MonoBehaviour
{
    private void Start()
    {
        if (!string.IsNullOrEmpty(GameManager.Instance.resultNodeAfterMinigame))
        {
            FindFirstObjectByType<DialogueRunner>().StartDialogue(GameManager.Instance.resultNodeAfterMinigame);
            GameManager.Instance.resultNodeAfterMinigame = null; // Reset
        }
    }
}