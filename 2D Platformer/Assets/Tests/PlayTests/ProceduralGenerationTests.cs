using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class ProceduralGenerationTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator checkMap()
    {
        // Your procedural generation logic here
        yield return null; // Placeholder for any procedural generation logic

        Assert.IsTrue(true); // Test passes if reached
    }
}
