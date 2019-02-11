using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaterSplash : MonoBehaviour
{


    public Animator animatorWater;
    public AudioSource audioSource;
    public List<AudioClip> clips;

    public float waterDropTime = 0.2f;
    public float waterSondDelay= 0.08f;
    public void StartWaterCoroutine()
    {
        StartCoroutine(WaterDropCoroutine());
    }

    IEnumerator WaterDropCoroutine()
    {
        yield return new WaitForSeconds(waterDropTime);
        PlaySound();
        yield return new WaitForSeconds(0.08f);
        animatorWater.Play("splash");
    }
    public void PlaySound()
    {
        int x = Random.Range(0, clips.Count);
        AudioClip clip = clips[x];
        audioSource.PlayOneShot(clip, 1f);
    }
}
