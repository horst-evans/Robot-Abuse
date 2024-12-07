using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocalize : MonoBehaviour
{
    public AudioClip[] attachClips;
    public AudioClip[] detachClips;
    public AudioSource vocalSource;

    public GameObject jaw;
    [Tooltip("Seconds it takes for jaw to open and close")]
    public float jawSpeed = 2;

    void Start()
    {
        Interactable.AttachEvent?.AddListener(ThankYou);
        Interactable.DettachEvent?.AddListener(SpeakOut);
    }

    private void Update()
    {
        if(vocalSource.isPlaying && !isMasticating)
        {
            StartCoroutine(Masticate());
        }
    }

    private void OnDestroy()
    {
        Interactable.AttachEvent?.RemoveListener(ThankYou);
        Interactable.DettachEvent?.RemoveListener(SpeakOut);
    }

    private void ThankYou()
    {
        AudioClip randomClip = attachClips[Random.Range(0,attachClips.Length)];
        vocalSource.PlayOneShot(randomClip);
    }

    private void SpeakOut()
    {
        AudioClip randomClip = detachClips[Random.Range(0, detachClips.Length)];
        vocalSource.PlayOneShot(randomClip);
    }

    private bool isMasticating = false;
    private IEnumerator Masticate()
    {
        isMasticating = true;
        // open
        for(int i = 0; i < 10; i ++)
        {
            jaw.transform.Rotate(Vector3.right * 3);
            yield return new WaitForSeconds(jawSpeed/20f); // (10 chunks per half * 2 halfs = 20)
        }
        // close
        for (int i = 0; i < 10; i ++)
        {
            jaw.transform.Rotate(Vector3.left * 3);
            yield return new WaitForSeconds(jawSpeed/20f);
        }
        isMasticating = false;
    }


}
