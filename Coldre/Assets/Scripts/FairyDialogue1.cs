using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FairyDialogue1 : MonoBehaviour {

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

		for(int i=0; i < Dialogs.Length; i++)
			if(Dialogs[i]!=null) Dialogs[i].enabled = false;
		
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [0].GetComponent<Renderer> ().enabled = false;
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [1].GetComponent<Renderer> ().enabled = false;
		StartCoroutine (Dialog());
	}


	void Update()
	{
		if (CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button2)) {
			Application.LoadLevel(5);
		}
	}


	public IEnumerator Dialog()
	{
        //dialogue.Play();

        yield return new WaitForSeconds(2.1f);

        Particles[0].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.1f);

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.15f);

        Dialogs[0].enabled = true;
        print(Dialogs[0].text);
        yield return new WaitForSeconds(4f);
        Dialogs[0].enabled = false;

        Particles[1].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);

        Dialogs[1].enabled = true;
        print(Dialogs[1].text);
        yield return new WaitForSeconds(4f);
        Dialogs[1].enabled = false;

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);

        Dialogs[2].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[2].enabled = false;

        Dialogs[3].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[3].enabled = false;

        Dialogs[4].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[4].enabled = false;

        Dialogs[5].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[5].enabled = false;

        Dialogs[6].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[6].enabled = false;

        Dialogs[7].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[7].enabled = false;

        Dialogs[8].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[8].enabled = false;

        Dialogs[9].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[9].enabled = false;

        Dialogs[10].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[10].enabled = false;

        Dialogs[11].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[11].enabled = false;

        Dialogs[12].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[12].enabled = false;

        Dialogs[13].enabled = true;
        yield return new WaitForSeconds(4f);
        Dialogs[13].enabled = false;

        //dialogue.Stop();

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        yield return new WaitForSeconds(2.0f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);

		Application.LoadLevel("playtesting1");

    }
}
