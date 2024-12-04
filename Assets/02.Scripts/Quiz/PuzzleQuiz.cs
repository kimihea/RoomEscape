using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

class PuzzleQuiz : QuizObject
{
    BoxCollider boxColider;
    [field:Serialize] private int[] indexSol = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    public int[] indexCur;
    private void Start()
    {
        indexCur = new int[9];
        boxColider = GetComponent<BoxCollider>();
    }
    protected override void Awake()
    {
        base.Awake();

    }
    protected override void QuizCorrect()
    {
        if(indexCur.SequenceEqual(indexSol))
        {
            isSolved = true;   
        }
        PlayEffect(IsSolved);
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

}

