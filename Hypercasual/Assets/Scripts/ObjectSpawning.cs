using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawning : MonoBehaviour
{
    private bool sasmSet=false;
    public SceneAndScoreManagment sASM;
    public TextMeshProUGUI goodItemCounter, badItemCounter;
    public int gIN, bIN;
    public List<GameObject> ObjectsSpawned = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!sasmSet)
        {
            setSASM(GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>());
        }
        goodItemCounter.text = "Needed ingredients: " + gIN + "/5";
        badItemCounter.text = "Uneeded ingredients: " + bIN;
        if (gIN == 5)
        {
            LevelTransisitonTime();
        }
    }
    public void setSASM(SceneAndScoreManagment sassy)
    {
        sASM = sassy;
        sasmSet = true;
    }
    public void LevelTransisitonTime()
    {
        
    }
}
