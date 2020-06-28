using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static string scene = "Level01";
    public Slider slider;

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Level02");
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom2>().LoadLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Game exited!");
        Application.Quit();
    }
}
