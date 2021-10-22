using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string Name;
    public GameManager gameManager;
    public bool Start = false;
    public GameObject Highlighit;
    public GameObject HighlighitOpened;
    public SpriteRenderer spriteRenderer;
    public GameObject goat;
    public Door door1;
    public Door door2;
    public GameObject treasure;
    public bool DoorFaceTwo;
    public bool Highlighited;
    private void OnMouseDown()
    {
        if (DoorFaceTwo == true)
        {
            door1.Highlighit.SetActive(false);
            door2.Highlighit.SetActive(false);
            Highlighit.SetActive(true);
        }
        if (door1.Start == true || door2.Start == true || Start == true) return;
        gameManager.doorThatIsSelected = this;
        Start = true;
        Highlighit.SetActive(true);
    }

    void Update()
    {
        if (Highlighit.activeSelf == true)
        {
            Highlighited = true;
        }
        else
        {
            Highlighited = false;
        }
    }
}
