using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Mathematics;
using UnityEngine;

public class OnClickListener : MonoBehaviour
{
    /// <summary>
    /// This method is called by the <c>InputManager</c> when a <c>GameObject<c> with a <c>OnClickListener</c> is clicked on.
    /// </summary>
    public void Click()
    {
        Debug.Log("Click on " + gameObject.name + " registered");
        WSMessageDto messageDto = new WSMessageDto(WSMessageDto.WSMessageType.click, gameObject.name);
        string messageJson = JsonConvert.SerializeObject(messageDto, Formatting.Indented );
        JavaScriptAPI.SendWSMessage(messageJson);
        //JavaScriptAPI.DebugAlert("Click on " + gameObject.name + " registered");
    }
}
