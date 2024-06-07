using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
