namespace Knv.BHS.IO
{
    using NUnit.Framework;
    using System.Linq;
    using System.Text;

    [TestFixture]
    internal class Flash_UnitTest
    {
        Connection Conn;

        [SetUp]
        public void TestSetup()
        { 
            Conn = new Connection();
            Conn.Open("COM3");
        }


        [Test]
        public void FlashRead() 
        {
            Conn.FlashErase(0);
            byte[] read = Conn.FlashRead(0, 12);
            byte[] except = new byte[] {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(Enumerable.SequenceEqual(read, except));
            Conn.FlashWrite(0, Encoding.ASCII.GetBytes("Hello, World"));
            read = Conn.FlashRead(0, 12);

        }

        [Test]
        public void DeviceName()
        {
            Assert.AreEqual("BHS", Conn.WhoIs());
        }

        [TearDown]
        public void TestTearDown() 
        {
            if(Conn != null && Conn.IsOpen)
            {
                Conn.Close();
            }
            
        }


    }
}
