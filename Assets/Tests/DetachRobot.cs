using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DetachRobot
{
    // A Test behaves as an ordinary method
    [Test]
    public void RotateRobotSimplePasses()
    {
        // tests that the counter is correctly incremented and decremented on event calls
        StatusManager statusManager = new()
        {
            attachMessage = new GameObject(),
            detachMessage = new GameObject()
        };
        Assert.That(statusManager.GetDetached() == 0);
        statusManager.OnDetach();
        Assert.That(statusManager.GetDetached() == 1);
        statusManager.OnAttach();
        Assert.That(statusManager.GetDetached() == 0);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator RotateRobotWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
