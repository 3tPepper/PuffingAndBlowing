using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodMove : MonoBehaviour
{

    void FixedUpdate()
    {
        FMove();
    }

    void FMove()
    {
        if (gameObject.activeSelf)  //food ������Ʈ�� Ȱ��ȭ ������ ���
        {
            Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //����ڰ� ��ġ�� ���� ��ġ ��ǥ
            newpos.z = 0f;  //z���� ������� �ʵ��� ���� 
            this.transform.position = newpos;   //food�� ��ġ = ���� ��ġ�� ���� ��ġ
        }
    }
}
