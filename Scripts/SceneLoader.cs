using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
public class SceneLoader : MonoBehaviour
{
    public void RelaodGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Reset time scale to normal
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
