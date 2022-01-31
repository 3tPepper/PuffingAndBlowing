using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    //한 프레임마다 실행되는 메소드
    void FixedUpdate()
    {
        if (!isCatch)
        {
            PMove();
        }
    }

    private float pSpeed = 20f;
    public static bool isTouch = false;
    private bool isCatch = false;

    void PMove()
    {
        if(!EventSystem.current.IsPointerOverGameObject())  //마우스가 UI를 클릭했을 경우 실행되지 않도록
        {
            if (Input.GetMouseButton(0))    //마우스 좌클릭 여부를 반환
            {
                isTouch = true; //마우스 좌클릭하는 중이면, food 나타나도록

                Vector3 nowpos = this.transform.position;    //현재 캐릭터의 위치 좌표
                Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 10f));   //사용자가 터치한 곳의 위치 좌표
                Vector3 tmp = nowpos;
                newpos.z = 0f;  //z축이 변경되지 않도록 고정 

                //nowpos와 newpos의 위치를 비교하여 캐릭터 애니메이션의 차이 주기
                if(nowpos.x > newpos.x) //left:1
                {
                    animator.SetInteger("move", 1);
                    tmp.x -= pSpeed * Time.deltaTime;
                    //this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                }
                else if(nowpos.x < newpos.x)    //right:2
                {
                    animator.SetInteger("move", 2);
                    tmp.x += pSpeed * Time.deltaTime;
                    //this.transform.Translate(newpos * pSpeed * Time.deltaTime);
                }

                if(nowpos.y > newpos.y)
                {
                    tmp.y -= pSpeed * Time.deltaTime;
                }
                else if(nowpos.y < newpos.y)
                {
                    tmp.y += pSpeed * Time.deltaTime;
                }

                this.transform.position = tmp;
            }
            else
            {
                isTouch = false; //마우스 좌클릭하고있지 않을 경우, food 사라지도록
                animator.SetInteger("move", 0);
            }
        }
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.tag == "Food")
        {
            isCatch = true;
            this.transform.position = collision.transform.position;
            animator.SetInteger("move", 3);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("exit");
        isCatch = false;
    }
}
