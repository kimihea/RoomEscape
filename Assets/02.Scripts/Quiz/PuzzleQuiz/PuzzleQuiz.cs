using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleQuiz : QuizObject
{
    BoxCollider boxColider;
    [field:Serialize] private int[] indexSol = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    public int[] indexCur;
    private void Start()
    {
        indexCur = new int[9];
        boxColider = GetComponent<BoxCollider>();
    }
    void Awake()
    {

    }
    protected override void QuizCorrect()
    {
        if(indexCur.SequenceEqual(indexSol))
        {
            isSolved = true;   
        }

        EdgeRenderer.material = EdgeMaterial;
        AudioManager.Instance.PlayEffect("Quiz2");
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayEffect("Hover");
    }
    private void OnCollisionExit(Collision collision)
    {
     //   
    }
    private void OnCollisionStay(Collision collision)
    {
        Puzzle pz = collision.gameObject.GetComponent<Puzzle>();
        ////★퍼즐 Object의 위치를 계산해서 홀로그램 띄운다.
        ///
    }

    protected override void Hint()
    {
        throw new NotImplementedException();
    }

    protected override void ResetQuiz()
    {
        throw new NotImplementedException();
    }
}

