﻿using UnityEngine;
using System.Collections;

public class TempleSphereCollected : MonoBehaviour
{

    public GameObject cloak;
    public GameObject bridge;
    public AudioSource cloakDestroyed;
    public AudioSource bridgeDown;
    public Animator surprisedFairyAnimator;

    void Start() {
        bridge.SetActive(false);
    }

    void OnTriggerEnter(Collider collider) {
        print("OnTriggerEnter purple sphere");
        bridge.SetActive(true);
        Destroy(cloak);
        surprisedFairyAnimator.SetBool("bridgeOpened", true);
        StartCoroutine(StartSound());
    }

    public IEnumerator StartSound()
    {
        if (cloakDestroyed != null) cloakDestroyed.Play();
        yield return new WaitForSeconds(1.5f);
        if (bridgeDown != null) bridgeDown.Play();
    }
}
