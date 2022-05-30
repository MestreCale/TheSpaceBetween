using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderFromMenu : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {

        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.GoToGame();
            
        }
    }
}
