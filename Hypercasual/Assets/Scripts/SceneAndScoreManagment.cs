using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndScoreManagment : MonoBehaviour
{
    public int GoodItemScore, BadItemScore;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindGameObjectsWithTag("SceneAndScore").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
