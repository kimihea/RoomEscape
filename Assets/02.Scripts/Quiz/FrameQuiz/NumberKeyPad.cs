using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class NumberKeyPad : MonoBehaviour
{
    public TextMeshPro NumberInput;
    const string correctPassword = "2813";
    public string input;
    public QuizObject MotherQuiz;
    /// <summary>
    /// 네자리 번호를 입력받고 틀리다면 새로운 번호 입력받기 문구도 뛰워주기 +효과음도
    /// </summary>
    //입력을 받을 텍스트와 번호들

    void Start()
    {
        
    }
    public void GetNumber(int index)
    {
        input += index.ToString();
        NumberInput.text = input;
            if (input.Length == 4) // 네 자리 입력되면
            {
                if (input == correctPassword) // 암호 일치 확인
                {
                    NumberInput.text = "Password is  Correct";
                    MotherQuiz.SendMessage("QuizCorrect");
                }
                else
                {
                    NumberInput.text = "Password is not Correct";
                    AudioManager.Instance.PlayEffect("InCorrect");
                }
            Invoke("Reset",2f);

            }
    }
    private void Reset()
    {
        input = "";
        NumberInput.text = input;
    }

}


