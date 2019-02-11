
using UnityEngine;
using TMPro;
using System.Collections;

public class FlikeringText : MonoBehaviour
{
    public TextMeshPro text;
    public float minAlphaChange = -0.2f;
    public float maxAlphaChange = 0.2f;
    public float minWaitSeconds = 0.05f;
    public float maxWaitSeconds = 0.1f;
    float lastValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fliker());
    }

    IEnumerator Fliker()
    {
        while (Application.isPlaying)
        {
            float value = Random.Range(minAlphaChange, maxAlphaChange);
            Color c = text.color;
            c.a -= lastValue;
            c.a += value;
            text.color = c;
            lastValue = value;
            yield return new WaitForSeconds(Random.Range(minWaitSeconds, maxWaitSeconds));
        }

    }
}
