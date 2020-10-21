using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Utils;

public class LordController : MonoBehaviour
{
    [FormerlySerializedAs("LordAnimator")] public Animator lordAnimator;
    public GameObject player;
    
    public Text text;
    private float _range;
    private static readonly int Grating = Animator.StringToHash("grating");
    private static readonly int Talk = Animator.StringToHash("talk");
    private bool _setGreeting = false;
    private bool _isAccept = false;
    private bool _isFinished = false;
    private string _conversation;

    private void Start()
    {
        lordAnimator.SetBool(Talk, false);
        // text = gameObject.GetComponent<Text>();
    }

    // // Update is called once per frame
    // private void OnGUI()
    // {
    //     GUI.Label(new Rect(Screen.width / 10f, Screen.height/ 12f, Screen.width/1.5f, Screen.height/ 4f), "_conversation" );
    //
    // }

    private void FixedUpdate()
    {
        _range = Vector3.Distance(transform.position, player.transform.position);
        // lordAnimator.SetBool(Grating, !(_range > 50));

        if (_range < 20)
        {
            if (!_setGreeting)
            {
                MainCanvas.SharedInstance.OnShowConversation("Lord Goldbloom:\n Greetings human!" + "\nThe Bishops Bog Goblin, which lives behind the Athletics center, has been terrorizing " 
                    + "students and must be destroyed.");

                lordAnimator.SetBool(Talk, true);
                _setGreeting = true;
            }
            //
            // if (_isAccept)
            // {
            //     MainCanvas.SharedInstance.OnShowConversation("Lord Goldbloom:\n " + "How about the Goblin, have you killed it?");
            // }

            if (_isFinished)
            {
                MainCanvas.SharedInstance.OnShowConversation("Lord Goldbloom:\n " + "Well done, warrior! Here's your reward!");
            }
            
        }

        if (_range > 20 && _setGreeting)
        {
            _setGreeting = false;
        }
        /*Lord rotate to player */
        // if (!(_range < 30)) return;
        // var position = player.transform.position;
        // var position1 = transform.position;
        // lordAnimator.transform.Rotate(Quaternion.FromToRotation(position - position1, position - position1).eulerAngles);
    }
}
