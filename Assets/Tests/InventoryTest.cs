using System.Collections;
using System.Collections.Generic;
using LD46.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void InventoryTest_BasicCreation()
        {
            var go = new GameObject();
            var inv = go.AddComponent<Inventory>();
            Assert.False(inv.Has<Battery>());
        }

        [Test]
        public void InventoryTest_HasObjects()
        {
            var go = new GameObject();
            var inv = go.AddComponent<Inventory>();
            Assert.False(inv.Full);
            Assert.AreEqual(0, inv.Count);

            Assert.True(inv.Add(new Battery()));
            Assert.False(inv.Full);
            Assert.AreEqual(1, inv.Count);
            
            Assert.True(inv.Add(new Battery()));
            Assert.True(inv.Add(new Battery()));
            Assert.True(inv.Add(new Battery()));
            Assert.True(inv.Add(new Battery()));
            Assert.True(inv.Full);
            Assert.AreEqual(5, inv.Count);
            
            Assert.False(inv.Add(new Battery()));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator InventoryTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
