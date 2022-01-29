using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    //초기에 실행되는 메소드
    void Awake()
    {
        
    }

    //한 프레임마다 실행되는 메소드
    void FixedUpdate()
    {
        PMove();
    }

    private float pSpeed = 0.2f;
    void PMove()
    {
        if(!EventSystem.current.IsPointerOverGameObject())  //마우스가 UI를 클릭했을 경우 실행되지 않도록
        {
            if (Input.GetMouseButton(0))    //마우스 좌클릭 여부를 반환
            {
                Vector3 nowpos = this.transform.position;    //현재 캐릭터의 위치 좌표
                Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //사용자가 터치한 곳의 위치 좌표
                newpos.z = 0f;  //z축이 변경되지 않도록 고정 
                this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                //todo: nowpos와 newpos의 위치를 비교하여 캐릭터 애니메이션의 차이 주기
            }
        }
        
    }
}
