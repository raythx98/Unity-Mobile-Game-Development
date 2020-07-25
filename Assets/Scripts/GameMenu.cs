using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public static string scene = "Level01";
    public Slider slider;
    public TMP_Text score;
    public TMP_Text highScore;

    private void Start()
    {
        switch (GameObject.Find("gameCanvas").GetComponent<GameManager>().game)
        {
            case "Battle":
                int score = GameObject.Find("gameCanvas").GetComponent<GameManager>().score;
                this.score.text = score.ToString();
                if (score > PlayerPrefs.GetInt("HighScoreBattle", 0))
                {
                    PlayerPrefs.SetInt("HighScoreBattle", score);
                    highScore.text = score.ToString();
                } else
                {
                    highScore.text = PlayerPrefs.GetInt("HighScoreBattle", 0).ToString();
                }
                break;
            case "Treasure":
                int score2 = GameObject.Find("gameCanvas").GetComponent<GameManager>().score;
                this.score.text = score2.ToString();
                if (score2 > PlayerPrefs.GetInt("HighScoreTreasure", 0))
                {
                    PlayerPrefs.SetInt("HighScoreTreasure", score2);
                    highScore.text = score2.ToString();
                } else
                {
                    highScore.text = PlayerPrefs.GetInt("HighScoreTreasure", 0).ToString();
                }
                break;
            case "Survival":
                int score3 = GameObject.Find("gameCanvas").GetComponent<GameManager>().score;
                this.score.text = score3.ToString();
                if (score3 > PlayerPrefs.GetInt("HighScoreSurvival", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score3);
                    highScore.text = score3.ToString();
                } else
                {
                    highScore.text = PlayerPrefs.GetInt("HighScoreSurvival", 0).ToString();
                }
                break;
        }
        
    }

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
