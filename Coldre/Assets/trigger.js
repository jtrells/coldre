#pragma strict

var target:Transform;
var mySound : AudioClip; 


function OnTriggerEnter(cubeTrigger:Collider) {
	if(cubeTrigger.transform == target){
		GetComponent.<AudioSource>().PlayOneShot(mySound); 
		GetComponent.<MeshRenderer>().enabled = false;
		Destroy(this,mySound.length);
	}
}
