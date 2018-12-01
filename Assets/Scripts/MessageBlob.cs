public class MessageBlob {
	private int senderID;
	private LocalizableText message;

    public MessageBlob(int senderID, LocalizableText message)
    {
        this.senderID = senderID;
        this.message = message;
    }
}