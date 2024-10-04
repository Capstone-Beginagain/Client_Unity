using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTomScript : MonoBehaviour
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
        Debug.Log("����Ž �浹 ����!");
        audioSource.PlayOneShot(audioSource.clip);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("�浹 ��!");
    }


}
