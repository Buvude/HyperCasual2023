using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawning : MonoBehaviour
{
    private bool sasmSet=false;
    public SceneAndScoreManagment sASM;
    public TextMeshProUGUI goodItemCounter, badItemCounter;
    public int gIN=0, bIN=0;
    public List<GameObject> ObjectsSpawned = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().collected)
        {
            GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().collected = false;
            GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().ResetPosition();            
            gIN++;

        }

        if (GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().collected)
        {
            GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().collected = false;
            GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().ResetPosition();
            bIN++;

        }
        if (GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().collected)
        {
            GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().collected = false;
            GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().ResetPosition();
            if (bIN > 0)
            {
                bIN--;
            }
            else if(gIN>0)
            {
                gIN--;
            }

        }
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
