using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PrefabFactory prefabFactory;
    void Start()
    {
        StartCoroutine(prefabFactory.CreateLevel());
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Barrier" && prefabFactory.GameStart)
        {
            prefabFactory.GameStart = false;
            this.gameObject.GetComponent<Animator>().enabled = false;
            StartCoroutine(prefabFactory.Restart());
        }
    }
}
