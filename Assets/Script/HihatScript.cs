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
            Debug.Log("닫은 하이햇 충돌소리");
            audioSource.PlayOneShot(closeHiHatClip);
        }
        else
        {
            Debug.Log("열린 하이햇 충돌소리");
            audioSource.PlayOneShot(openHiHatClip);
        }
    }




    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HiHat"))
        {
            if (pS.GetPedalPressed())
            {
                Debug.Log("클로즈 하이헷 충돌 - 클로즈 하이헷 소리 재생");
                audioSource.PlayOneShot(closeHiHatClip);
            }
            else
            {
                Debug.Log("오픈 하이헷 충돌 - 오픈 하이헷 소리 재생");
                audioSource.PlayOneShot(openHiHatClip);
            }
        }
    }
*/

}



