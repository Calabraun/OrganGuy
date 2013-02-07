using UnityEngine;
using System.Collections;

public class DescentLight : MonoBehaviour {
	
	public GameObject _descentLight;
	public GameObject _skelly;
    public GameObject WellTop;
	public GameObject _endGUI;
	
		
	// Use this for initialization
	void Start () {
		
		audio.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!WellTop) _descentLight.transform.position = new Vector3(_descentLight.transform.position.x,_skelly.transform.position.y,_descentLight.transform.position.z); 
		
		
		if (_endGUI.activeSelf){
		
			audio.Stop();
		}
	}
}
