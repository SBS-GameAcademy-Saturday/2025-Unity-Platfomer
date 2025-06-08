using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource introSource;
    [SerializeField] private AudioSource loopSource;

    void Start()
    {
        introSource.Play();
        loopSource.PlayScheduled(introSource.clip.length + AudioSettings.dspTime);

    }

}
