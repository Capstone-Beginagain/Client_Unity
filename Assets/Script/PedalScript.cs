using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalScript : MonoBehaviour
{
    public bool isPedalPressed = false; // 발판 눌림 상태 체크 변수
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsPedalPressed()
    {
        return isPedalPressed;
    }

    public void SetPedalPressed(bool isPedalPressed)
    {
        this.isPedalPressed = isPedalPressed;
    }


    public bool GetPedalPressed()
    {
        return isPedalPressed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Foot"))
        {
            Debug.Log("발판이 눌림");
            isPedalPressed = true;
        }


    }

   

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Foot"))
        {
            Debug.Log("발판에서 발을 뗌");
            isPedalPressed = false;  // 발판이 눌리지 않은 상태로 설정
        }


    }


}
