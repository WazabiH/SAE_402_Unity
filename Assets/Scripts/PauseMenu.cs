using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   // public GameObject PausePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    {
        
    }

    //public void Pause () {
        PausePanel.SetActive (true);
        Time.timeScale = 0;
    }

    //public void Continue () {
        PausePanel.SetActive (false);
        Time.timeScale = 1;
    }
}
