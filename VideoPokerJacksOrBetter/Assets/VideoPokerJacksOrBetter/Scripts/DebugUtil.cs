using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtil : MonoBehaviour
{
    public static DebugUtil Instance;

    private static string CLASS_NAME = typeof(DebugUtil).ToString();
    private const string methodSeparator1 = "->";
    private const string methodSeparator2 = ": ";
    private const string classSeparator1 = " [";
    private const string classSeparator2 = "]";
    private const bool IS_DEBUG_MODE_ENABLED = true;

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
        //This is useful so that we cannot have more than one DebugUtil object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    /**
	 * Sends a debug log message if <code>IS_DEBUG_MODE_ENABLED=true</code> to Unity Console with detailed info.
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
            Debug.Log(yourCustomDetailedMsg); // prints to Unity Console
        }
    }

    /**
	 * Sends a debug log message if <code>IS_DEBUG_MODE_ENABLED=true</code> to 
     * Unity Console with info about the source of a log message.
	 *
     * @param className  Used to identify the source of a log message.
	 * @param methodName Activity where the log call occurs.
	 */
    public void PrintD(string className, string methodName)
    {
        if (IS_DEBUG_MODE_ENABLED)
        {
            String pathMsg = GetMessageFormat(className, methodName);
            Debug.Log(pathMsg); // prints to Unity Console
        }
    }

    /**
	 * Created message string. Example:  [DebugUtil]->PrintD:
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

}
