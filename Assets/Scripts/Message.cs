using UnityEngine;

[System.Serializable]
public enum messageType
{
    greeting,
    gossip,
    fear,
    relief,
    shitpost,
    grief
}

[System.Serializable]
public class Message
{
    [SerializeField] private messageType messageType;
    [SerializeField] private LocalizableText messageText;

    public messageType MessageType
    {
        get
        {
            return messageType;
        }
    }

    public LocalizableText MessageText
    {
        get
        {
            return messageText;
        }
    }
}
