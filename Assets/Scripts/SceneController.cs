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
            //Debug.Log("Has recogido todas las frutas, enhorabuena!");

            try
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                Debug.Log("Juego Completado");
            }
        }
    }
}
