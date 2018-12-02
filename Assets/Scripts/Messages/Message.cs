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
    grief,
    blame,
    agree,
    disagree
}

[System.Serializable]
public class Message
{
    [SerializeField] private messageType messageType;
    [SerializeField] private string messageTextKey;
    private bool wasUsed = false;

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

    public bool WasUsed
    {
        get
        {
            return wasUsed;
        }

        set
        {
            wasUsed = value;
        }
    }
}
