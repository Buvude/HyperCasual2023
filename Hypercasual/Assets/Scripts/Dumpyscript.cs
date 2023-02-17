using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpyscript : MonoBehaviour
{
    public Transform set;
    private bool privcol;
    public bool collected;
    public List<Sprite> foodItem = new List<Sprite>();
    public ObjectSpawning OS;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision + " has entered collision");
    }*/
    public void ResetCol()
    {
        privcol = false;
        collected = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("entered");
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        privcol = true;
        print("Collected");
    }
    public void ResetPosition()
    {
        this.gameObject.transform.position = set.position;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void postAnimation()
    {
        if (privcol)
        {
            collected = true;
        }
        else
        {
            ResetPosition();
        }
        OS.nODL--;
        OS.ChooseNextItem();
    }
}
