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

    private void Start()
    {
        lordAnimator.SetBool(Talk, false);
        // text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _range = Vector3.Distance(transform.position, player.transform.position);
        lordAnimator.SetBool(Grating, !(_range > 30));

        if (_range < 10)
        {
            DrawTextUtils.SharedInstance.SetContent("Lord Goldbloom: " + "Greetings human!");
            lordAnimator.SetBool(Talk, true);
            // text.text = "Gratings, human!";
        }
        /*Lord rotate to player */
        // if (!(_range < 30)) return;
        // var position = player.transform.position;
        // var position1 = transform.position;
        // lordAnimator.transform.Rotate(Quaternion.FromToRotation(position - position1, position - position1).eulerAngles);
    }
}
