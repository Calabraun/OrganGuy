#pragma strict

function Start () {

	//rigidbody.isKinematic = false;

}

function Update () {

}

function OnCollisionEnter (other : Collision) {

       rigidbody.isKinematic = true; 
       collider.isTrigger = true;  
            
}