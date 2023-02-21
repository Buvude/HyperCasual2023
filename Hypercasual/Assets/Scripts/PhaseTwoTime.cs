using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwoTime : MonoBehaviour
{
    public GameObject WinBurger, LossBurger, WinPizza, LossPizza;
    public CookingRoundOne cr1;
    public SceneAndScoreManagment sasm;
    // Start is called before the first frame update
    void Start()
    {

        sasm = GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>();
        sasm.pTT = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWork()
    {
        switch (sasm.currentRecipie)
        {
            case SceneAndScoreManagment.Recipie.Pizza:
                {
                    foreach (SceneAndScoreManagment.FoodItemsCollected FIC in sasm.recipieIngredients)
                    {
                        if (!cr1.FoodCollectedInRoundOne.Contains(FIC))
                        {
                            failure();
                            break;
                        }
                    }
                    Success();
                }
                break;
            case SceneAndScoreManagment.Recipie.Hamburger:
                {
                    foreach (SceneAndScoreManagment.FoodItemsCollected FIC in sasm.recipieIngredients)
                    {
                        if (!cr1.FoodCollectedInRoundOne.Contains(FIC))
                        {
                            failure();
                        }
                    }
                    Success();
                }
                break;
            default:
                break;
        }
    }
    public void failure()
    {
        switch (sasm.currentRecipie)
        {
            case SceneAndScoreManagment.Recipie.Pizza:
                /*LossPizza.GetComponent<Endings>();*/
                LossPizza.SetActive(true);
                break;
            case SceneAndScoreManagment.Recipie.Hamburger:
                LossBurger.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Success()
    {
        switch (sasm.currentRecipie)
        {
            case SceneAndScoreManagment.Recipie.Pizza:
                WinPizza.SetActive(true);
                break;
            case SceneAndScoreManagment.Recipie.Hamburger:
                WinBurger.SetActive(true);
                break;
            default:
                break;
        }
    }
}
