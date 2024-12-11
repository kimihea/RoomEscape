using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsQuiz : QuizObject
{
    protected override void Hint()
    {
        throw new System.NotImplementedException();
    }

    protected override void QuizCorrect()
    {
        AudioManager.Instance.PlayEffect("Quiz3");
        EdgeRenderer.material = EdgeMaterial;
    }

    protected override void ResetQuiz()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
