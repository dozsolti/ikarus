using System;
using System.Collections.Generic;
public class InputDTO
{
    public String type;
    public String eventType;

    public JSONObject data;

    public InputDTO(string type, string eventType, JSONObject data)
    {
        this.type = type;
        this.eventType = eventType;
        this.data = data;
    }
}