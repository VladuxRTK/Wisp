using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public List<AudioClip> laserClip;
    public List<AudioClip> deathClip;
    public List<AudioClip> plaftormFallingClip;
    public List<AudioClip> buttonClickClip;
    public List<AudioClip> loadComplete;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "laserSound":
                audioSource.PlayOneShot(laserClip[Random.Range(0, laserClip.Count)]);
                break;
            case "laserDeathSound":
                audioSource.PlayOneShot(deathClip[0]);
                break;
            case "fallingPlatformSound":
                audioSource.PlayOneShot(plaftormFallingClip[0]);
                break;
            case "buttonClickSound":
                audioSource.PlayOneShot(buttonClickClip[Random.Range(0, buttonClickClip.Count)]);
                break;
            case "loadCompleteSound":
                audioSource.PlayOneShot(loadComplete[0]);
                break;

                //   case "deathEffectSound":

        }
    }
}
