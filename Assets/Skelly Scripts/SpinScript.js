#pragma strict

var xspin = 20;
var yspin = 20;
var zspin = 20;

function Start () {

}

function Update () {

	 transform.Rotate(xspin*Time.deltaTime, yspin*Time.deltaTime, zspin*Time.deltaTime);

}