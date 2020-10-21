using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    public Button BtnMainMenu;
    public Button BtnQuest;

    public Text TextQuest;
    // Start is called before the first frame update
    void Start()
    {
        BtnMainMenu.onClick.AddListener(OnMainMenu);
        BtnQuest.onClick.AddListener(OnQuest);
    }
    public void OnMainMenu()
    {
        // _textConversation.text = "Thanks, I'm here waiting for you!";

    }
    
    public void OnQuest()
    {
        TextQuest.text = "Your Quest:";
    }
}
