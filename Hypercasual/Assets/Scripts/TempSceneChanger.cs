using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        GameObject.FindGameObjectWithTag("SceneAndScore").transform.parent = this.gameObject.transform;
        SceneManager.LoadScene(0);
    }
}
