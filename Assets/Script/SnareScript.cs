using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareScript : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("스네어 충돌");
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("스네어 충돌 해제");
    }
}
