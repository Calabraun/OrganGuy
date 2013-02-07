#pragma strict

var endGame : GameObject;




function Start () {

	
	

}

function Update () {

	if(endGame.activeSelf == true){
	
		var bottom = GameObject.FindWithTag ("wellBottom");
		
		transform.position = Vector3(bottom.transform.position.x, bottom.transform.position.y + 10, bottom.transform.position.z);
		
	
	}

}