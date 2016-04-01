using UnityEngine;
using System.Collections;

public class welcome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button7)) {
			Debug.Log("df");
			Application.LoadLevel("intro");
		}
	}
}
