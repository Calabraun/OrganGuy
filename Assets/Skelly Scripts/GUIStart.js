#pragma strict

var skelly : GameObject;
var GUIObject : GameObject;
var startGUI : Texture2D;
var descentLight : GameObject;
var EndGUI : GameObject;

function Start () {

	skelly.SetActiveRecursively(false);
	descentLight.SetActiveRecursively(false);
	EndGUI.SetActiveRecursively(false);

}

function Update () {

	if(Input.anyKey){
	
		skelly.SetActiveRecursively(true);
		descentLight.SetActiveRecursively(true);
		Destroy (GUIObject);
	
	}

}

function OnGUI () {

	if (GUI.Button(Rect(0,0,Screen.width,Screen.height), startGUI)){
	
		skelly.SetActiveRecursively(true);
		descentLight.SetActiveRecursively(true);
		Destroy (GUIObject);
	
	}

}