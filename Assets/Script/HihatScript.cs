using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HihatScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip closeHiHatClip;
    public AudioClip openHiHatClip;
    public PedalScript pS;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //closeHiHatClip = Resources.Load("drumSound/close hihat") as AudioClip;
        //openHiHatClip = Resources.Load("drumSound/open hihat") as AudioClip;

        //pS = GetComponent<PedalScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HiHat") && pS.GetIsPedalPressed())
        {
            Debug.Log("���� ������ �浹�Ҹ�");
            audioSource.PlayOneShot(closeHiHatClip);
        }
        else
        {
            Debug.Log("���� ������ �浹�Ҹ�");
            audioSource.PlayOneShot(openHiHatClip);
        }
    }




    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HiHat"))
        {
            if (pS.GetPedalPressed())
            {
                Debug.Log("Ŭ���� ������ �浹 - Ŭ���� ������ �Ҹ� ���");
                audioSource.PlayOneShot(closeHiHatClip);
            }
            else
            {
                Debug.Log("���� ������ �浹 - ���� ������ �Ҹ� ���");
                audioSource.PlayOneShot(openHiHatClip);
            }
        }
    }
*/

}



