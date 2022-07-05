using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class ShipTest
    {
        [Test]
        public void VerifyShipSize()
        {
            Ship s1 = new Ship(5);

            Assert.AreEqual(s1.ShipDim, 5);
        }
        [Test]
        public void VerifyShipName()
        {
            Ship s1 = new Ship(5);

            Assert.AreEqual(s1.Shipname, "Portaaviones");
        }
    }
}