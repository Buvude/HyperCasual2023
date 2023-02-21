using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawning : MonoBehaviour
{
    public Animator dumpy, goodColect, badCollect;
    public int nOGIL, nOBIL, nODL, totalToGenerate;
    private int randomNumberToGenerate, randomChoice;
    private bool sasmSet=false;
    public SceneAndScoreManagment sASM;
    public TextMeshProUGUI goodItemCounter, badItemCounter;
    public int gIN=0, bIN=0;
    public List<GameObject> ObjectsSpawned = new List<GameObject>();
    public int numberofGoodItemsNeeded=0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        goodItemCounter.text = "Needed ingredients: " + gIN + "/"+numberofGoodItemsNeeded;
        badItemCounter.text = "Uneeded ingredients: " + bIN;
        if (totalToGenerate <= 0)
        {
            sASM.ontoPhase2();
        }
        /* if (gIN == 5)
         {
             LevelTransisitonTime();
         }*/ //making the difficulty scalable
    }

    public void calculateTotal()
    {
        totalToGenerate = nOGIL + nOBIL + nODL;
    }
    public void setSASM(SceneAndScoreManagment sassy)
    {
        sASM = sassy;
        sASM.OS = this;
        sasmSet = true;
    }
    public void LevelTransisitonTime()
    {
        sASM.ontoPhase2();
    }

    public void setSprites()
    {
        switch (sASM.currentRecipie)
        {
            case SceneAndScoreManagment.Recipie.Pizza:
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.PizzDough);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.PizzBestTopping);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.PizzPep);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.PizzSauce);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.hBurgBun);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.hBurgCheese);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.hBurgKetchapp);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.hBurgLetuce);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.hBurgMustard);
                nOGIL = 4;
                nOBIL = 5;
                nODL = 0;
                numberofGoodItemsNeeded = 4;
                calculateTotal();
                break;
            case SceneAndScoreManagment.Recipie.Hamburger:
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.PizzDough);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.PizzBestTopping);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.PizzPep);
                badCollect.GetComponent<BadCollectables>().foodItem.Add(sASM.SL.PizzSauce);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.hBurgBun);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.hBurgCheese);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.hBurgKetchapp);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.hBurgLetuce);
                goodColect.GetComponent<GoodCollectables>().foodItem.Add(sASM.SL.hBurgMustard);
                nOBIL = 4;
                nOGIL = 5;
                nODL = 0;
                numberofGoodItemsNeeded = 5;
                calculateTotal();
                break;
            default:
                break;
        }
    }

    public void ChooseNextItem()
    {
        if (totalToGenerate <= 0)
        {
            LevelTransisitonTime();
        }
        randomChoice= Random.Range(1, 3);
        switch (randomChoice)
        {
            /*case 1:
                {
                    SpawnDumpy();
                    break;
                }*/
            case 2:
                {
                    SpawnGC();
                    break;
                }
            case 1:
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
            goodColect.GetComponent<SpriteRenderer>().sprite=goodColect.GetComponent<GoodCollectables>().foodItem[0];
            goodColect.GetComponent<GoodCollectables>().foodItem.RemoveAt(0);
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
            badCollect.GetComponent<SpriteRenderer>().sprite = badCollect.GetComponent<BadCollectables>().foodItem[0];
            badCollect.GetComponent<BadCollectables>().foodItem.RemoveAt(0);
            badCollect.SetTrigger("Move");
        }
        else
        {
            SpawnDumpy();
        }
        
    }


}
