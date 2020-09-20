using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2 : MonoBehaviour, IGameBlock
{
    public Transform StartPos;
    public Transform EndPos;
    public Transform[] Points;
    public GameObject Barrier1;
    public GameObject Barrier2;
    public GameObject Barrier3;
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
        Barrier1.transform.Rotate(Barrier1.transform.rotation.x, Barrier1.transform.rotation.y, 0);
        Barrier2.transform.Rotate(Barrier2.transform.rotation.x, Barrier2.transform.rotation.y, 0);
        Barrier3.transform.Rotate(Barrier3.transform.rotation.x, Barrier3.transform.rotation.y, 0);
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

    // Update is called once per frame
    void Update()
    {
        if (isAnimStart)
        {
            Barrier1.transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * speed;
            Barrier2.transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * speed;
            Barrier3.transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
    }

    public void SpeedUp(float percent)
    {
        speed = (speed + (speed * percent));
    }

    public void Start()
    {
        speed = ((GameObject)GameObject.FindGameObjectWithTag("Player")).GetComponent<Config>().WheelRotateSpeed;
    }
}
