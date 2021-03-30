using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
    {
    public Image timeBar;
    public float maxTime;
    public float timeLeft;
    public GameObject contune;
    public GameObject bar;
    public GameObject player;
    public GameObject start;
    bool isContune=false;
    private bool strt = false;


    void Start()
    {
        timeLeft = maxTime;
        contune.SetActive(false);
        player.SetActive(true);
        start.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bar.SetActive(true);
            start.SetActive(false);
            strt = true;


        }
        if (strt == true)
        {
            if (timeLeft > 0)
            {

                timeLeft -= Time.deltaTime;
                timeBar.fillAmount = timeLeft / maxTime;
            }
            else
                PlayAgain();
        }
    }
    public void PlayAgain() 
    {
        bar.SetActive(false);
        contune.SetActive(true);
        player.SetActive(false);
        



    }
    public void LoadeScene(int value)
    {
        SceneManager.LoadScene(value);
    
    

    }

}
