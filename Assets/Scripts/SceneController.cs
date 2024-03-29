using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject coinsCollection;
    public TextMeshProUGUI textCoinsInfo;

    public int coinsRemaining;
    private int coinsTotal;

    // Start is called before the first frame update
    void Start()
    {

        coinsRemaining = coinsCollection.gameObject.transform.childCount;
        coinsTotal = coinsCollection.gameObject.transform.childCount;
        checkCoinsRemaining();
    }

    public void checkCoinsRemaining()
    {
        textCoinsInfo.text = (coinsTotal - coinsRemaining).ToString() + " / " + coinsTotal.ToString();

        if (coinsRemaining == 0) 
        {

            if(! (SceneManager.GetActiveScene().buildIndex == 2))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
