using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsQuiz : QuizObject
{
    protected override void Hint()
    {
           
    }

    protected override void QuizCorrect()
    {
        AudioManager.Instance.PlayEffect("Quiz3");
        EdgeRenderer.enabled = true;
        EdgeRenderer.material = EdgeMaterial;
    }

    protected override void ResetQuiz()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        EdgeRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
