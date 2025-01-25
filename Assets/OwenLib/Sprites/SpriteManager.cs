using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] sprites;
    private Sprite[] spriteList;
    private void Awake()
    {
        spriteList = new Sprite[sprites.Length+1];
        spriteList[0] = gameObject.GetComponent<SpriteRenderer>().sprite;
        for(int i = 0; i < sprites.Length; i++) 
        {
            spriteList[i + 1] = sprites[i];
        }
    }
    // Start is called before the first frame update
    public void setSprite(int id)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[id];
    }
    // Update is called once per frame
}
