using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom1>().LoadLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Game exited!");
        Application.Quit();
    }
}
