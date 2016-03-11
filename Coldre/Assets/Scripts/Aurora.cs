using UnityEngine;
using System.Collections;

public class Aurora : MonoBehaviour {

	Material aMaterial;
	float offset;
	public bool reversed;

	// Use this for initialization
	void Awake () {
		aMaterial = this.GetComponent<Renderer>().material;

	}
	
	// Update is called once per frame
	void Update () {
		
			if(reversed == false){
				offset += 0.1f*Time.deltaTime;
			}
			else{
				offset -= 0.1f*Time.deltaTime;
			}

			aMaterial.SetTextureOffset("_MainTex", new Vector2(offset/3, offset));
		
	}
		
}
