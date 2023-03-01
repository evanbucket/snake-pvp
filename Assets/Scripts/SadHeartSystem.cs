using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SadHeartSystem : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject heart1;
    public GameObject heart2;
    public int sadLife;
    private GameObject angrySnake;

    public void RemoveHeart()
    {
        fullHeart = emptyHeart;
    }

    public void TakeDamage(int d)
    {
        if (sadLife != 0) {
        sadLife -= d;
        }

        if(sadLife == 1) {
            heart1.GetComponent<Image>().sprite = emptyHeart;            
        }
        // Get angry heart system and the angryLife variable
        angrySnake = GameObject.Find("Angry Snake");
        int angryLife = angrySnake.GetComponent<AngryHeartSystem>().angryLife;
    }

    public void Update
    {
        //PUT STUFF FROM ANGRY HEART SYSTEM HERE
    }
}