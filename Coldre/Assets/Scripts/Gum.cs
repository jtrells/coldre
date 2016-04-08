using UnityEngine;
using System.Collections;

public class Gum : MonoBehaviour {

	Transform player;
	Transform enemy;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform == player) {
			player.GetComponent<ColdreCharacterController>().enabled = false;
		} else if (collider.transform == enemy) {
			enemy.GetComponent<Enemy_AI>().enabled = false;
		}

	}
}
