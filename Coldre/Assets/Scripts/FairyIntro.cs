using UnityEngine;
using System.Collections;

public class FairyIntro : MonoBehaviour {

	public Transform[] Dialogs;
	public Transform player;
	public bool firstCoroutine = false;
	public bool secondCoroutine = false;
	public bool runAway = false;
	public bool runAway2 = false;
	// Use this for initialization
	void Start () {
		for(int i=0;i<Dialogs.Length;i++)
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
		if (runAway2 && !secondCoroutine) {
			transform.GetComponent<Animator>().SetBool("runAway2", true);
			secondCoroutine = true;
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
        // Fairy: Too fast!
        yield return new WaitForSeconds(1.5f);
		Dialogs [0].GetComponent<Renderer> ().enabled = true;

        // Fairy: I knew (gasp) that...
        yield return new WaitForSeconds(1.5f);
		Dialogs [0].GetComponent<Renderer> ().enabled = false;
		Dialogs [1].GetComponent<Renderer> ().enabled = true;

        // Fairy: I (gasp) shouldn’t have (gasp) eaten
        // all those (gasp) cookies for breakfast.
        yield return new WaitForSeconds(5.2f);
		Dialogs [1].GetComponent<Renderer> ().enabled = false;
		Dialogs [2].GetComponent<Renderer> ().enabled = true;
	}


	public IEnumerator Dialog2()
	{

        // Fairy: Please (gasp) don’t (gasp) hurt me.
        yield return new WaitForSeconds(3.5f);
		Dialogs [2].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = true;

        // Rocky: Hurt you?
        yield return new WaitForSeconds(2.0f);
		Dialogs [3].GetComponent<Renderer> ().enabled = false;
		Dialogs [4].GetComponent<Renderer> ().enabled = true;

        // Rocky: We just wanted to know what’s going on
        // around here and where’s Bella?
        yield return new WaitForSeconds(4.5f);
		Dialogs [4].GetComponent<Renderer> ().enabled = false;
		Dialogs [5].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Stop it Rocky. Give her a second to catch her breath.
        yield return new WaitForSeconds(3.2f);
		Dialogs [5].GetComponent<Renderer> ().enabled = false;
		Dialogs [6].GetComponent<Renderer> ().enabled = true;

        // Cuddles:  She’s not looking fairy good right now. Don’t worry, we won’t hurt you.
        yield return new WaitForSeconds(5.0f);
		Dialogs [6].GetComponent<Renderer> ().enabled = false;
		Dialogs [7].GetComponent<Renderer> ().enabled = true;

        // Fairy: Thanks... 
        // Wait a minute.
        // How can you not know what’s going on?
        // It's been total chaos in Coldre.
        yield return new WaitForSeconds(7.4f);
		Dialogs [7].GetComponent<Renderer> ().enabled = false;
		Dialogs [8].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Well, the last thing I remember is playing with Bella here.
        yield return new WaitForSeconds(3.8f);
		Dialogs [8].GetComponent<Renderer> ().enabled = false;
		Dialogs [9].GetComponent<Renderer> ().enabled = true;

        // Cuddles:  It was a phenomenal game of hide-and-seek,
        // I had just found the absolutely, positively, undeniably
        // best hiding spot ever!
        yield return new WaitForSeconds(7.5f);
		Dialogs [9].GetComponent<Renderer> ().enabled = false;
		Dialogs [10].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Unlike you, Rocky, 
        // just hiding behind a flower while you take a nap.
        yield return new WaitForSeconds(5.0f);
		Dialogs [10].GetComponent<Renderer> ().enabled = false;
		Dialogs [11].GetComponent<Renderer> ().enabled = true;

        // Rocky: But I was tired.
        yield return new WaitForSeconds(2.5f);
		Dialogs [11].GetComponent<Renderer> ().enabled = false;
		Dialogs [12].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Anyway, it was the best hiding place ever! 
        // I am a great hider you know and—
        yield return new WaitForSeconds(5.0f);
		Dialogs [12].GetComponent<Renderer> ().enabled = false;
		Dialogs [13].GetComponent<Renderer> ().enabled = true;

        // Fairy: Get to the point!
        yield return new WaitForSeconds(3.0f);
		Dialogs [13].GetComponent<Renderer> ().enabled = false;
		Dialogs [14].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Oh, yeah. 
        // Well, I don’t remember what happened after that.
        // Last I remember, the islands were still as beautiful and colorful as ever.
        // Can you tell us what happened?
        yield return new WaitForSeconds(9.5f);
		Dialogs [14].GetComponent<Renderer> ().enabled = false;
		Dialogs [15].GetComponent<Renderer> ().enabled = true;

        // Fairy: It was another beautiful day here on the islands, 
        // when all of a sudden Bella disappeared and then the ogres came.
        // They made the islands turn gloomy and dark. 
        yield return new WaitForSeconds(10.5f);
		Dialogs [15].GetComponent<Renderer> ().enabled = false;
		Dialogs [16].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Maybe the ogres took Bella?
        yield return new WaitForSeconds(3.5f);
		Dialogs [16].GetComponent<Renderer> ().enabled = false;
		Dialogs [17].GetComponent<Renderer> ().enabled = true;

        // Rocky: Oh, you are making conclusions too fast. 
        // It may be just a correlation, not a causation
        // but lets add it to our theories list.
        yield return new WaitForSeconds(10.0f);
		Dialogs [17].GetComponent<Renderer> ().enabled = false;
		Dialogs [18].GetComponent<Renderer> ().enabled = true;

        // Fairy: I think you should explore the hills on the west side of the island.
        // I hear that there is a mysterious place there.
       // Maybe you’ll find Bella there or at least a way
        yield return new WaitForSeconds(9.0f);
		Dialogs [18].GetComponent<Renderer> ().enabled = false;
		Dialogs [19].GetComponent<Renderer> ().enabled = true;

        // Cuddles: Well, we won’t figure anything out 
        // by standing around.Let’s go!!
        yield return new WaitForSeconds(4.5f);
		Dialogs [19].GetComponent<Renderer> ().enabled = false;
		Dialogs [20].GetComponent<Renderer> ().enabled = true;

        yield return new WaitForSeconds(4.5f);
        Dialogs[20].GetComponent<Renderer>().enabled = false;
    }



}
