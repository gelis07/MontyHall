using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Simulation : MonoBehaviour
{
    public int TimesToRun;
    public bool Change;
    private int doorSelected;
    private int Doorwithcar;
    private int DoorThatWillBeOpened;
    private bool didit = true;
    private int wins;
    private int losts;
    public TextMeshProUGUI text;
    public TMP_InputField TimesToRun1;
    public GameObject text1;
    public Image ChangeButton1;
    public Image NotChangeButton1;
    public Color color;
    private void Update()
    {
        if (Change == true)
        {
            ChangeButton1.color = color;
            NotChangeButton1.color = Color.white;
        }
        else
        {
            ChangeButton1.color = Color.white;
            NotChangeButton1.color = color;
        }
        int.TryParse(TimesToRun1.text, out TimesToRun);
        if (didit == false)
        {
            Simulate();
        }
    }

    public void Run()
    {
        didit = false;
        text1.SetActive(true);
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ChangeButton()
    {
        Change = true;
    }
    public void NotChangeButton()
    {
        Change = false;
    }
    void Simulate()
    {
        didit = true;
        for (int i = 0; i < TimesToRun; i++)
        {
            doorSelected = Random.Range(0, 3);
            Doorwithcar = Random.Range(0, 3);

            DoorThatWillBeOpened = Doorwithcar;

            while (DoorThatWillBeOpened == Doorwithcar || DoorThatWillBeOpened == doorSelected)
            {
                DoorThatWillBeOpened = Random.Range(0, 3);
            }

            if (Change == true)
            {
                int NewDoorSelected = doorSelected;
                while (NewDoorSelected == doorSelected || NewDoorSelected == DoorThatWillBeOpened)
                {
                    NewDoorSelected = Random.Range(0, 3);
                }

                doorSelected = NewDoorSelected;
            }

            if (doorSelected == Doorwithcar)
            {
                wins += 1;
            }
            else
            {
                losts += 1;
            }
        }

        text.text = "Wins: " + wins + " Losts: " + losts;
        wins = 0;
        losts = 0;
    }
}
