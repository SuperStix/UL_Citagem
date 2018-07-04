using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    //crincle sound found here: http://freesound.org/people/volivieri/sounds/37171/

    public AudioClip crincleAudioClip;
    public AudioClip slide2AudioClip;
    public AudioClip slide10AudioClip;
    public AudioClip slide26AudioClip;
    AudioSource crincle;
    AudioSource slide2;
    AudioSource slide10;
    AudioSource slide26;



    void Awake()
    {
        crincle = AddAudio(crincleAudioClip);
        slide2 = AddAudio(slide2AudioClip);
        slide10 = AddAudio(slide10AudioClip);
        slide26 = AddAudio(slide26AudioClip);
    }

    AudioSource AddAudio( AudioClip audioClip)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = audioClip;
        return audioSource;
    }

    public void PlayCrincle()
    {
        crincle.Play();
    }

    public void PlaySoundSlide2()
    {
        slide2.Play();
    }
    public void PlaySoundSlide10()
    {
        slide10.Play();
    }
    public void PlaySoundSlide26()
    {
        slide26.Play();
    }

}
