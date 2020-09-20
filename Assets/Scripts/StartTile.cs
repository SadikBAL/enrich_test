using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartTile : MonoBehaviour, IGameBlock
{
    public Transform StartPos;
    public Transform EndPos;
    public Transform[] Points;
    public Transform GetEndPos()
    {
        return EndPos;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public List<Transform> GetPath()
    {
        List<Transform> TempPoints = new List<Transform>();
        TempPoints.Add(StartPos);
        foreach(Transform t in Points)
        {
            TempPoints.Add(t);
        }
        return TempPoints;
    }

    public Transform GetStartPos()
    {
        return StartPos;
    }

    public void RestartAnimation()
    {
    }

    public void SpeedUp(float percent)
    {
    }

    public void SetSpeed(int value)
    {
    }

    public void StartAnimation()
    {
    }

    public void StopAnimation()
    {
    }
}
