using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(UnityEngine.Collider collider)
	{

		if (collider.transform == player) {
			Destroy (gameObject);

		}
	}
}
