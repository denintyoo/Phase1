using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void pause()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void setting()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void settingPause()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void QuitGame()
    {
        Debug.Log("EXIT!"); 
        Application.Quit();
    }
    
}
