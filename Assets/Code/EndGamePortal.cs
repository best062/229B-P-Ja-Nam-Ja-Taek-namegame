using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndGamePortal : MonoBehaviour
{
    [Header("Scene Transition")]
    public string creditSceneName = "End";
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Teleporting to End Credit...");
            SceneManager.LoadScene(creditSceneName);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Press 'F' to finish the game.");
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}