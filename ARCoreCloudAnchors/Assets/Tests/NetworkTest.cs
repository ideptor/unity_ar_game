﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;



namespace Tests
{
    public class NetworkTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NetworkTestSimplePasses()
        {
            Assert.AreEqual(1, 2);

            var go = new GameObject();
// go.AddComponent<Server>();


        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NetworkTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
