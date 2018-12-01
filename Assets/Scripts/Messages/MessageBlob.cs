public enum messageStyle{
	normal,
	joined,
	left
}

public class MessageBlob {
	public int senderID {get; private set;}
	public LocalizableText message {get; private set;}
	public messageStyle style {get; private set;}

    public MessageBlob(int senderID, LocalizableText message, messageStyle style)
    {
        this.senderID = senderID;
        this.message = message;
		this.style = style;
    }
}