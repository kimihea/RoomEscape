using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameQuiz : QuizObject
{
    public Transform Frame;
    public Transform KeyPad;

    private Transform FrameValue;
    private Transform KeyPadValue;
    protected override void Hint()
    {
       
    }

    protected override void QuizCorrect()
    {
        //보상지급
        isSolved = true;
        AudioManager.Instance.PlayEffect("Quiz1");
        EdgeRenderer.material = EdgeMaterial;
    }

    protected override void ResetQuiz()
    {
        if (isSolved)
        {
            Frame = FrameValue;
            KeyPad = KeyPadValue;
        }
        else
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FrameValue = Frame;
        KeyPadValue = KeyPad;
    }

    // Update is called once per frame

}
