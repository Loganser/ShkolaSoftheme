using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus.Messaging;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = "Endpoint=sb://fedorov.servicebus.windows.net/;SharedAccessKeyName=ProducerAccessKey;SharedAccessKey=u7ifx65ueolCDx/BXp25a2+KMYuwonGPsxn7W0KaxTw=";
            string queueName = "fedorovqueue";

            var producer = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage("This is a test message!");
            producer.Send(message);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}