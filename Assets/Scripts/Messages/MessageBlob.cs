public enum messageStyle{
	normal,
	joined,
	left,
	user
}

public class MessageBlob {
	public int senderID {get; private set;}
	public string messageKey {get; private set;}
	public messageStyle style {get; private set;}

    public MessageBlob(int senderID, string messageKey, messageStyle style)
    {
        this.senderID = senderID;
        this.messageKey = messageKey;
		this.style = style;
    }
}