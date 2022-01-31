using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private GameObject PausePanel;

    public static bool isPause = false;

    void Start()
    {
        PausePanel.SetActive(false);
        hideFood();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
        if (PlayerMove.isTouch)
        {
            showFood();  //터치 상태일때
        }
        else
        {
            hideFood();  //터치 상태가 아닐때
        }
    }

    //사용자가 터치 시 터치 지점에 food 오브젝트 활성화.
    void showFood()
    {
        food.SetActive(true);   //food 오브젝트를 활성화
    }

    void hideFood()
    {
        food.SetActive(false);  //food 오브젝트를 비활성화
    }

    public void GamePause()
    {
        isPause = !isPause;
        if (isPause)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
        
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
