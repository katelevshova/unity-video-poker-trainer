using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Singleton class for printing debug info into deployed application on the device.
 * For testing on the device.
 * Also prints the same info into Unity Console.
 * @author Kateryna Levshova
 * */
//path "GameHandler/UI_Container/UICanvas/DebugCanvas/DebugConsole"
public class DebugConsole : MonoBehaviour
{
    public Text debugText;
    public GameObject debugConsoleScrollView;
    public GameObject btnDebug;
    public static DebugConsole Instance;

    private static string CLASS_NAME = typeof(DebugConsole).ToString();
    private const string methodSeparator1 = "->";
    private const string methodSeparator2 = ": ";
    private const string classSeparator1 = " [";
    private const string classSeparator2 = "]";
    private const bool IS_DEBUG_MODE_ENABLED = true; //TODO: change it to false before release


    void Awake()
    {
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one DebugConsole object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        if (debugText == null)
        {
            throw new Exception("Initialize debug text for DebugConsole, drag DebugText from DebugCanvas prefab");
        }
        if (debugConsoleScrollView == null)
        {
            throw new Exception("Initialize DebugConsoleScrollView for DebugConsole, drag DebugConsoleScrollView from DebugCanvas prefab");
        }

        if (btnDebug == null)
        {
            throw new Exception("Initialize DebugButton for DebugConsole, drag DebugButton from DebugCanvas prefab");
        }

        btnDebug.SetActive(IS_DEBUG_MODE_ENABLED);

    }

    /**
     * Sets visibility of DebugConsoleScrollView
     */
    public void SetConsoleVisivility()
    {
        debugConsoleScrollView.SetActive(!debugConsoleScrollView.activeSelf);
    }

    /**
	 * Sends a debug log message if <code>IS_DEBUG_MODE_ENABLED=true</code> to DebugConsole of the app 
     * and to Unity Console with detailed info.
	 *
     * @param className  Used to identify the source of a log message.
	 * @param methodName Activity where the log call occurs.
	 * @param msg        The message you would like logged.
	 */
    public void PrintD(string className, string methodName, string msg)
    {
        if (IS_DEBUG_MODE_ENABLED)
        {
            String yourCustomDetailedMsg = GetMessageFormat(className, methodName) + msg.ToString();
            Print(yourCustomDetailedMsg);     // prints to DebugConsole in app
            Debug.Log(yourCustomDetailedMsg); // prints to Unity Console
        }
    }

    /**
	 * Sends a debug log message if <code>IS_DEBUG_MODE_ENABLED=true</code> to DebugConsole of the app 
     * and to Unity Console with info about the source of a log message.
	 *
     * @param className  Used to identify the source of a log message.
	 * @param methodName Activity where the log call occurs.
	 */
    public void PrintD(string className, string methodName)
    {
        if (IS_DEBUG_MODE_ENABLED)
        {
            String pathMsg = GetMessageFormat(className, methodName);
            Print(pathMsg);     // prints to DebugConsole in app
            Debug.Log(pathMsg); // prints to Unity Console
        }
    }

    /**
	 * Created message string. Example:  [DebugConsole]->PrintD:
	 *
	 * @param className
	 * @param methodName
	 * @return  message string
	 */
    public string GetMessageFormat(string className, string methodName)
    {
        return classSeparator1 + className + classSeparator2 + methodSeparator1 + methodName +
                methodSeparator2;
    }

    /**
     * Adds a message from a new line in DebugConsole in the application (leaves Console in Unity empty)
     * 
     * @msg The message you would like logged
     */
    private void Print(String msg)
    {
        debugText.text += msg + "\n";
    }

}
