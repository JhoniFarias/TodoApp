using FluentValidation.Results;

namespace Todo.Domain.Notifications
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() => _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;


        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }

        public void Clear()
        {
            _notifications.Clear();
        }

        public bool IsValid => _notifications.Any() == false;
    
    }
}