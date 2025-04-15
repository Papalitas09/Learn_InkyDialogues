using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManag : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Animation Settings")]
    [SerializeField] private float animationSpeed = 0.05f;
    private bool isAnimatingText;
    private Coroutine animationTextCoroutine;

    private Story currentStory;
    private string currentDialogue;
    private bool isActive;
    private static DialogueManag instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Bahaya, ada dua instance of dialogue manager cuy");
        }
        instance = this;
    }

    public static DialogueManag GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        Debug.Log("Current Dialogue : " + currentDialogue);
        Debug.Log("<color=purple>isAnimating : </color>" + isAnimatingText);
        DialogueStatus();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAnimatingText)
            {
                CompleteTextAnimation();
            }
            else
            {
                ContinueStory();
            }
        }
    }

    public void DisplayDialogue(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isActive = true;
        ContinueStory();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            currentDialogue = currentStory.Continue();

            if(animationTextCoroutine != null)
            {
                StopCoroutine(animationTextCoroutine);
            }

            animationTextCoroutine = StartCoroutine(TextAnimation(currentDialogue));
        }
        else
        {
            isActive = false;
            dialogueText.text = "";
        }
    }
    
    private IEnumerator TextAnimation(string line)
    {
        isAnimatingText = true;
        dialogueText.text = "";

        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(animationSpeed);
        }
        isAnimatingText = false;
    }

    private void CompleteTextAnimation()
    {
        if(animationTextCoroutine != null)
        {
            StopCoroutine(animationTextCoroutine);
        }

        dialogueText.text = currentDialogue;
        isAnimatingText = false;
    }
    public void DialogueStatus()
    {
        if (isActive) 
        {
            FindAnyObjectByType<Movements>().enabled = false;
            FindAnyObjectByType<Headbob>().enabled = false;
            dialoguePanel.SetActive(true);
        }
        else
        {
            FindAnyObjectByType<Movements>().enabled = true;
            FindAnyObjectByType<Headbob>().enabled = true;
            dialoguePanel.SetActive(false);
        }
    }
}
