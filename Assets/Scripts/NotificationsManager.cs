using System.Collections.Generic;

public class NotificationsManager : Singleton<NotificationsManager>
{
    private List<NotificationBlob> notificationHistory = new List<NotificationBlob>();

    public void AddNotification(NotificationBlob blob){
        notificationHistory.Add(blob);
        GameEvents.Notifications.NewNotification.SafeInvoke(blob);
    }
}

public class NotificationBlob
{
    private int sheepID;
    private string messageKey;

    public NotificationBlob(int sheepID, string messageKey)
    {
        this.sheepID = sheepID;
        this.messageKey = messageKey;
    }

    public int SheepID
    {
        get
        {
            return sheepID;
        }
    }

    public string MessageKey
    {
        get
        {
            return messageKey;
        }
    }
}