using UnityEngine;
using System.Collections;

public class TestSceneParam : MonoBehaviour {

    LevelManager lvlManager;

	// Use this for initialization
	void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            lvlManager.NewGame();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            lvlManager.bookScene = 6;
            lvlManager.canChangePage = false;
            lvlManager.LoadLevel("1_Book");
        }
    }
}
