using System.Collections;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private static RandomAudio instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(ExecuteAfterTime(0.5f));
        }
    }

    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting) {} 
        else
        {
            isCoroutineExecuting = true;
            yield return new WaitForSeconds(time);
            PlayRandom();
            isCoroutineExecuting = false;
        }
    }

    void PlayRandom()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
