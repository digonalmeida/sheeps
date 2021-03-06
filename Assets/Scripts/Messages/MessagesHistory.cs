using System.Collections.Generic;
using UnityEngine;

public class MessagesHistory : Singleton<MessagesHistory>{

    private List<MessageBlob> messages = new List<MessageBlob>();

    public void AddMessage(MessageBlob blob)
    {
        messages.Add(blob);
        GameEvents.Messages.NewMessage.SafeInvoke(blob);
    }

}