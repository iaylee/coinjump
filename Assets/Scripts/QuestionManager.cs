using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuestion(Question q) {
        Debug.Log("Starting convo with" + q.name);

        sentences.Clear();

        foreach (string sentence in q.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndQuestion();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndQuestion()
    {
        Debug.Log("End of conversation");
    }

}
