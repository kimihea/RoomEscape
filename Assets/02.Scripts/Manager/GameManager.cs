using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public RoomSO[] RoomsInfo;
    
    void Start()
    {
        
    }

    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            //퀴즈순회 반짝이기;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            //퀴즈 Rest
            //컨트롤러에서 Ray를 발사하고 값을 돌려준다.
        }
    }
    void UpdateRoom(RoomSO roomInfo)
    {
        //룸에 있는 퀴즈 탐색및 위치 설정
       GameObject[] QuizList = SetQuiz(roomInfo.QuizPozitions);
        //퀴즈 진행상황 초기화
        foreach (GameObject quiz in QuizList)
        {
            QuizObject quizObject = GetComponent<QuizObject>();
        }

    }
    GameObject[] SetQuiz(Vector3[] positions)
    {
        GameObject[] quizs = GameObject.FindGameObjectsWithTag("Quiz");//Scene에 있는 Quiz오브젝트들을 탐색
        for (int i = 0; i < positions.Length; i++)
        {
            try
            {
                quizs[i].transform.position = positions[i];
            }
            catch (System.Exception)
            {
                Debug.Log("Check Your QuizObject have Quiz tag");
            }
            
        }
        return quizs;
    }

}
   
