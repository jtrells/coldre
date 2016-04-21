using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public string nextScene;
    public float waitSeconds;

    private LevelManager levelManager;

	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        StartCoroutine(WaitAndChange());
	}

    IEnumerator WaitAndChange () {
        yield return new WaitForSeconds(waitSeconds);
        levelManager.LoadLevel(nextScene);
    }
}
