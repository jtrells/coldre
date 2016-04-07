using UnityEngine;
using UnityEngine.UI;

public class TalkCollider : MonoBehaviour {

    public Text instructions;
    public string context;
    public LevelManager levelManager;

    private bool actionEnabled = false;

    void Awake() {
        instructions.enabled = false;
    }

    void OnTriggerEnter(Collider other) {
        print("OnTriggerEnter fairy");
        instructions.enabled = true;
        actionEnabled = true;
    }

    void OnTriggerExit(Collider other) {
        print("OnTriggerExit fairy");
        instructions.enabled = false;
        actionEnabled = false;
    }

    void Update() {
        if (actionEnabled && Input.GetKeyDown(KeyCode.A)) {
            if (context.Contains("fairy-what-going-on"))
                levelManager.LoadLevel("1-whats-going-on");
            else
                print("no scene");
        }
    }
}
