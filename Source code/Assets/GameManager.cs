
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Door doorA;
    public Door doorB;
    public Door doorC;
    public Door[] doors;
    public Door doorThatIsSelected;
    private Door doorWithTheCar;
    private bool didIt;
    private Door doorThatWillBeOpened;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Text2;
    private Door changedoor;
    public GameObject button1;
    public GameObject button2;
    public GameObject Panel;
    public Sprite doorOpened;
    private void Update()
    {
        if (doorA.Start)
        {
            doorThatIsSelected = doorA;
        }
        if (doorB.Start)
        {
            doorThatIsSelected = doorB;
        }
        if (doorC.Start)
        {
            doorThatIsSelected = doorC;
        }

        if (doorThatIsSelected.Start == true && didIt == false)
        {
            doorWithTheCar = doorThatIsSelected;
            int randomNumber = Random.Range(0, doors.Length);
            doorWithTheCar = doors[randomNumber];
            doorThatWillBeOpened = doorWithTheCar;
            while (doorThatWillBeOpened == doorWithTheCar || doorThatWillBeOpened == doorThatIsSelected)
            {
                int randomNumber2 = Random.Range(0, doors.Length);
                doorThatWillBeOpened = doors[randomNumber2];
            }
            print(doorThatWillBeOpened.Name + " Is the door with that will be opened");
            Text.text = "Host opens " + doorThatWillBeOpened.Name +
                        " \n Do you want to swap doors? Or stick with your choice?";
            doorThatWillBeOpened.spriteRenderer.sprite = doorOpened;
            doorThatWillBeOpened.goat.SetActive(true);
            button2.SetActive(true);
            didIt = true;
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].DoorFaceTwo = true;
                doorThatWillBeOpened.DoorFaceTwo = false;
            }
        }
    }
    
    

    
    public void Change()
    {
        changedoor = doorThatIsSelected;
        while (changedoor == doorThatIsSelected || changedoor == doorThatWillBeOpened)
        {
            int randomnumber3 = Random.Range(0, doors.Length);
            changedoor = doors[randomnumber3];
        }

        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].spriteRenderer.sprite = doorOpened;
            if (doors[i] != doorWithTheCar)
            {
                doors[i].goat.SetActive(true);
            }
            else
            {
                doors[i].treasure.SetActive(true);
            }
        }
        /*
        doorWithTheCar.spriteRenderer.sprite = doorOpened;
        doorWithTheCar.treasure.SetActive(true);
        doorThatIsSelected.spriteRenderer.sprite = doorOpened;
        doorThatWillBeOpened.spriteRenderer.sprite = doorOpened;
        if (doorThatIsSelected != doorWithTheCar)
        {
            doorThatIsSelected.goat.SetActive(true);
        }
        if (doorThatWillBeOpened != doorWithTheCar)
        {
            doorThatWillBeOpened.goat.SetActive(true);
        }

        Door doorthatwillopenedautomatically = doorWithTheCar;

        */
        /*
        if (changedoor == doorWithTheCar)
        {
            print("You won!");
            Text2.text = "You Won!";
            Panel.SetActive(true);
        }
        else
        {
            print("You Lost");
            Text2.text = "You Lost!";
            Panel.SetActive(true);
        }
        */
    }
    
    public void NotChange()
    {
        while (changedoor == doorThatIsSelected || changedoor == doorThatWillBeOpened)
        {
            int randomnumber3 = Random.Range(0, doors.Length);
            changedoor = doors[randomnumber3];
        }

        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].spriteRenderer.sprite = doorOpened;
            if (doors[i] != doorWithTheCar)
            {
                doors[i].goat.SetActive(true);
            }
            else
            {
                doors[i].treasure.SetActive(true);
            }
        }
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].spriteRenderer.sprite = doorOpened;
            if (doors[i] != doorWithTheCar)
            {
                doors[i].goat.SetActive(true);
            }
            else
            {
                doors[i].treasure.SetActive(true);
            }
        }
        if (doorThatIsSelected == doorWithTheCar)
        {
            print("you won");
            Text2.text = "You Won!";
            Panel.SetActive(true);
        }
        else
        {
            print("You lost");
            Text2.text = "You Lost!";
            Panel.SetActive(true);
        }
    }

    public void LockIn()
    {

        Door DoorLockedIn = new Door();
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].Highlighited == true)
            {
                 DoorLockedIn = doors[i];
            }
        }

        if (DoorLockedIn == doorWithTheCar)
        {
            print("You won!");
            print("You selected " + DoorLockedIn.Name);
        }
        else
        {
            print("You lost!");
            print("You selected " + DoorLockedIn.Name);
        }
        while (changedoor == doorThatIsSelected || changedoor == doorThatWillBeOpened)
        {
            int randomnumber3 = Random.Range(0, doors.Length);
            changedoor = doors[randomnumber3];
        }

        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].spriteRenderer.sprite = doorOpened;
            if (doors[i] != doorWithTheCar)
            {
                doors[i].goat.SetActive(true);
            }
            else
            {
                doors[i].treasure.SetActive(true);
            }
        }
        DoorLockedIn.Highlighit.SetActive(false);
        DoorLockedIn.HighlighitOpened.SetActive(true);
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
