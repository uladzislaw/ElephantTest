using UnityEngine;
using TMPro;
using System.Collections;

public class StudentTextManager : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip typeSound;
    [Range(0.8f, 1.2f)] public float minPitch = 0.9f;
    [Range(0.8f, 1.2f)] public float maxPitch = 1.1f;
    
    private string fullText;
    private AudioSource audioSource;
    public TMP_Text tmpText;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void StartTextDisplay(string newText = null)
    {
        if (tmpText == null)
        {
            Debug.LogError("TMP_Text component missing!");
            return;
        }

        // Останавливаем текущее воспроизведение
        StopAllCoroutines();
        
        // Обновляем текст, если передан новый
        if (!string.IsNullOrEmpty(newText))
        {
            fullText = newText;
            tmpText.text = "";
        }
        else
        {
            fullText = tmpText.text;
            tmpText.text = "";
        }

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            string currentText = fullText.Substring(0, i);
            tmpText.text = currentText;
            
            if (i > 0 && fullText[i-1] != ' ' && typeSound != null)
            {
                // Каждый раз новые настройки звука
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.volume = Random.Range(0.9f, 1.0f);
                audioSource.PlayOneShot(typeSound);
            }
            
            yield return new WaitForSeconds(delay);
        }
    }

    // Для инициализации через Start
    void Start()
    {
        if (tmpText != null)
        {
            StartTextDisplay();
        }
    }
}