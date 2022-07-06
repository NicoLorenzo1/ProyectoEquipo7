using NUnit.Framework;
using Telegram.Bot.Types;

namespace Test.Library
{
    public class AttackHandlerTest
    {
        AttackHandler handler;
        Message message;

        [SetUp]
        public void SetUp()
        {
            handler = new AttackHandler(null);
            message = new Message();
        }

        public void TestHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("Atacar"));
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