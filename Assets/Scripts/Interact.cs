using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string eventText;
    public string eventCommandText;
    public SlenderChase slenderScript; // assign your SlenderChase script reference

    [SerializeField] GameObject fadeIn;
    [SerializeField] bool canOpen;
    [SerializeField] bool hasKey;
    [SerializeField] bool hasGun;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject theCam;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] AudioSource lockedDoor;
    [SerializeField] GameObject doorObject;
    [SerializeField] GameObject flameObject;
    [SerializeField] GameObject webObject;
    [SerializeField] GameObject obstacle;

    private void Update()
    {
        if(canOpen)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (eventCommandText == "Open")
                {
                    if(hasKey)
                    {
                        StartCoroutine(OpeningDoor());
                    } 
                    else
                    {
                        StartCoroutine(DoorLocked());
                    }
                }
                if(eventCommandText == "Reload")
                {
                    if(hasGun)
                    {

                    }
                    else
                    {
                        //display the text for 5 seconds
                        StartCoroutine(NoGun());
                    }
                }
                if (eventCommandText == "Burn")
                {
                    StartCoroutine(BurnWeb());

                }
            }
        }
    }
    private void OnMouseOver()
    {
        if(PlayerCasting.distanceToInteract < 3)
        {
            canOpen = true;
            UIController.actionText = eventText;
            UIController.commandText = eventCommandText;
            UIController.showActionText = true;
        }
        else
        {
            canOpen = false;
            UIController.actionText = "";
            UIController.commandText = "";
            UIController.showActionText = false;
        }
    }

    void OnMouseExit()
    {
        canOpen = false;
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.showActionText = false;
    }

    IEnumerator NoGun()
    {
        textOnScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "You don't have a gun to reload!";
        textOnScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        textOnScreen.SetActive(false);
    }

    IEnumerator OpeningDoor()
    {
        doorObject.GetComponent<Animator>().Play("DoorOpenAnim");
        //remove the door's box collider so the player can walk through
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2);
    }
    IEnumerator DoorLocked()
    {
        theCam.SetActive(true);
        thePlayer.SetActive(false);
        textOnScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(true);
        textOnScreen.SetActive(false);
        thePlayer.SetActive(true);
        theCam.SetActive(false);
    }
    IEnumerator BurnWeb()
    {
        theCam.SetActive(true);
        thePlayer.SetActive(false);
        flameObject.SetActive(true);
        obstacle.SetActive(false);
        slenderScript.UnlockChase();
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
        fadeIn.SetActive(true);
        webObject.SetActive(false);
        flameObject.SetActive(false);
        thePlayer.SetActive(true);
        theCam.SetActive(false);
    }

}
