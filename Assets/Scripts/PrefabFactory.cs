
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrefabFactory : MonoBehaviour
{
    public Animator animator;
    public GameObject Block1Prefab;
    public GameObject Block2Prefab;
    public GameObject BlockStartPrefab;
    public GameObject BlockEndPrefab;
    public GameObject Block3Prefab;
    IGameBlock GameBlockStart;
    IGameBlock GameBlockEnd;
    List<IGameBlock> GameBlockList;
    public List<Transform> Path;
    public Transform Target;
    Vector3 CheckPoint;
    public bool GameStart = false;
    public Config settings;
    int healt = 3;
    float game_speed = 1.0f;
    public void Start()
    {
        GameBlockList = new List<IGameBlock>();
        Path = new List<Transform>();
        InitBlocks();
    }
    private void InitBlocks()
    {
        GameBlockStart = (Instantiate(BlockStartPrefab, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<IGameBlock>();
        GameBlockStart.GetGameObject().SetActive(false);
        GameBlockEnd = (Instantiate(BlockEndPrefab, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<IGameBlock>();
        GameBlockEnd.GetGameObject().SetActive(false);
        for (int i = 0; i< 10; i++)
        {
            GameBlockList.Add((Instantiate(Block1Prefab, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<IGameBlock>());
            GameBlockList.Add((Instantiate(Block2Prefab, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<IGameBlock>());
            GameBlockList.Add((Instantiate(Block3Prefab, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<IGameBlock>());
        }
        foreach(IGameBlock t in GameBlockList)
        {
            t.GetGameObject().SetActive(false);
        }
    }
    public IEnumerator CreateLevel()
    {
        while(GameBlockStart == null)
        {
            yield return new WaitForSeconds(1);
        }
        game_speed *= 0.5f;
        Path.Clear();
        healt = 3;
        CheckPoint = new Vector3(0, 0, 0);
        this.gameObject.transform.position = CheckPoint;
        this.gameObject.GetComponent<Animator>().enabled = true;
        Transform l_end_pos;
        GameBlockStart.GetGameObject().transform.position = new Vector3(0,0,0);
        GameBlockStart.GetGameObject().SetActive(true);
        l_end_pos = GameBlockStart.GetEndPos();
        Path.AddRange(GameBlockStart.GetPath());
        int random;

        foreach (IGameBlock t in GameBlockList)
        {
            t.SpeedUp(game_speed);
            random = Random.Range(0, 8);
            if(random == 3)
            {
                t.GetGameObject().transform.position = l_end_pos.position;
                t.StartAnimation();
                t.GetGameObject().SetActive(true);
                l_end_pos = t.GetEndPos();
                Path.AddRange(t.GetPath());
                
            }
            else
            {
                t.StopAnimation();
                t.GetGameObject().SetActive(false);
            }
        }
        GameBlockEnd.GetGameObject().transform.position = l_end_pos.position;
        GameBlockEnd.GetGameObject().SetActive(true);
        Path.AddRange(GameBlockEnd.GetPath());
        GameStart = true;
        Target = Path[0];
    }
    void Update()
    {
        if(GameStart)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isSpacePressed", true);
                float step = 5 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
                if (Vector3.Distance(transform.position, Target.position) < 0.001f)
                {
                    CheckPoint = Path[0].position;
                    Path.RemoveAt(0);
                    if (Path.Count > 0)
                    {
                        Target = Path[0];
                    }
                    else
                    {
                        GameStart = false;
                        StartCoroutine(CreateLevel());
                    }
                }
            }
            else
            {
                animator.SetBool("isSpacePressed", false);
            }
            var rotation = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
        }
        else
        {
           
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (IGameBlock t in GameBlockList)
            {
                t.SpeedUp(0.1f);
            }
        }
    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        if (healt > 0)
        {
            healt--;
            this.gameObject.transform.position = CheckPoint;
            this.gameObject.GetComponent<Animator>().enabled = true;
            GameStart = true;
        }
        else
        {
            game_speed = 0.5f;
            StartCoroutine(CreateLevel());
        }
    }
}
