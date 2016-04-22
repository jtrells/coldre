using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

    // public Transform[] Dialogs;
    public Text[] Dialogs;
	public Transform[] Particles;
    public GameObject[] DialogPanels;
	public Transform CAVECamera;
	public Animator anim;
    public AudioSource dialogue;

	// Use this for initialization
	void Start () {

		anim = CAVECamera.GetComponent<Animator>();

        /*
		for(int i=0;i<Dialogs.Length-1;i++)
		{
			if(Dialogs[i]!=null)
			Dialogs[i].GetComponent<Renderer>().enabled = false;
		}*/
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [0].GetComponent<Renderer> ().enabled = false;
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [1].GetComponent<Renderer> ().enabled = false;
		StartCoroutine (Dialog());
	}

	void Update()
	{
		if (CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button7)) {
			Application.LoadLevel("playtesting");

		}
	}


	public IEnumerator Dialog()
	{
       

        // enable panel 1 to display first half of dialogues
        yield return new WaitForSeconds(2.1f);
        //DialogPanels[0].SetActive(true);

        Particles[0].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.1f);

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.15f);

        

        Particles[1].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);

        
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);

        // no need to turn back the color to white as we
        // are moving to the next panel
        

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        yield return new WaitForSeconds(3.0f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);

        //DialogPanels[1].SetActive(false);
        anim.SetBool("isIntro", true);
        yield return new WaitForSeconds(30.0f);
        Application.LoadLevel("playtesting");

        /*
		yield return new WaitForSeconds(2.0f);
		Dialogs [0].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.1f);
		yield return new WaitForSeconds(3.0f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.15f);
		Dialogs [1].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(4.0f);
		Particles [1].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);

		Dialogs [0].GetComponent<Renderer> ().enabled = false;
		Dialogs [1].GetComponent<Renderer> ().enabled = false;
		Dialogs [2].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);

		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.5f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.5f);

		Dialogs [1].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = true;

		yield return new WaitForSeconds(2.0f);
		Dialogs [4].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [5].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [2].GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		Dialogs [3].GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		Dialogs [4].GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		Dialogs [5].GetComponent<Renderer> ().enabled = false;

		yield return new WaitForSeconds(2.0f);
		Dialogs [6].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [7].GetComponent<Renderer> ().enabled = true;


		yield return new WaitForSeconds(4.0f);
		Dialogs [6].GetComponent<Renderer> ().enabled = false;
		Dialogs [7].GetComponent<Renderer> ().enabled = false;


		Dialogs [8].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [9].GetComponent<Renderer> ().enabled = true;

		yield return new WaitForSeconds(4.0f);
		Dialogs [8].GetComponent<Renderer> ().enabled = false;
		Dialogs [9].GetComponent<Renderer> ().enabled = false;

		Dialogs [10].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [11].GetComponent<Renderer> ().enabled = true;

		yield return new WaitForSeconds(3.0f);
		Dialogs [10].GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		Dialogs [11].GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		Dialogs [12].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [13].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [14].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Dialogs [15].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(3.0f);
		Dialogs [16].GetComponent<Renderer> ().enabled = true;


		anim.SetBool("isIntro", true);
		Dialogs [2].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = false;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		yield return new WaitForSeconds(2.0f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.01f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.01f);

		yield return new WaitForSeconds(30.0f);
		Application.LoadLevel ("Demo");
		*/
    }
}
