using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour {

	public bool trapped=false;
	public Transform gum;
	Transform tr_Player;
	float f_RotSpeed=3.0f,f_MoveSpeed = 3.0f;

	float range = 60f;
	float range2 = 60f;
	float stop =  0f;
	Vector3 distance;
    float mag;

	Vector3 initialPos;

	// Use this for initialization
	void Start () {

		initialPos = transform.position; 
        tr_Player = GameObject.FindGameObjectWithTag ("Player").transform;
        distance = tr_Player.position;
    }

    void FixedUpdate()
    {
		if (trapped) {
			distance = tr_Player.position - transform.position;
			mag = distance.magnitude;
			Debug.Log (mag);
		} else {
			distance = initialPos - transform.position;
			mag = distance.magnitude;
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (trapped) {
			if (mag <= range2 && mag >= range) {
				/* Look at Player*/
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
			} else if (mag <= range && mag > stop) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

				/* Move at Player*/
				transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
			} else if (mag <= stop) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
	
			}
		} else {
			if (mag <= range2 && mag >= range) {
				/* Look at Player*/
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (initialPos - transform.position), f_RotSpeed * Time.deltaTime);
			} else if (mag <= range && mag > stop) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (initialPos - transform.position), f_RotSpeed * Time.deltaTime);
				
				/* Move at Player*/
				transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
			} else if (mag <= stop) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (initialPos - transform.position), f_RotSpeed * Time.deltaTime);
				
			}
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform== tr_Player) {
			trapped = true;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.transform== tr_Player) {
			trapped = false;
		}
	}
}