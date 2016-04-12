using UnityEngine;
using System.Collections;

public class LoadPlayTesting : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Awake () {
		Transform characterTransform = PositionManager.characterTransform;

		if (characterTransform != null){
			print ("transform not null");
			character.transform.position = character.transform.position;
			character.transform.rotation = character.transform.rotation;
		} else
			print ("transform null");
	}
}
