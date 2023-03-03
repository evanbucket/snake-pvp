using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AngryHeartSystem : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject heart1;
    public GameObject heart2;
    public int angryLife;
    private GameObject sadSnake;
    private int timer = 0;
   

    public void RemoveHeart()
    {
        fullHeart = emptyHeart;
    }

    public void TakeDamage(int d)
    {
        if (angryLife != 0) {
            angryLife -= d;
        }

        if(angryLife == 1) {
            heart1.GetComponent<Image>().sprite = emptyHeart;            
        }    
    }

    public void Update()
    {
        // Get sad heart system script and the sadLife variable
        sadSnake = GameObject.Find("Sad Snake");
        int sadLife = sadSnake.GetComponent<SadHeartSystem>().sadLife;

        if(angryLife == 0 && sadLife == 0) { 
            timer++;
        }

        if (timer > 10) {
            // if both snake's life is 0, reset game with hearts back at 1.
            if(angryLife == 0 && sadLife == 0) {
                Debug.Log("tie");
                angryLife = 1;
                GetComponent<AngryController>().ResetAngryState();

            } 
            // Otherwise, if sad is dead and angry isn't dead, load angry's win scene
            else if(sadLife == 0 && angryLife != 0) {
                heart2.GetComponent<Image>().sprite = emptyHeart;
                SceneManager.LoadScene("AngryWin", LoadSceneMode.Single);
            }
            timer = 0;
        }
    }
}

