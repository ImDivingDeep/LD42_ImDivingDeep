using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour {

    private static Textbox s_Instance = null;

    public Dialog currentDialog;
    private int currentLine;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static Textbox instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(Textbox)) as Textbox;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("Textbox");
                s_Instance = obj.AddComponent(typeof(Textbox)) as Textbox;
            }

            return s_Instance;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            NextLine();
        }

	}

    public void StartDialog(Dialog dialog)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GameController.paused = true;
        currentDialog = dialog;
        currentLine = 0;
        gameObject.GetComponentInChildren<Text>().text = currentDialog.lines[currentLine];
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < currentDialog.lines.Length)
            gameObject.GetComponentInChildren<Text>().text = currentDialog.lines[currentLine];
        else
            EndDialog();
    }

    public void EndDialog()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GameController.paused = false;
    }


}
