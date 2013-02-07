using UnityEngine;
using System.Collections;

public class GlowGlyph : MonoBehaviour
{
    private double duration;
    private float dim;
    private float bright;

    // Use this for initialization
   IEnumerator Start()
    {
       duration = 1;
       dim = .3f;
       bright = .8f;
 
        transform.renderer.material = new Material(Shader.Find("Self-Illumin/Diffuse"));

        while (true)
        {
           yield return StartCoroutine(LerpLightColor(new Color(dim,dim,dim), new Color(bright,bright,bright)));
           yield return StartCoroutine(LerpLightColor(new Color(bright,bright,bright), new Color(dim,dim,dim)));
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 10);
    }

    IEnumerator LerpLightColor(Color col1, Color col2)
    {
        var t = 0.0;
        var rate = 1.0 / duration;
        while (t < 1.0)
        {
            t += Time.deltaTime * rate;
            transform.renderer.material.color = Color.Lerp(col1, col2, (float)t);
            yield return null;
        }
    }
}
