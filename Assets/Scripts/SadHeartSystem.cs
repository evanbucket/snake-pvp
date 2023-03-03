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
    private int timer = 0;

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
    }

    public void Update()
    {
        // Get angry heart system and the angryLife variable
        angrySnake = GameObject.Find("Angry Snake");
        int angryLife = angrySnake.GetComponent<AngryHeartSystem>().angryLife;

        if(angryLife == 0 && sadLife == 0) { 
            timer++;
        }

        if (timer > 10) {
            // if both snake's life is 0, reset game with hearts back at 1.
            if(angryLife == 0 && sadLife == 0) {
                Debug.Log("tie");
                sadLife = 1;
                GetComponent<SadController>().ResetSadState();

            }
            // Otherwise, if angry is dead and sad isn't, load sad's win scene 
            else if(angryLife == 0 && sadLife != 0) {
                heart2.GetComponent<Image>().sprite = emptyHeart;
                SceneManager.LoadScene("SadWin", LoadSceneMode.Single);
            }
            timer = 0;
        }
    }
}