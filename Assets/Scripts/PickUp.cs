using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Gun scriptReference;
    public string itemName;
    [SerializeField] bool canPick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject playerPickUp;

    [SerializeField] GameObject webEvent;
    [SerializeField] GameObject OtherPlayerPickUp;
    [SerializeField] GameObject tablePickUp;


    private void Update()
    {
        if(canPick)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(itemName == "Candle")
                {
                    webEvent.SetActive(true);
                    if(OtherPlayerPickUp.activeSelf)
                    {
                        OtherPlayerPickUp.SetActive(false);
                        tablePickUp.SetActive(true);
                    }
                }
                if(itemName == "ShotGun")
                {
                    Debug.Log("Gun picked up!");
                    scriptReference.PickUpGun();
                }
                if(itemName == "Torch")
                {
                    webEvent.SetActive(false);
                    if (OtherPlayerPickUp.activeSelf)
                    {
                        OtherPlayerPickUp.SetActive(false);
                        tablePickUp.SetActive(true);
                    }
                }
                gameObject.SetActive(false);
                playerPickUp.SetActive(true);
                canPick = false;
                UIController.actionText = "";
                UIController.commandText = "";
                UIController.showActionText = false;
            }
        }
    }
    private void OnMouseOver()
    {
        if(PlayerCasting.distanceToInteract < 3)
        {
            canPick = true;
            UIController.actionText = itemName;
            UIController.commandText = "Pick Up";
            UIController.showActionText = true;
        }
        else
        {
            canPick = false;
            UIController.actionText = "";
            UIController.commandText = "";
            UIController.showActionText = false;
        }
    }

    void OnMouseExit()
    {
        canPick = false;
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.showActionText = false;
    }
}
