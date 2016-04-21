using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{
    public AudioSource sound;
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
        if (lvlManager != null && lvlManager.bookScene > 0)
            storyNo = lvlManager.bookScene;
        
        StartCoroutine(TurnRightPage());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(TurnRightPage());
        }
    }

    public IEnumerator TurnRightPage()
    {
        int leftPage = (storyNo - 1) * 2;
        int rightPage = leftPage + 1;

        if (leftPage < textures.Length && canChangePage) {
            sound.Play();
            
            anim.SetTrigger("rotate");
            yield return new WaitForSeconds(1.0f);

            leftMeshRenderer.material.mainTexture = textures[leftPage];
            rightMeshRenderer.material.mainTexture = textures[rightPage];

            storyNo++;
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

                anim.SetTrigger("rotate");
                yield return new WaitForSeconds(1.0f);

                leftMeshRenderer.material.mainTexture = textures[leftPage];
                rightMeshRenderer.material.mainTexture = textures[rightPage];

                storyNo--;
            }
        }
    }
}