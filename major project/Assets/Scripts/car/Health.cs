using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

     void Update()
    {
        if(health > numberOfHearts)
        {
            health = numberOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if( i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if( i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("working");
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("health lost");
            health--;
        }
    }
}