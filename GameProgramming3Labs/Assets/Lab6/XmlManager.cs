using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[ExecuteInEditMode]
public class XmlManager : MonoBehaviour {

    /*
     <ROOT>
     <CONVERSATIONS>
        <CONVERSATION id="1">
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Cheryl" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
        </CONVERSATION>
        <CONVERSATION id="2">
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Cheryl" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
            <DIALOGUE name="Thomas" Sentences="lorem ipsum whatever"/>
        </CONVERSATION>
        
    </CONVERSATIONS> 
    </ROOT>


    */

    public static XmlManager xmlManager;
    public Action LoadXMLComplete;
    public Dictionary<int, Conversation> allConversations = new Dictionary<int, Conversation>();

    private readonly string xmlPath = Environment.CurrentDirectory + "/SaveData/SpriteGenerator.xml";

    private void Awake()
    {
        xmlManager = this;
    }

    public Conversation conversation;

    public void SaveConversation()
    {
        if(!Directory.Exists(xmlPath))
        {
            DirectoryInfo newDir = Directory.CreateDirectory(xmlPath);
        }

        //FileStream stream = new FileStream(xmlPath, FileMode.Create);
        //XmlSerializer serializer = new XmlSerializer(typeof(XmlDocument);
        XmlDocument xmlDocument = new XmlDocument();

        //Creating Nodes
        XmlNode rootNode = xmlDocument.CreateNode(XmlNodeType.Element, "ROOT", null);
        XmlNode conversationsNode = xmlDocument.CreateNode(XmlNodeType.Element, "CONVERSATIONS", null);
        XmlNode conversationNode = xmlDocument.CreateNode(XmlNodeType.Element, "CONVERSATION", null);
        XmlNode dialogueNode = xmlDocument.CreateNode(XmlNodeType.Element, "DIALOGUE", null);

        //Creating Attributes
        XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
        idAttribute.InnerText = "1";
        XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");
        nameAttribute.InnerText = "Joseph";
        XmlAttribute sentencesAttribute = xmlDocument.CreateAttribute("sentences");
        sentencesAttribute.InnerText = "jhsdjhflkjhsdkjfhkjhdslkhkj. jshjhasjdhkhaskdjh";

        //Appending Attributes
        dialogueNode.Attributes.Append(nameAttribute);
        dialogueNode.Attributes.Append(sentencesAttribute);
        conversationNode.Attributes.Append(idAttribute);

        //Appending Nodes
        conversationNode.AppendChild(dialogueNode);
        conversationsNode.AppendChild(conversationNode);
        rootNode.AppendChild(conversationsNode);
        xmlDocument.AppendChild(rootNode);

        xmlDocument.Save(xmlPath);

        //serializer.Serialize(stream, xmlDocument);
        //stream.Close();

        LoadConversation();
    }

    public void LoadConversation()
    {
        XmlDocument xmlDocument = new XmlDocument();

        if (File.Exists(xmlPath))
        {
            xmlDocument.Load(xmlPath);
            XmlNode rootNode = xmlDocument.SelectSingleNode("ROOT");

            try
            {
                XmlNode converstationsNode = rootNode.SelectSingleNode("CONVERSATIONS");

                #region Looping through all conversations
                foreach(XmlNode conversationNode in converstationsNode.ChildNodes)
                {
                    Conversation con = new Conversation();
                    int id = 0;

                    if (conversationNode.Name.ToUpper().Equals("CONVERSATION"))
                    {
                        con = new Conversation();
                        #region Getting conversations id
                        if (conversationNode.Attributes["id"] != null)
                        {
                            id = Convert.ToInt32(conversationNode.Attributes["id"]);
                        }
                        #endregion

                        #region Looping through all Dialougues
                        foreach(XmlNode dialogue in conversationNode.ChildNodes)
                        {
                            DialogueItem item = new DialogueItem();

                            #region Getting all Dialogues Attributes

                            if (dialogue.Attributes["name"] != null)
                            {
                                item.name = dialogue.Attributes["name"].ToString();
                            }

                            if (dialogue.Attributes["sentences"] != null)
                            {
                                item.sentences = dialogue.Attributes["sentences"].ToString();
                            }

                            #endregion
                            con.l_Conversation.Add(item);
                        }
                        #endregion
                    }

                    allConversations.Add(id, con);
                }
                #endregion

                if(LoadXMLComplete != null)
                {
                    LoadXMLComplete();
                }
            } 
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                SaveConversation();
            }
        } else
        {
            SaveConversation();
        }
    }
}

[System.Serializable]
public class DialogueItem
{
    public string name;
    [TextArea(3, 10)]
    public string sentences;
}

[System.Serializable]
public class Conversation
{
    public List<DialogueItem> l_Conversation = new List<DialogueItem>();
    private Queue<DialogueItem> q_Conversation = new Queue<DialogueItem>();

    public Queue<DialogueItem> ReturnList()
    {
        foreach (DialogueItem item in l_Conversation)
        {
            q_Conversation.Enqueue(item);
        }

        return q_Conversation;
    }
}

[CustomEditor(typeof(XmlManager))]
public class XmlManagerSaver : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(GUILayout.Button("Save Conversation"))
        {
            XmlManager.xmlManager.SaveConversation();
        }
        if(GUILayout.Button("Load Conversation"))
        {
            XmlManager.xmlManager.LoadConversation();
        }
    }
}


