using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool showHint;

    private TMP_Text hintText;
    
    public GameObject hintPanel;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        hintText = hintPanel.GetComponent<TMP_Text>();
        animator = hintPanel.GetComponent<Animator>();
        showHint = false;
        hintText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showHint == true)
        {
            hintText.enabled = true;
            animator.Play("ShowHint");
        }
        else
        {
            hintText.enabled = false;
        }
    }

    /*public void ShowHint()
    {
        showHint = true;
    }*/
}
