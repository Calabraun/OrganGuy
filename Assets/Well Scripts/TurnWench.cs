using UnityEngine;
using System.Collections;

public class TurnWench : MonoBehaviour
{
    private GameObject bucketLantern;

	// Use this for initialization
	void Start () {
        bucketLantern = GameObject.FindWithTag("bucketLantern");

		transform.parent.animation.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	void OnTriggerEnter(Collider other) {

        transform.parent.animation.Play();

	    LanternSwitch(true);
	}


    void LanternSwitch(bool light)
    {

        Material[] newMaterials = new Material[2];

        newMaterials[0] = new Material(Shader.Find("Diffuse"));

        if (light)
        {
            newMaterials[1] = new Material(Shader.Find("Self-Illumin/Diffuse")); 
        }
        else
        {
            newMaterials[1] = new Material(Shader.Find("Diffuse"));
        }


        bucketLantern.renderer.materials = newMaterials;

        Light lanternLight = bucketLantern.GetComponentInChildren<Light>();
        lanternLight.intensity = .5f;



    }
}
