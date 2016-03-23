using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public Transform[] Dialogs;
	public Transform[] Particles;
	public Transform CAVECamera;
	public Animator anim;

	// Use this for initialization
	void Start () {

		anim = CAVECamera.GetComponent<Animator>();
		for(int i=0;i<Dialogs.Length-1;i++)
		{
			if(Dialogs[i]!=null)
			Dialogs[i].GetComponent<Renderer>().enabled = false;
		}
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [0].GetComponent<Renderer> ().enabled = false;
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.0f);
		Particles [1].GetComponent<Renderer> ().enabled = false;
		StartCoroutine (Dialog());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator Dialog()
	{
		yield return new WaitForSeconds(2.0f);
		Dialogs [0].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.1f);
		yield return new WaitForSeconds(2.0f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.15f);
		Dialogs [1].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);
		Particles [1].GetComponent<Renderer> ().enabled = true;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);

		Dialogs [0].GetComponent<Renderer> ().enabled = false;
		Dialogs [2].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(2.0f);

		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.5f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.5f);

		Dialogs [1].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds(5.0f);
		anim.SetBool("isIntro", true);
		Dialogs [2].GetComponent<Renderer> ().enabled = false;
		Dialogs [3].GetComponent<Renderer> ().enabled = false;
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.2f);
		yield return new WaitForSeconds(2.0f);
		Particles [0].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.01f);
		Particles [1].GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 255, 0.01f);
		
	}
}
