using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckboxButtons : MonoBehaviour
{
    public GameObject smileyStudentFace;
    public GameObject sadStudentFace;
    private AudioSource audio;
    public AudioClip smileyAudioClip;
    public AudioClip sadAudioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCorrectButtonClick()
    {
        StartCoroutine(ShowSmileyStudentFace());
    }
    
    public void OnIncorrectButtonClick()
    {
        StartCoroutine(ShowSadStudentFace());
    }

    IEnumerator ShowSmileyStudentFace()
    {
        smileyStudentFace.SetActive(true);
        audio.PlayOneShot(smileyAudioClip);
        yield return new WaitForSeconds(smileyAudioClip.length);
        smileyStudentFace.SetActive(false);
    }
    
    IEnumerator ShowSadStudentFace()
    {
        sadStudentFace.SetActive(true);
        audio.PlayOneShot(sadAudioClip);
        yield return new WaitForSeconds(sadAudioClip.length);
        sadStudentFace.SetActive(false);
    }
}
