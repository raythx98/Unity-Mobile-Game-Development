using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom1>().LoadLevel("Level02");
    }

    public void Play2ndGame()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom1>().LoadLevel("Level03");
    }

    public void Play3rdGame()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderFrom1>().LoadLevel("Level04");
    }
    
}
