using UnityEngine;

[System.Serializable]
public enum messageType
{
    none,
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
    [SerializeField] private string messageTextKey;

    public messageType MessageType
    {
        get
        {
            return messageType;
        }
    }

    public string MessageTextKey
    {
        get
        {
            return messageTextKey;
        }
    }
}
