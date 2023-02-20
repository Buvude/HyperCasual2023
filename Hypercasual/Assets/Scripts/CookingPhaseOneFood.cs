using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPhaseOneFood : MonoBehaviour
{
    /*public int CurrentIngredientCount;
    private int IngredientsNeeded = 0;*/
    public Animator selfAnimation;
    public SceneAndScoreManagment sasm;
    public SceneAndScoreManagment.FoodItemsCollected whatAmI;
    public FoodSpawner FS;
    // Start is called before the first frame update
    void Start()
    {
        sasm = GameObject.FindGameObjectWithTag("SceneAndScore").GetComponent<SceneAndScoreManagment>();
        FS = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PostAnimation()
    {
        print("Made it to post animation");
        FS.SpawnNextFood(sasm.SpawnNext());
        selfAnimation.enabled = false;
        Destroy(this.gameObject);
    }
}
