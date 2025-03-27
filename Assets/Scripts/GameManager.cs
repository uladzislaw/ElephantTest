using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool showHint;

    private TMP_Text hintText;
    
    public GameObject hintPanel;
    public GameObject teacher;
    public GameObject startButton;
    public GameObject startButtonAnim;
    public GameObject stopButton;
    public GameObject stopButtonAnim;

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

    public void OnStartButtonClick()
    {
        StartCoroutine(ActivateStopButton());
    }

    public void OnStopButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator HideHint()
    {
        hintText.enabled = true;
        animator.SetBool("IsTimeForHint", true);
        //animator.Play("ShowHint");
        yield return new WaitForSeconds(4f);
        animator.SetBool("IsTimeForHint", false);
        //animator.Play("Idle");
        hintPanel.SetActive(false);
    }

    IEnumerator ActivateStopButton()
    {
        teacher.GetComponent<TestScript>().enabled = true;
        startButtonAnim.GetComponent<Animator>().SetBool("IsTextComplete", false);
        startButton.SetActive(false);
        yield return new WaitForSeconds(20f);
        stopButton.SetActive(true);
        stopButtonAnim.GetComponent<Animator>().SetBool("IsTextComplete", true);
    }
}
