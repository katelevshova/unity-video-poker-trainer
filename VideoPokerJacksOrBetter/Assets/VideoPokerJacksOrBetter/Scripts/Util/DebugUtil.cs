using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtil 
{
    private static DebugUtil _instance;

    private static string CLASS_NAME = typeof(DebugUtil).ToString();
    private const string methodSeparator1 = "->";
    private const string methodSeparator2 = ": ";
    private const string classSeparator1 = " [";
    private const string classSeparator2 = "]";
    private const bool IS_DEBUG_MODE_ENABLED = true;

    public static DebugUtil Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DebugUtil();
            }
            return _instance;
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
