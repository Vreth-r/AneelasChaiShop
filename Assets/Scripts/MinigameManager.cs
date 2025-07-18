using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public void OnTeaPrepared(string playerTea)
    {
        if (playerTea == GameManager.Instance.expectedTea)
        {
            Debug.Log("Correct tea");
            // sfx go here
            GameManager.Instance.EndDay();
        }
        else
        {
            Debug.Log("Wrong tea");
            // restart here prob script doesnt say
        }
        SceneManager.LoadScene("Story");
    }
}