using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour, IGameBlock
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
        foreach (Transform t in Points)
        {
            TempPoints.Add(t);
        }
        TempPoints.Add(EndPos);
        return TempPoints;
    }
    public Transform GetStartPos()
    {
        return StartPos;
    }

    public void RestartAnimation()
    {
    }

    public void SetSpeed(int value)
    {
    }

    public void SpeedUp(float percent)
    {
    }

    public void StartAnimation()
    {
    }

    public void StopAnimation()
    {
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
