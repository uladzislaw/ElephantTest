using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool showHint;

    private TMP_Text hintText;
    
    public GameObject hintPanel;
    public GameObject teacher;
    public GameObject startButton;

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
            StartCoroutine(HideHint());
        }
        else
        {
            hintText.enabled = false;
        }
    }

    public void OnButtonClick()
    {
        teacher.GetComponent<TestScript>().enabled = true;
        startButton.GetComponent<Animator>().SetBool("IsTextComplete", false);
    }

    IEnumerator HideHint()
    {
        hintText.enabled = true;
        animator.Play("ShowHint");
        yield return new WaitForSeconds(4f);
        hintPanel.SetActive(false);
    }

    /*public void ShowHint()
    {
        showHint = true;
    }*/
}
