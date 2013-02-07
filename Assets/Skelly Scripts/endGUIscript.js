#pragma strict

var GUIend : Texture2D;

function Start () {

	audio.Play();


}

function Update () {

}

function OnGUI () {

	GUI.Box(Rect(0,0,Screen.width,Screen.height), GUIend);
	
}