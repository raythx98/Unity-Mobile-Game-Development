using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.GameIsPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom2>().LoadLevel();
    }

    public void Quit() 
    {
        Debug.Log("Game exited!");
        Application.Quit();
    }
}
