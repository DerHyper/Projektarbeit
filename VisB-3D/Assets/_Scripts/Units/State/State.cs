using System.Collections.Generic;
using System.Data;

public class State
{
    public enum Type
    {
        Material,
        Position,
        Visibility
    }
    public Dictionary<string, ObjectState> elements;

    public State()
    {
        elements = new Dictionary<string, ObjectState>();
    }
} 