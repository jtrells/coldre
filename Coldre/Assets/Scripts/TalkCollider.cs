using UnityEngine;
using UnityEngine.UI;

public class TalkCollider : MonoBehaviour {

    public Text instructions;
    public string context;
    public LevelManager levelManager;
    public GameObject affectedObject;

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
        if (actionEnabled && Input.GetKeyDown(KeyCode.A)) {
            if (context.Contains("fairy-what-going-on"))
                levelManager.LoadLevel("1-whats-going-on");
            else if (context.Contains("fairy-surprised")) {
                levelManager.LoadLevel("2-surprised-uglifruit");
            }
            else if (context.Contains("destroy"))
                Destroy(affectedObject);
            else
                print("no scene");
        }
    }
}
