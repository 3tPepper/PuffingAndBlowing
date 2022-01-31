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
        if (gameObject.activeSelf)  //food 오브젝트가 활성화 상태인 경우
        {
            Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //사용자가 터치한 곳의 위치 좌표
            newpos.z = 0f;  //z축이 변경되지 않도록 고정 
            this.transform.position = newpos;   //food의 위치 = 현재 터치한 곳의 위치
        }
    }
}
