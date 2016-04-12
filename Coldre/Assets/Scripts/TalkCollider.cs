using UnityEngine;
using UnityEngine.UI;

public class TalkCollider : MonoBehaviour {

    public Text instructions;
    public string context;
    public LevelManager levelManager;
    public GameObject affectedObject;
	public GameObject character;

    private bool actionEnabled = false;

    void Awake() {
        instructions.enabled = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            print("OnTriggerEnter fairy");
            instructions.enabled = true;
            actionEnabled = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player"){
            print("OnTriggerExit fairy");
            instructions.enabled = false;
            actionEnabled = false;
        }
    }

    void Update() {
		if (actionEnabled && CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button2)) {
		//if (actionEnabled && Input.GetKey(KeyCode.B)) {
			if (context.Contains("fairy-what-going-on")){
				PositionManager.characterTransform = character.transform;
                levelManager.LoadLevel("1-whats-going-on");
			}else if (context.Contains("fairy-surprised")) {
				PositionManager.characterTransform = character.transform;
				levelManager.LoadLevel("2-surprised-uglifruit");
			} else if (context.Contains("first-music-box")) {
				levelManager.LoadLevel("music-box-doing-here");
			}else if (context.Contains("destroy"))
                Destroy(affectedObject);
            else
                print("no scene");
        }
    }
}
