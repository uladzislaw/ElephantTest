using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterBehavior : MonoBehaviour
{
    public GameObject textBubble;
    // Start is called before the first frame update
    void Start()
    {
        textBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(GetAnswer());
    }

    IEnumerator GetAnswer()
    {
        textBubble.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        textBubble.SetActive(false);
    }
}
