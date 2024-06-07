using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button settingButton;
    public Button startButton;

    void Start()
    
    {
        // Pastikan button setting terhubung dengan method OnSettingGame di dalam OnClick
        settingButton.onClick.AddListener(OnSettingGame);
        startButton.onClick.AddListener(OnStartGame);
    }

    void OnSettingGame()
    {
        // Memuat scene Setting
        SceneManager.LoadScene("Setting");
    }
    void OnStartGame()
    {
        // Memuat scene Phase1
        SceneManager.LoadScene("Phase1");
    }




}
