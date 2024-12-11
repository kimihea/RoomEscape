using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameQuiz : QuizObject
{
    public Transform Frame;

    private Transform FrameValue;
    public Puzzle[] puzzle;
    void Start()
    {
        EdgeRenderer.enabled = false;
        FrameValue = Frame;
    }
    protected override void Hint()
    {
        
    }

    protected override void QuizCorrect()
    {
        isSolved = true;
        AudioManager.Instance.PlayEffect("Puzzle");
        foreach (var p in puzzle)
        {
            if (!p.Finish)
                isSolved = false;
        }
        //모두Finish되었다면최종 엔드
        if(isSolved)
        {
            isSolved = true;
            AudioManager.Instance.PlayEffect("Quiz1");
            EdgeRenderer.enabled = true;
            EdgeRenderer.material = EdgeMaterial;
        }
        //보상지급

    }

    protected override void ResetQuiz()
    {
        if (isSolved)
        {
            Frame = FrameValue;
        }
        else
        {

        }
    }

}
