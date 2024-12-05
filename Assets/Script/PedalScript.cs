using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalScript : MonoBehaviour
{
    public bool isPedalPressed = false; // ���� ���� ���� üũ ����
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
            Debug.Log("������ ����");
            isPedalPressed = true;
        }


    }

   

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Foot"))
        {
            Debug.Log("���ǿ��� ���� ��");
            isPedalPressed = false;  // ������ ������ ���� ���·� ����
        }


    }


}
