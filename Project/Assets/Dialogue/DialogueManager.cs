using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dlgText;

    public float speedOfTyping = 0.1f;
    public float delay = 2f;

    public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    IEnumerator TypeSentence (string sentence)
    {
        dlgText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dlgText.text += letter;
            yield return new WaitForSeconds(speedOfTyping);
        }
        yield return new WaitForSeconds(delay);
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
