using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PrologText : MonoBehaviour
{
    public Text prologText;
    public string fullText = @" Di suatu wilayah tinggal seorang keluarga, kepala keluarga tersebut memiliki kekuatan mistis. 
Suatu ketika malapetaka menimpa keluarga tersebut.
Jiwa anaknya telah dibawa ke dimensi lain. 
Mengetahui hal tersebut ayahnya berusaha menyelamatkan anaknya dengan masuk dimensi lain";
    public float delay = 0.1f;
    public GameObject continueTextObj; // The "klik untuk melanjutkan" text object
    public string nextSceneName = "Phase1"; // The name of the scene to load
    private string currentText;
    private bool isPrologFinished = false; // Define the variable here

    private CanvasGroup continueTextCanvasGroup; // Add a reference to the CanvasGroup component

    void Start()
    {
        continueTextCanvasGroup = continueTextObj.GetComponent<CanvasGroup>();
        StartCoroutine(ShowText());
        continueTextObj.SetActive(false); // Hide the "klik untuk melanjutkan" text at the start
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            prologText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        continueTextObj.SetActive(true); // Show the "klik untuk melanjutkan" text when the full text has been displayed
        isPrologFinished = true; // Set isPrologFinished to true here

        // Fade in the continueTextObj
        continueTextCanvasGroup.alpha = 0f;
        while (continueTextCanvasGroup.alpha < 1f)
        {
            continueTextCanvasGroup.alpha += Time.deltaTime * 2f; // Adjust the fade-in speed here
            yield return null;
        }

        // Start the pulsing effect
        StartCoroutine(PulseContinueText());
    }

    IEnumerator PulseContinueText()
    {
        while (true)
        {
            // Fade out
            while (continueTextCanvasGroup.alpha > 0.2f)
            {
                continueTextCanvasGroup.alpha -= Time.deltaTime * 1f; // Adjust the fade-out speed here
                yield return null;
            }

            // Fade in
            while (continueTextCanvasGroup.alpha < 1f)
            {
                continueTextCanvasGroup.alpha += Time.deltaTime * 1f; // Adjust the fade-in speed here
                yield return null;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && continueTextObj.activeSelf && isPrologFinished) // Check if the left mouse button is clicked and the "klik untuk melanjutkan" text is active
        {
            // Stop the pulsing effect
            StopCoroutine(PulseContinueText());

            // Fade out the continueTextObj before loading the next scene
            StartCoroutine(FadeOutContinueText());
        }
    }

    IEnumerator FadeOutContinueText()
    {
        while (continueTextCanvasGroup.alpha > 0f)
        {
            continueTextCanvasGroup.alpha -= Time.deltaTime * 2f; // Adjust the fade-out speed here
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName); // Load the specified scene
    }
}