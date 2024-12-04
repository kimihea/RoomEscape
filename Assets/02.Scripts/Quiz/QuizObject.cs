using UnityEngine;
class QuizObject : MonoBehaviour 
{
    protected bool isSolved;
    public bool IsSolved
    {
        get { return isSolved; }
    }
    protected virtual void Awake()
    {
        isSolved = false;

    }
    protected virtual void QuizCorrect()
    {
        //퀘즈마다 조건을 검사하여 상태변경

    }
    protected virtual void Hint() 
    {
        //퀴즈의 힌트들을 알려주는 메소드
    }
    protected virtual void ResetQuiz()
    {
        
    }
    protected void PlayEffect(bool correct)
    {
        if (correct)
        {//오디오매니저에서 정답 출력

        }
        else
        {//오디오 매니저에서 띠링 출력

        }
    }
}
   
