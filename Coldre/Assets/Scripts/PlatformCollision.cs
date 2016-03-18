using UnityEngine;
using System.Collections;

public class PlatformCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision)
	{

		transform.GetComponent<FSMAI> ().state = FSMAI.State.Idle;
	}

	void OnTriggernExit(Collider collision)
	{
		transform.GetComponent<FSMAI> ().state = FSMAI.State.Action;
	}
}
