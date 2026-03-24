using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class WSMessageDto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WSMessageType
    {
        click
    }
    /// <summary>
    /// type can be one o
    /// </summary>
    public WSMessageType type;
    public string objectId;
    public int pageX;
    public int pageY;
    public bool altKey;
    public bool ctrlKey;
    public bool metaKey;
    public bool shiftKey;
    public string jsVars;

    public WSMessageDto(
        WSMessageType type,
        string objectId,
        int pageX = 0,
        int pageY = 0,
        bool altKey = false,
        bool ctrlKey = false,
        bool metaKey = false,
        bool shiftKey = false,
        string jsVars = "{}")
    {
        this.type = type;
        this.objectId = objectId;
        this.pageX = pageX;
        this.pageY = pageY;
        this.altKey = altKey;
        this.ctrlKey = ctrlKey;
        this.metaKey = metaKey;
        this.shiftKey = shiftKey;
        this.jsVars = jsVars;
    }
}