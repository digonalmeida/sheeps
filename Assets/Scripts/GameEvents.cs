using System;

public static class GameEvents{
    public static class Messages{
        public static Action NewMessage;
    }

    public static class Localization{
        public static Action LanguageChanged;
    }

    public static class Notifications{
        public static Action<NotificationBlob> TriggerNotification;
    }
}