using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameBlock 
{
    GameObject GetGameObject();
    void StartAnimation();
    void StopAnimation();
    void RestartAnimation();

    Transform GetStartPos();
    Transform GetEndPos();
    List<Transform> GetPath();
    void SpeedUp(float percent);

}
