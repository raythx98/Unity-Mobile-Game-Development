using UnityEngine;

public class StartRandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    private bool playedWind = true;
    public AudioSource windSong;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

    void Start()
    {
        Destroy(GameObject.Find("GameBGM"));
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying && !windSong.isPlaying)
        {
            if (playedWind)
            {
                //Invoke("PlayRandom", 0f);
                PlayRandom();
            } else
            {
                windSong.Play();
                playedWind = true;
            }
        }
    }

    void PlayRandom()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        playedWind = false;
    }
}
