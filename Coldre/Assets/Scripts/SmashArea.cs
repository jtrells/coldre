using UnityEngine;
using System.Collections;

public class SmashArea : MonoBehaviour {

	public Transform character;
	public Transform AIElement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform == character) {
			AIElement.GetComponent<FSMAI>().state = FSMAI.State.Action;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.transform == character) {
			AIElement.GetComponent<FSMAI>().state = FSMAI.State.Idle;
		}
	}
}
