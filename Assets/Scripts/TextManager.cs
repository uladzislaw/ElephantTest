using UnityEngine;
using TMPro;
using System.Collections;

public class TextManager : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip typeSound;
    public Animator animator;
    
    private string fullText;
    private string currentText = "";
    private AudioSource audioSource;
    public TMP_Text tmpText;

    void Start()
    {
        if (tmpText == null) Debug.LogError("TMP_Text component missing!");
        
        audioSource = GetComponent<AudioSource>();
        fullText = tmpText.text;
        tmpText.text = "";
        
        // Сбрасываем анимацию в начальное состояние
        if (animator != null)
        {
            animator.SetBool("IsTextComplete", false);
        }
        
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        // Показываем текст по буквам
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tmpText.text = currentText;
            
            if (i > 0 && fullText[i-1] != ' ' && typeSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typeSound);
            }
            
            yield return new WaitForSeconds(delay);
        }

        // После завершения текста запускаем анимацию
        if (animator != null)
        {
            animator.SetBool("IsTextComplete", true);
        }
    }

    // Метод для остановки анимации (если нужно)
    public void StopAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsTextComplete", false);
        }
    }
}