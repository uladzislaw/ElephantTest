using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TestScript : MonoBehaviour
{
    [Header("Timing Settings")]
    public float letterDelay = 0.1f;         // Задержка между буквами
    public float sentencePause = 1f;        // Пауза после полного набора предложения
    public float betweenSentencesDelay = 2f; // Задержка между предложениями (после исчезновения)
    
    [Header("References")]
    public AudioClip typeSound;
    public Animator animator;
    public TMP_Text tmpText;
    public GameObject bubbleBox;
    public GameManager gameManager;
    
    private List<string> sentences = new List<string>();
    private AudioSource audioSource;

    void Start()
    {
        bubbleBox.SetActive(true);
        if (tmpText == null) Debug.LogError("TMP_Text component missing!");
        
        audioSource = GetComponent<AudioSource>();
        InitializeSentences();
        
        if (animator != null)
        {
            animator.SetBool("IsTextComplete", false);
        }
        
        StartCoroutine(ShowSentences());
    }

    void InitializeSentences()
    {
        sentences.Add("Hello kids");
        sentences.Add("Let's start the exam");
        sentences.Add("First question is");
        sentences.Add("2+2*2=?");
        
        tmpText.text = "";
    }

    IEnumerator ShowSentences()
    {
        for (int i = 0; i < sentences.Count; i++)
        {
            bool isLastMessage = (i == sentences.Count - 1);
            
            // 1. Показываем предложение
            yield return StartCoroutine(ShowText(sentences[i]));
            
            // 2. Пауза после полного набора (предложение видно)
            yield return new WaitForSeconds(sentencePause);
            
            // 3. Очищаем только если это НЕ последнее сообщение
            if (!isLastMessage)
            {
                tmpText.text = "";
                yield return new WaitForSeconds(betweenSentencesDelay);
            }
        }
        
        // Действия после завершения
        if (gameManager != null) gameManager.showHint = true;
        if (animator != null) animator.SetBool("IsTextComplete", true);
    }

    IEnumerator ShowText(string text)
    {
        tmpText.text = ""; // Очищаем перед новым предложением
        
        for (int i = 0; i <= text.Length; i++)
        {
            string currentText = text.Substring(0, i);
            tmpText.text = currentText;
            
            if (i > 0 && text[i-1] != ' ' && typeSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typeSound);
            }
            
            yield return new WaitForSeconds(letterDelay);
        }
    }
}