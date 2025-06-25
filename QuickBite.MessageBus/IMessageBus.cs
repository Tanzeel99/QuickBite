using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBite.MessageBus
{
    public interface IMessageBus
    {
        //Passing message of Object type and second parameter queueName/TopicName(either both cant have same name)
        Task PublishMessage(object message, string topic_queue_Name);
    }
}
