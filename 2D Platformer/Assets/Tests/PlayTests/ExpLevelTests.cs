using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ExpLevelTests
{
[UnityTest]
    public IEnumerator Singleton_Instance()
    {
        // Arrange
        GameObject gameObject1 = new GameObject();
        ExperienceManager experienceManager1 = gameObject1.AddComponent<ExperienceManager>();

        GameObject gameObject2 = new GameObject();
        ExperienceManager experienceManager2 = gameObject2.AddComponent<ExperienceManager>();

        yield return null;

        // Assert
        Assert.AreEqual(1, GameObject.FindObjectsOfType<ExperienceManager>().Length);

        // Yield to wait for the next frame or certain conditions
    }
}
