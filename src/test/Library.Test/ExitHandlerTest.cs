using NUnit.Framework;
using Telegram.Bot.Types;

namespace Test.Library
{
    public class ExitHandlerTest
    {
        ExitHandler handler;
        Message message;

        [SetUp]
        public void SetUp()
        {
            handler = new ExitHandler(null);
            message = new Message();
        }

        public void TestHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("/Salir"));
        }

        public void TestDoesNotHandle()
        {
            message.Text = "CualquierCosa123";
            string response;

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.Empty);
        }
    }
}