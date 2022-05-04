using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioClip[] walkAudioClips;
    [SerializeField] AudioSource walkAudioSource;
    [SerializeField] AudioClip[] gunAudioClips;
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioSource outsideAudioSource;

    public void SetGunAudio(int index)
    {
        gunAudioSource.clip = gunAudioClips[index];
    }

    public void PlayGunAudio()
    {
            gunAudioSource.Play();
    }



    public void WalkAudio()
    {
        if (!walkAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
    }

    public void OnDirt()
    {
        walkAudioSource.clip = walkAudioClips[0];

    }
    public void OnCement()
    {
        walkAudioSource.clip = walkAudioClips[3];


    }

    public void OnWood()
    {
        Debug.Log("Play Audio");
        walkAudioSource.clip = walkAudioClips[2];

    }

    public void WalkOnGrass()
    {

        walkAudioSource.clip = walkAudioClips[2];

    }


    public void StopAudio()
    {
        walkAudioSource.Stop();
    }

    public void OutsideVolumeHandler(float vol)
    {
        outsideAudioSource.volume = vol;
    }


}
