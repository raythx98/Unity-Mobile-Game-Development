using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject WinGameUI;
    public GameObject pauseMenuUI;
    public GameObject panelUI;
    public GameObject PauseButton;
    public GameObject winText;
    public GameObject loseText;

    public static string scene = "Level01";
    public static bool GameIsPaused = false;
    public Slider slider;

    void Start()
    {
        Destroy(GameObject.Find("StartAudio"));
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.01f;
        GameIsPaused = true;
    }

    public void WinGame()
    {
        panelUI.SetActive(true);
        WinGameUI.SetActive(true);
        PauseButton.SetActive(false);
        winText.SetActive(true);
    }

    public void LoseGame()
    {
        panelUI.SetActive(true);
        WinGameUI.SetActive(true);
        PauseButton.SetActive(false);
        loseText.SetActive(true);
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
