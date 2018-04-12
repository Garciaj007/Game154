using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{ 
    public Dialogue dialogue;
    
    private Queue<DialogueItem> items;
    private Queue<DialogueItem> reset;

    // Use this for initialization
    void Start()
    {
        //items = XmlManager.xmlManager.conversation.ReturnList();
    }

    public void Display()
    {
        dialogue.Display(items.Peek());
        reset.Enqueue(items.Dequeue());
    }

    public void Reset()
    {
        items = reset;
    }

}
