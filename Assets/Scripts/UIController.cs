using UnityEngine;

public class UIController : MonoBehaviour
{
    public static string actionText;
    public static string commandText;
    public static bool showActionText;
    [SerializeField] GameObject actionBox;
    [SerializeField] GameObject commandBox;
    [SerializeField] GameObject interactCross;

    // Update is called once per frame
    void Update()
    {
        if(showActionText)
        {
            actionBox.SetActive(true);
            commandBox.SetActive(true);
            actionBox.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = actionText;
            commandBox.GetComponentInChildren<TMPro.TextMeshProUGUI>().text =  "[E] " + commandText;
        }
        else
        {
            actionBox.SetActive(false);
            commandBox.SetActive(false);
            interactCross.SetActive(false);
        }
    }
}
