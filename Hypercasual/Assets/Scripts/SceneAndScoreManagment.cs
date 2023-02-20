using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndScoreManagment : MonoBehaviour
{
    public enum Recipie { Pizza, Hamburger};
    public Recipie currentRecipie;
    public SpriteLibrary SL;
    public FoodSpawner FS;
    public enum FoodItemsCollected {Pizza_Dough, Pizza_Pineapple, Pizza_Sauce, Pizza_Peperoni, Burger_Bun, Burger_Cheese, Burger_ketchapp, Burger_Mustard, Burger_Lettuce, none_left };
    public List<FoodItemsCollected> whatWasCollected=new List<FoodItemsCollected>();
    public int GoodItemScore, BadItemScore;
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

    public FoodItemsCollected SpawnNext()
    {
        if (whatWasCollected.Capacity > 0)
        {
            FoodItemsCollected temp;
            temp = whatWasCollected[0];
            whatWasCollected.RemoveAt(0);
            return temp;
        }
        else return FoodItemsCollected.none_left;
        
    }
    
}
