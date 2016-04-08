using UnityEngine;
using System.Collections;

public class FairySurprised : MonoBehaviour {

    public Transform[] Dialogs;
    public Transform player;

    void Start(){
        for (int i = 0; i < Dialogs.Length; i++)
            if (Dialogs[i] != null)
                Dialogs[i].GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
	
	}


}
