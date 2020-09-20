using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1 : MonoBehaviour, IGameBlock
{
    public Transform StartPos;
    public Transform EndPos;
    public Transform[] Points;

    public GameObject Left1;
    public Transform Left1Start;
    public Transform Left1End;
    Transform Left1Target;
    public GameObject Left2;
    public Transform Left2Start;
    public Transform Left2End;
    Transform Left2Target;
    public GameObject Right1;
    public Transform Right1Start;
    public Transform Right1End;
    Transform Right1Target;
    public GameObject Right2;
    public Transform Right2Start;
    public Transform Right2End;
    Transform Right2Target;
    public bool isAnimStart = false;
    float speed;
    public Transform GetEndPos()
    {
        return EndPos;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public Transform GetStartPos()
    {
        return StartPos;
    }
    public List<Transform> GetPath()
    {
        List<Transform> TempPoints = new List<Transform>();
        TempPoints.Add(StartPos);
        foreach (Transform t in Points)
        {
            TempPoints.Add(t);
        }
        return TempPoints;
    }
    public void RestartAnimation()
    {
        Left1.transform.position = Left1Start.position;
        Left1Target = Left1End;
        Left2.transform.position = Left2Start.position;
        Left2Target = Left2End;
        Right1.transform.position = Right1Start.position;
        Right1Target = Right1End;
        Right2.transform.position = Right2Start.position;
        Right2Target = Right2End;
    }

    public void StartAnimation()
    {
        RestartAnimation();
        isAnimStart = true;
    }

    public void StopAnimation()
    {
        isAnimStart = false;
    }
    void Update()
    {
        if(isAnimStart)
        {
            Left1.transform.position = Vector3.MoveTowards(Left1.transform.position, Left1Target.position, speed * Time.deltaTime);
            Left2.transform.position = Vector3.MoveTowards(Left2.transform.position, Left2Target.position, speed * Time.deltaTime);
            Right1.transform.position = Vector3.MoveTowards(Right1.transform.position, Right1Target.position, speed * Time.deltaTime);
            Right2.transform.position = Vector3.MoveTowards(Right2.transform.position, Right2Target.position, speed * Time.deltaTime);
            if (Vector3.Distance(Left1.transform.position, Left1Target.position) < 0.001f)
            {
                if(Left1Target == Left1Start)
                {
                    Left1Target = Left1End;
                }
                else
                {
                    Left1Target = Left1Start;
                }
            }
            if (Vector3.Distance(Left2.transform.position, Left2Target.position) < 0.001f)
            {
                if (Left2Target == Left2Start)
                {
                    Left2Target = Left2End;
                }
                else
                {
                    Left2Target = Left2Start;
                }
            }
            if (Vector3.Distance(Right1.transform.position, Right1Target.position) < 0.001f)
            {
                if (Right1Target == Right1Start)
                {
                    Right1Target = Right1End;
                }
                else
                {
                    Right1Target = Right1Start;
                }
            }
            if (Vector3.Distance(Right2.transform.position, Right2Target.position) < 0.001f)
            {
                if (Right2Target == Right2Start)
                {
                    Right2Target = Right2End;
                }
                else
                {
                    Right2Target = Right2Start;
                }
            }

        }
    }

    public void SpeedUp(float percent)
    {
        speed = (float)(speed + (speed * percent));
    }

    public void Start()
    {
        speed = ((GameObject)GameObject.FindGameObjectWithTag("Player")).GetComponent<Config>().WallMoveSpeed;
    }
}
