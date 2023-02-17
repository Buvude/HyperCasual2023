using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawning : MonoBehaviour
{
    public Animator dumpy, goodColect, badCollect;
    public int nOGIL, nOBIL, nODL;
    private int randomNumberToGenerate, randomChoice, totalToGenerate;
    private bool sasmSet=false;
    public SceneAndScoreManagment sASM;
    public TextMeshProUGUI goodItemCounter, badItemCounter;
    public int gIN=0, bIN=0;
    public List<GameObject> ObjectsSpawned = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        totalToGenerate = nOGIL + nOBIL + nODL;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().collected)
        {
            GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().ResetCol();
            GameObject.FindGameObjectWithTag("needed ingredient").GetComponent<GoodCollectables>().ResetPosition();
            //nOGIL--;
            gIN++;

        }

        if (GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().collected)
        {
            GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().ResetCol(); ;
            GameObject.FindGameObjectWithTag("unNeededIngredients").GetComponent<BadCollectables>().ResetPosition();
            //nOBIL--;
            bIN++;

        }
        if (GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().collected)
        {
            GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().ResetCol();
            GameObject.FindGameObjectWithTag("dumpy").GetComponent<Dumpyscript>().ResetPosition();
            if (bIN > 0)
            {
                bIN--;
            }
            else if(gIN>0)
            {
                gIN--;
            }
            //nODL--;

        }
        if (!sasmSet)
        {
            setSASM(GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>());
        }
        goodItemCounter.text = "Needed ingredients: " + gIN + "/5";
        badItemCounter.text = "Uneeded ingredients: " + bIN;
       /* if (gIN == 5)
        {
            LevelTransisitonTime();
        }*/ //making the difficulty scalable
    }
    public void setSASM(SceneAndScoreManagment sassy)
    {
        sASM = sassy;
        sasmSet = true;
    }
    public void LevelTransisitonTime()
    {
        
    }

    public void ChooseNextItem()
    {
        if (totalToGenerate <= 0)
        {
            LevelTransisitonTime();
        }
        randomChoice= Random.Range(1, 4);
        switch (randomChoice)
        {
            case 1:
                {
                    SpawnDumpy();
                    break;
                }
            case 2:
                {
                    SpawnGC();
                    break;
                }
            case 3:
                {
                    SpawnBC();
                    break;
                }
            default:
                break;
        }
    }
    public void SpawnDumpy()
    {
        if (nODL > 0)
        {
            dumpy.SetTrigger("Move");
        }
        else
        {
            SpawnGC();
        }
    }
    public void SpawnGC()
    {
        if (nOGIL > 0)
        {
            goodColect.SetTrigger("Move");
        }
        else
        {
            SpawnBC();
        }
        
    }

    public void SpawnBC()
    {
        if (nOBIL > 0)
        {
            badCollect.SetTrigger("Move");
        }
        else
        {
            SpawnDumpy();
        }
        
    }


}
