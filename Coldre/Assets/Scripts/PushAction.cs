using UnityEngine;
using System.Collections;

public class PushAction : MonoBehaviour {

	public Transform target;
	public Vector3 direction;
	public bool isPushAllow = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		direction = transform.position - target.transform.position;
		direction.Normalize ();
		if(isPushAllow&&CAVE2Manager.GetButton(1,CAVE2Manager.Button.Button2))
		{
            target.GetComponent<Animator>().SetBool("isPushing", true);
			transform.GetComponent<Rigidbody>().AddForce(direction*1000);
		}
        else
        target.GetComponent<Animator>().SetBool("isPushing", false);
    }

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform == target) {
			isPushAllow = true;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.transform == target) {
			isPushAllow = false;
		}
	}
}
