using UnityEngine;
using UnityEngine.UI;

public class TalkCollider : MonoBehaviour {

    public Text instructions;
    public string context;
    LevelManager levelManager;
    public GameObject affectedObject;
	public GameObject character;

    private bool actionEnabled = false;

    void Awake() {
        instructions.enabled = false;
    }

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            instructions.enabled = true;
            actionEnabled = true;

            if (context.Equals("end")) {
                levelManager.bookScene = 5;
                levelManager.canChangePage = false;
                levelManager.LoadLevel("1_Book");
            }
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
		if (actionEnabled && ( CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button2) || Input.GetKeyDown(KeyCode.Z) )) {
            //if (actionEnabled && Input.GetKey(KeyCode.B)) {

            print("CONTEXT " + context);

			if (context.Contains("fairy-what-going-on")){
                levelManager.bookScene = 2;
                levelManager.canChangePage = false;
                // levelManager.LoadLevel("1-whats-going-on");
                levelManager.LoadLevel("1_Book");
            }
            else if (context.Contains("fairy-surprised")) {
                levelManager.bookScene = 3;
                levelManager.canChangePage = false;
                //levelManager.LoadLevel("2-surprised-uglifruit");
                levelManager.LoadLevel("1_Book");
            } else if (context.Contains("first-music-box")) {
                levelManager.bookScene = 4;
                levelManager.canChangePage = false;
                levelManager.LoadLevel("1_Book");
                //levelManager.LoadLevel("music-box-doing-here");
			}else if (context.Contains("destroy"))
                Destroy(affectedObject);
            else
                print("no scene");
        }
    }
}
