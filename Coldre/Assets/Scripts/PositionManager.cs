using UnityEngine;
using System.Collections;

public class PositionManager : MonoBehaviour {

	public static Transform characterTransform;
	public GameObject character;

	void Awake(){
		characterTransform = null;
	}
	
}
