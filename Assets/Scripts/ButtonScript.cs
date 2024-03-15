using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public AudioSource sound;

    public void StartButton()
    {
        sound.Play();
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        sound.Play();
        Application.Quit();
    }

    public void MenuButton()
    {
        sound.Play();
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
