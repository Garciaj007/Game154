using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshPro name, sentences;

    public void Display(DialogueItem item)
    {
        if(item != null)
        {
            name.text = item.name;
            sentences.text = item.sentences;
        }
    }
}
