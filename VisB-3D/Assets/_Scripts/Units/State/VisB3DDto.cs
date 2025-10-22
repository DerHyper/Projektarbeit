using System;
using System.Collections.Generic;

[Serializable]
public class VisB3DDto
{
    public List<VisB3DObjectDto> objectStates;

    public VisB3DDto()
    {
        objectStates = new List<VisB3DObjectDto>();
    }
} 