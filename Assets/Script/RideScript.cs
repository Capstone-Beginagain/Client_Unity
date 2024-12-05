using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideScript : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("라이드심벌 충돌 시작!");
        audioSource.PlayOneShot(audioSource.clip);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("충돌 끝!");
    }


}
