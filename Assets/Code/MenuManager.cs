using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Navigation")]
    public string gameplaySceneName = "GameplayScene"; 

    // ฟังก์ชันสำหรับปุ่ม Start
    public void PlayGame()
    {
        Debug.Log("Starting Game...");
        Time.timeScale = 1f; 
        SceneManager.LoadScene(gameplaySceneName);
    }

    // ฟังก์ชันสำหรับปุ่ม Exit
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); 
    }
}