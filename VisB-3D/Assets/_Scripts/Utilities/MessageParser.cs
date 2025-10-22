using Unity.VisualScripting;
using UnityEngine;

public static class MessageParser
{
    /// <summary>
    /// Converts a message string into a State object.
    /// Message should be formatted as: JSON
    /// </summary>
    /// <param name="message">Message from ProB2UI</param>
    /// <returns></returns>
    public static VisB3DDto MessageToState(string message)
    {
        VisB3DDto state = JsonUtility.FromJson<VisB3DDto>(message);
        return state;
    }
}