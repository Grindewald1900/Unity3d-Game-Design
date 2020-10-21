using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas SharedInstance;
    public Button _btnOk;
    public Button _btnCancel;
    public Text _textConversation;
    public Text _textQuest;

    // Start is called before the first frame update
    void Start()
    {
        SharedInstance = this;
        gameObject.SetActive(false);
        _btnOk.onClick.AddListener(OnAccept);
        _btnCancel.onClick.AddListener(OnCancel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShowConversation(string content)
    {
        gameObject.SetActive(true);
        _textConversation.text = content;
    }
    
    public void OnAccept()
    {
        // _textConversation.text = "Thanks, I'm here waiting for you!";
        _textQuest.text = "Quest: kill Goblin (ongoing):\n  Kill the Bog Goblin in the Peter Curry marsh";
        OnClose();
    }
    
    public void OnCancel()
    {
        // _textConversation.text = "Okay, maybe next time...";
        OnClose();
    }
    public void OnClose()
    {
        gameObject.SetActive(false);
    }
    
}
