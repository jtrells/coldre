using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FairyDialogue2 : MonoBehaviour {

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


	public IEnumerator Dialog()
	{
        //dialogue.Play();

        yield return new WaitForSeconds(2.1f);

        Particles[0].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.1f);

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.15f);

        Dialogs[0].enabled = true;
        print(Dialogs[0].text);
        yield return new WaitForSeconds(3f);
        Dialogs[0].enabled = false;

        Particles[1].GetComponent<Renderer>().enabled = true;
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);

        Dialogs[1].enabled = true;
        yield return new WaitForSeconds(3f);
        Dialogs[1].enabled = false;

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.5f);

        Dialogs[2].enabled = true;
        yield return new WaitForSeconds(3f);
        Dialogs[2].enabled = false;

        //dialogue.Stop();

        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.2f);
        yield return new WaitForSeconds(2.0f);
        Particles[0].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);
        Particles[1].GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 0.01f);
    }
}
