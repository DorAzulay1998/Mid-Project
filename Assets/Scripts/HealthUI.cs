using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public static int health;
    public static int numOfHears;
    public static Image[] hearts;
    public static Sprite fullHeart;
    public static Sprite emptyHeart;
    void Start()
    {
        
    }

    static void HeartSystem()
    {   
        if(health > numOfHears)
        {
            health = numOfHears;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHears)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
