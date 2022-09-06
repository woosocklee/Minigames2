using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource AudioSource;

    private AudioReverbZone ARZ;

    void Start()
    {
        this.AudioSource = this.gameObject.GetComponent<AudioSource>();
        this.ARZ = this.gameObject.GetComponent<AudioReverbZone>();
    }


    void soundtest()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StopNPlay(audioClips[0]);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound_Loop(audioClips[1]);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopNPlay(audioClips[2]);
        }
    }

    void StopNPlay(AudioClip clip)
    {
        //AudioSource.loop = false;
        AudioSource.Stop();
        AudioSource.clip = clip;
        AudioSource.Play();
    }

    void PlaySound_Loop(AudioClip clip)
    {
        if (AudioSource.isPlaying)
        {
            AudioSource.loop = false;
            return;
        }
        AudioSource.loop = true;
        AudioSource.clip = clip;
        AudioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        soundtest();
    }

    private void OnTriggerEnter(Collider other)
    {
        this.ARZ.reverbPreset = AudioReverbPreset.Cave;
    }

    private void OnTriggerExit(Collider other)
    {
        this.ARZ.reverbPreset = AudioReverbPreset.Generic;
    }
}
