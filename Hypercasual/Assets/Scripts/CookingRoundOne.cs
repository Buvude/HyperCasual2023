using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingRoundOne : MonoBehaviour
{
    
    public GameObject RTRoundOne;
    public TextMeshProUGUI Counter;
    public FoodSpawner FS;
    public bool FoodInArea;
    public SceneAndScoreManagment sasm;
    public int CurrentIngredientCount;
    private int IngredientsNeeded = 0;
    // Start is called before the first frame update
    void Start()
    {
        sasm = GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>();
        switch (sasm.currentRecipie)
        {
            case SceneAndScoreManagment.Recipie.Pizza:
                IngredientsNeeded = 4;
                break;
            case SceneAndScoreManagment.Recipie.Hamburger:
                IngredientsNeeded = 5;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Counter.text = "Ingredients Collected: " + CurrentIngredientCount.ToString() + "/" + IngredientsNeeded.ToString();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Debug Log triggered");
        print("Collider Entered");
        if (collision.gameObject.CompareTag("CookingIngredient"))
        {
            print("Cooking Ingredient Entered");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {

        /*Debug.Log("Debug Log triggered");
        print("Trigger Entered");*/
        if (other.gameObject.CompareTag("CookingIngredient"))
        {
            FoodInArea = true;
            /*print("Cooking Ingredient Entered");*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

       /* Debug.Log("Debug Log triggered");
        print("Trigger Exited");*/
        if (collision.gameObject.CompareTag("CookingIngredient"))
        {
            FoodInArea = false;
            /*print("Cooking Ingredient Exited");*/
        }
    }

    public void SelectBtnHit()
    {
        if (FoodInArea)
        {
            print("Food Was in the area when button was pressed");
        }
        else print("Food wasn't in the area when the button was pressed");
    }
}
