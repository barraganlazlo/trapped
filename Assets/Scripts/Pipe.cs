using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public WaterSplash splash;
    public Animator animatorPipe;
    public float minWaitTime;
    public float maxWaitTime;
    private void Start()
    {
        StartCoroutine(PlayAnimation());
    }
    IEnumerator PlayAnimation()
    {
        while (Application.isPlaying)
        {
            animatorPipe.Play("pipe-drop");
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }
    public void StartWaterAnimation()
    {
        splash.StartWaterCoroutine();
    }
}
