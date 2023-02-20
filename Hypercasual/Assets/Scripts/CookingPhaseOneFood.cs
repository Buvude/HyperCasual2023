using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPhaseOneFood : MonoBehaviour
{
    /*public int CurrentIngredientCount;
    private int IngredientsNeeded = 0;*/
    public Animator selfAnimation;
    /*public SceneAndScoreManagment sasm;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PostAnimation()
    {
        print("Made it to post animation");
        selfAnimation.enabled = false;
    }
}
