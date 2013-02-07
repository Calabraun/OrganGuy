using UnityEngine;
using System.Collections;

public class GlowBlock : MonoBehaviour {

    private GameObject[] blocks;

	// Use this for initialization
	void Start () {
        blocks = GameObject.FindGameObjectsWithTag("block");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collider") return;

        foreach (var block in blocks )
        {
            BlockSwitch(block, false);
        }
        BlockSwitch(null, true);
    }


    void BlockSwitch(GameObject currentBlock, bool light)
    {

        if (light)
        {
            transform.renderer.material = new Material(Shader.Find("Diffuse"));
            transform.renderer.material.SetColor("_Color", new Color(3.5f, 3.4f, 3.4f));
        }
        else
        {
            currentBlock.transform.renderer.material = new Material(Shader.Find("Diffuse"));
        }

    }


}
