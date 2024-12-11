using UnityEngine;
public abstract class QuizObject : MonoBehaviour 
{
    public Material EdgeMaterial;
    public MeshRenderer EdgeRenderer;
    protected bool isSolved;
    public bool IsSolved
    {
        get { return isSolved; }
    }
    //protected virtual void Awake()
    //{
    //    isSolved = false;

    //}
    protected abstract void QuizCorrect();

        //퀘즈마다 조건을 검사하여 상태변경


    protected abstract void Hint();

        //퀴즈의 힌트들을 알려주는 메소드
        //VoiceSDK Use
    protected abstract void ResetQuiz();  
    
    public void PlayEffect(bool correct)
    {
        if (correct)
        {
            AudioManager.Instance.PlayEffect("Correct");
        }
        else
        {
            AudioManager.Instance.PlayEffect("InCorrect");
        }
    }
}
   
