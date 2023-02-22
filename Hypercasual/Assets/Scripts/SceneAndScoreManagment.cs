using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndScoreManagment : MonoBehaviour
{
    public PhaseTwoTime pTT;
    public List<FoodItemsCollected> recipieIngredients = new List<FoodItemsCollected>();
    public int round, phase;
    public enum Recipie { Pizza, Hamburger};
    public Recipie currentRecipie;
    public SpriteLibrary SL;
    public FoodSpawner FS;
    public enum FoodItemsCollected {Pizza_Dough, Pizza_Pineapple, Pizza_Sauce, Pizza_Peperoni, Burger_Bun, Burger_Cheese, Burger_ketchapp, Burger_Mustard, Burger_Lettuce, none_left };
    public List<FoodItemsCollected> whatWasCollected=new List<FoodItemsCollected>();
    public int GoodItemScore, BadItemScore;
    public ObjectSpawning OS;
    public List<FoodItemsCollected> BurgerOrder = new List<FoodItemsCollected>(), PizzaOrder = new List<FoodItemsCollected>();
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindGameObjectsWithTag("SceneAndScore").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
       
        
        /*DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindGameObjectsWithTag("SceneAndScore").Length > 1)
        {
            Destroy(this.gameObject);
        }*/

        //test



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void setToBurger()
    {
        setRecipie(Recipie.Hamburger);
    }

    public void setToPizza()
    {
        setRecipie(Recipie.Pizza);
    }

    public void ontoPhase2()
    {
        SceneManager.LoadScene(1);
    }
    public void setRecipie(Recipie setittothis)
    {
        switch (setittothis)
        {
            case Recipie.Pizza:
                currentRecipie = Recipie.Pizza;
                OS.setSprites();
                break;
            case Recipie.Hamburger:
                currentRecipie = Recipie.Hamburger;
                OS.setSprites();
                break;
            default:
                break;
        }
        setRecipieIngridients();

    }

    public void updateWWC(bool goodCollect, bool collected)
    {
        switch (currentRecipie)
        {
            case Recipie.Pizza:
                if (goodCollect)
                {
                    if (collected)
                    {
                        whatWasCollected.Add(PizzaOrder[0]);
                        PizzaOrder.RemoveAt(0);
                    }
                    else
                    {
                        PizzaOrder.RemoveAt(0);
                    }
                }
                else
                {
                    if (collected)
                    {
                        whatWasCollected.Add(BurgerOrder[0]);
                        BurgerOrder.RemoveAt(0);
                    }
                    else
                    {
                        BurgerOrder.RemoveAt(0);
                    }
                }
                break;
            case Recipie.Hamburger:
                if (goodCollect)
                {
                    if (collected)
                    {
                        whatWasCollected.Add(BurgerOrder[0]);
                        BurgerOrder.RemoveAt(0);
                    }
                    else
                    {
                        BurgerOrder.RemoveAt(0);
                    }
                }
                else
                {
                    if (collected)
                    {
                        whatWasCollected.Add(PizzaOrder[0]);
                        PizzaOrder.RemoveAt(0);
                    }
                    else
                    {
                        PizzaOrder.RemoveAt(0);
                    }
                }
                    break;
            default:
                break;
        }
    }

    public void setRecipieIngridients()
    {
        switch (currentRecipie)
        {
            case Recipie.Pizza:
                recipieIngredients.Add(FoodItemsCollected.Pizza_Dough);
                recipieIngredients.Add(FoodItemsCollected.Pizza_Pineapple);
                recipieIngredients.Add(FoodItemsCollected.Pizza_Sauce);
                recipieIngredients.Add(FoodItemsCollected.Pizza_Peperoni);
                break;
            case Recipie.Hamburger:
                recipieIngredients.Add(FoodItemsCollected.Burger_Bun);
                recipieIngredients.Add(FoodItemsCollected.Burger_Cheese);
                recipieIngredients.Add(FoodItemsCollected.Burger_ketchapp);
                recipieIngredients.Add(FoodItemsCollected.Burger_Lettuce);
                recipieIngredients.Add(FoodItemsCollected.Burger_Mustard);
                break;
            default:
                break;
        }
        GameObject.FindGameObjectWithTag("Obstacle spawner").GetComponent<ObjectSpawning>().ChooseNextItem();
    }

    public FoodItemsCollected SpawnNext()
    {
        if (whatWasCollected.Count>0)
        {
            FoodItemsCollected temp;
            temp = whatWasCollected[0];
            whatWasCollected.RemoveAt(0);
            return temp;
        }
        else
        {
            pTT.CheckWork();
            print("Nothing left to ship"); 
            return FoodItemsCollected.none_left;
            
        }
        
    }
    
}
