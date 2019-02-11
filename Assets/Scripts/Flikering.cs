using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flikering : MonoBehaviour
{
    public List<Light> lights;
    public List<SpriteRenderer> Sprites;
    public float minAlphaChange = -0.2f;
    public float maxAlphaChange = 0.2f;
    public float minWaitSeconds = 0.05f;
    public float maxWaitSeconds =0.1f;
    float lastValue;

    void Start()
    {
        StartCoroutine(Fliker());
    }

    IEnumerator Fliker()
    {
        while (Application.isPlaying)
        {
            float value = Random.Range(minAlphaChange, maxAlphaChange);
            foreach (SpriteRenderer s in Sprites)
            {
                Color c = s.color;
                c.a -= lastValue;
                c.a += value;
                s.color = c;
            }
            foreach (Light l in lights)
            {
                Color c = l.color;
                c.a -= lastValue;
                c.a += value;
                l.color = c;
            }
            lastValue = value;
            yield return new WaitForSeconds(Random.Range(minWaitSeconds, maxWaitSeconds));
        }

    }
}
