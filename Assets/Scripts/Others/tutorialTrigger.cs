using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    string sceneName;
    Scene m_Scene;

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if(sceneName == "Main")
        {
            if(GameManager.instance.tutorial == 0)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                //Mato el tutorial para que no aparezca más
                GameManager.instance.tutorial = 1;
            }
        }
    }
}
