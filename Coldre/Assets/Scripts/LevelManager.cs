using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    public int bookScene;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string name){
        Application.LoadLevel(name);
    }

    public void QuitRequest() {
        Application.Quit();
    }
}
