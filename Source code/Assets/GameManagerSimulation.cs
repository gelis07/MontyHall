using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerSimulation : MonoBehaviour
{
    private DoorSimulation DoorSelected;
    private DoorSimulation doorWithTheCar;
    private DoorSimulation doorThatWillBeOpened;
    public bool Change;
    public DoorSimulation[] Doors;

    public Sprite doorOpened;
    public Sprite doorclosed;

    private bool didit = false;
    private bool didit2 = false;
    private bool didit3 = false;
    private int timesrun;
    private float wins;
    private float losses;
    private DoorSimulation changedoor;
    private bool next;
    public GameObject Panel;
    public TMP_InputField Timestorun;
    public TextMeshProUGUI textWIns;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    private float winper;
    private float loseper;
    private int test;
    public Color color;
    public Image image;
    public Image image2;
    private float test2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //int randomNumber = Random.Range(0, 3);
        //DoorSelected = Doors[randomNumber];
        //DoorSelected.Highlighit.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        test2 = 2.1f;

        text2.text = "Win  Percentance: " + winper.ToString("0.00");
        text3.text = "Loss Percentance: " + loseper.ToString("0.00");
        int.TryParse(Timestorun.text, out test);
        textWIns.text = "Wins: " + wins + " Losses: " + losses;
        if (timesrun == test)
        {
            print("wins: " + wins + " losses: " + losses);
            return;
        }
        if (next)
        {
            text.text = "Pick a door";
            int randomNumber = Random.Range(0, 3);
            DoorSelected = Doors[randomNumber];
            DoorSelected.Highlighit.SetActive(true);
            StartCoroutine(Wait());
            next = false;
            print(timesrun);
            didit2 = false;
            didit3 = false;
            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].spriteRenderer.sprite = doorclosed;
                Doors[i].goat.SetActive(false);
                Doors[i].treasure.SetActive(false);
                //Doors[i].Highlighit.SetActive(false);
                Doors[i].HighlighitOpened.SetActive(false);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        doorWithTheCar = DoorSelected;

        int randomNumber = Random.Range(0, Doors.Length);
        doorWithTheCar = Doors[randomNumber];
        doorThatWillBeOpened = doorWithTheCar;
        while (doorThatWillBeOpened == doorWithTheCar || doorThatWillBeOpened == DoorSelected)
        {
            int randomNumber2 = Random.Range(0, Doors.Length);
            doorThatWillBeOpened = Doors[randomNumber2];
        }
        text.text = "Host opened " + doorThatWillBeOpened.gameObject.name + ". Do you want to swap doors?";
        doorThatWillBeOpened.spriteRenderer.sprite = doorOpened;
        doorThatWillBeOpened.goat.SetActive(true);
        if (!didit2)
        {
            StartCoroutine(Wait2());
            didit2 = true;
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1);
        if (Change)
        {
            changedoor = DoorSelected;
            while (changedoor == DoorSelected || changedoor == doorThatWillBeOpened)
            {
                int randomnumber3 = Random.Range(0, Doors.Length);
                changedoor = Doors[randomnumber3];
            }

            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].Highlighit.SetActive(false);
            }
            changedoor.Highlighit.SetActive(true);
            if (!didit3)
            {
                StartCoroutine(OpenDoors());
                didit3 = true;
            }
        }
        else
        {
            changedoor = DoorSelected;
            if (!didit3)
            {
                StartCoroutine(OpenDoors());
                didit3 = true;
            }
        }
    }

    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].spriteRenderer.sprite = doorOpened;
            if (Doors[i] != doorWithTheCar)
            {
                Doors[i].goat.SetActive(true);
            }
            else
            {
                Doors[i].treasure.SetActive(true);
            }
        }

        if (changedoor == doorWithTheCar)
        {
            print("you won");
            wins += 1;
        }
        else
        {
            print("you lost");
            losses += 1;
        }

        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].Highlighit.SetActive(false);
        }
        DoorSelected = changedoor;
        DoorSelected.HighlighitOpened.SetActive(true);
        doorWithTheCar.goat.SetActive(false);
        StartCoroutine(WaitUntillNextRound());
    }

    IEnumerator WaitUntillNextRound()
    {
        yield return new WaitForSeconds(1);
        next = true;
        timesrun += 1;
        if (timesrun != 0)
        {
            winper = (wins * 100f) / timesrun ;
        }

        if (timesrun != 0)
        {
            loseper = (losses * 100f) / timesrun;
        }
    }

    public void Speedup()
    {
        Time.timeScale *= 2;
    }

    public void SlowDown()
    {
        Time.timeScale /= 2;
    }

    public void Change1()
    {
        Change = true;
        image.color = color;
        image2.color = Color.white;
    }

    public void DontChange2()
    {
        Change = false;
        image.color = Color.white;
        image2.color = color;
    }

    public void Run()
    {
        next = true;
        Panel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
