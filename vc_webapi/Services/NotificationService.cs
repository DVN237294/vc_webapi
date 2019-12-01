using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc_webapi.Data;
using vc_webapi.Model;

namespace vc_webapi.Services
{
    public class NotificationService
    {
        private readonly Vc_webapiContext db;
        private const string COMMENT_USER_MENTION_ID = "@";
        private const string USER_MENTION_NOTIFICATION_TEXT = "You were mentioned in a comment by {0}, in video \"{1}\"";

        public NotificationService(Vc_webapiContext context)
        {
            db = context;
        }
        public async Task PostUserMentions(Comment comment)
        {
            //Look for users mentioned in the comments
            IEnumerable<string> userIds = comment.Message.Split(COMMENT_USER_MENTION_ID, StringSplitOptions.None)
                .Where((str, i) => i > 0 && !string.IsNullOrWhiteSpace(str))
                .Select(str => 
                {
                    int i = str.IndexOf(' ');
                    return i > -1 ? str.Substring(0, i) : str;
                });

            IQueryable<Notification> notifications = db.Users.Where(u => userIds.Contains(u.UserName)).Select(user => new Notification
            {
                Dismissed = false,
                NotificationTimeUtc = DateTime.UtcNow,
                User = user,
                RouterLink = RouterLink.Comment,
                Message = string.Format(USER_MENTION_NOTIFICATION_TEXT, comment.User.FullName, comment.Video.Name),
                RouterLinkParameters = new[]
                {
                    new RouterLinkParam()
                    {
                        Param = LinkParam.VideoId,
                        Value = comment.Video.Id.ToString()
                    },
                    new RouterLinkParam()
                    {
                        Param = LinkParam.CommentId,
                        Value = comment.Id.ToString()
                    }
                }
            });

            db.Notifications.AddRange(notifications);
            await db.SaveChangesAsync();
        }
    }

}
  
