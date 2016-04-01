using UnityEngine;
using System.Collections;

public class FairyIntro : MonoBehaviour {

	public Transform[] Dialogs;
	public Transform player;
	public bool firstCoroutine = false;
	public bool runAway = false;
	public bool runAway2 = false;
	// Use this for initialization
	void Start () {
		for(int i=0;i<Dialogs.Length-1;i++)
		{
			if(Dialogs[i]!=null)
				Dialogs[i].GetComponent<Renderer>().enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (runAway && !firstCoroutine) {
			transform.GetComponent<Animator>().SetBool("runAway",true);
			firstCoroutine = true;
			StartCoroutine(Dialog1());
		}
		if (runAway2) {
			transform.GetComponent<Animator>().SetBool("runAway2", true);
			StartCoroutine (Dialog2());
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform == player&&runAway==false) {
			runAway = true;
			Debug.Log ("enter");
		}
		else if (collider.transform == player&&runAway==true) {
			runAway2 = true;
			Debug.Log ("enter");
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.transform == player)
			Debug.Log ("exit");
	}


	public IEnumerator Dialog1()
	{

		

		yield return new WaitForSeconds(2.0f);
		Dialogs [0].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [0].GetComponent<Renderer> ().enabled = false;
		Dialogs [1].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [1].GetComponent<Renderer> ().enabled = false;
		Dialogs [2].GetComponent<Renderer> ().enabled = true;

	}


	public IEnumerator Dialog2()
	{
	
		yield return new WaitForSeconds(2.0f);
		Dialogs [2].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = true;
	}



}
