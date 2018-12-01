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
    private string messageKey;

    public NotificationBlob(string messageKey)
    {
        this.messageKey = messageKey;
    }
}