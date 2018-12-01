using System.Collections.Generic;

public class MessageHistory{

    private List<MessageBlob> messages;

    public void AddMessage(MessageBlob blob)
    {
        messages.Add(blob);
        GameEvents.Messages.NewMessage.SafeInvoke();
    }

}