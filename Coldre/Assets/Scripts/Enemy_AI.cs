using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour {
	
	Transform tr_Player;
	float f_RotSpeed=3.0f,f_MoveSpeed = 3.0f;

	float range = 5f;
	float range2 = 5f;
	float stop =  0f;
	float distance = 2f;

	// Use this for initialization
	void Start () {
		
		tr_Player = GameObject.FindGameObjectWithTag ("Player").transform; }
	
	// Update is called once per frame
	void Update () {

		if (distance <= range2 && distance >= range) 
		{
			/* Look at Player*/
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
		} 
		else if (distance <= range && distance > stop) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

			/* Move at Player*/
			transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
		} 
		else if (distance <= stop) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
	
		}
	}
}