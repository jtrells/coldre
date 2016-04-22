using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource dialogue;
    public Animator anim;
    public MeshRenderer leftMeshRenderer;
    public MeshRenderer rightMeshRenderer;
    public MeshRenderer backMeshRenderer;
    public Texture[] textures;
    public bool canChangePage = true;

    public int storyNo = 0;

    private LevelManager lvlManager;

    void Start() {
        lvlManager = FindObjectOfType<LevelManager>();
        if (lvlManager != null && lvlManager.bookScene > 0) { 
            storyNo = lvlManager.bookScene;
            canChangePage = lvlManager.canChangePage;
        }

        print(lvlManager);
        print("Story " + storyNo);
        StartCoroutine(TurnRightPage());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            if (canChangePage)
                StartCoroutine(TurnRightPage());

        ExitShort();
    }

    public IEnumerator TurnRightPage()
    {
        int leftPage = (storyNo - 1) * 2;
        int rightPage = leftPage + 1;

        if (leftPage < textures.Length) {
            sound.Play();
            PlayDialogue();

            anim.SetTrigger("rotate");
            yield return new WaitForSeconds(1.0f);

            leftMeshRenderer.material.mainTexture = textures[leftPage];
            rightMeshRenderer.material.mainTexture = textures[rightPage];

            if (canChangePage)
                storyNo++;
        }
    }

    void ExitShort() {
        // When viewing the shorts from the game, the user can't change 
        // the pages manually
        if (!canChangePage && Input.GetKeyDown(KeyCode.Space)){
            if (storyNo == 1)
                lvlManager.LoadLevel("intro");
            else if (storyNo == 2)
                lvlManager.LoadLevel("playtesting1");
            else if (storyNo == 3)
                lvlManager.LoadLevel("playtesting2");
            else if (storyNo == 4)
                lvlManager.LoadLevel("playtesting3");
        }
    }

    public IEnumerator TurnLeftPage()
    {
        if (storyNo > 1) {
            int leftPage = (storyNo - 1) * 2;
            int rightPage = leftPage + 1;

            if (leftPage < textures.Length && canChangePage)
            {
                sound.Play();
                PlayDialogue();

                anim.SetTrigger("rotate");
                yield return new WaitForSeconds(1.0f);

                leftMeshRenderer.material.mainTexture = textures[leftPage];
                rightMeshRenderer.material.mainTexture = textures[rightPage];

                storyNo--;
            }
        }
    }

    private void PlayDialogue() {
        if (storyNo == 1)
            dialogue.Play();
    }
}