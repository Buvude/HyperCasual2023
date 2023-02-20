using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public SceneAndScoreManagment sasm;
    // Start is called before the first frame update
    void Start()
    {
        sasm = GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>();
        sasm.FS = this;
        SpawnNextFood(sasm.SpawnNext());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNextFood(SceneAndScoreManagment.FoodItemsCollected fSTemp)
    {
        switch (fSTemp)
        {
            case SceneAndScoreManagment.FoodItemsCollected.Pizza_Dough:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Pizza_Pineapple:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Pizza_Sauce:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Pizza_Peperoni:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Burger_Bun:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Burger_Cheese:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Burger_ketchapp:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Burger_Mustard:
                break;
            case SceneAndScoreManagment.FoodItemsCollected.Burger_Lettuce:
                break;
            default:
                break;
        }
    }
}
