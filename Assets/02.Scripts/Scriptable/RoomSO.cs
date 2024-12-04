using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Room", menuName = "RoomInfo")]
public class RoomSO : ScriptableObject
{
    public string RoomName;

    public int QuizCount;
    public Vector3[] QuizPozitions;

    public float LimitTime;
    public int FullAchievement;

}
