using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryHeartSystem : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject heart1;
    public GameObject heart2;
    public int life;

    public void RemoveHeart()
    {
        fullHeart = emptyHeart;
    }

    public void TakeDamage(int d)
    {
        life -= d;
        if(life == 1) {
            heart1.GetComponent<Image>().sprite = emptyHeart;            
        }
        if(life == 0) {
            heart2.GetComponent<Image>().sprite = emptyHeart;
        }
    }
}

