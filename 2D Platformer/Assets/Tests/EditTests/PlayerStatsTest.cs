using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStatsTest
{
    [Test]
    public void CheckBaseStats()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        PlayerStats playerStats = gameObject.AddComponent<PlayerStats>();

        playerStats.Awake();
        // Act & Assert
        Assert.AreEqual(playerStats.baseStrength, playerStats.Strength.Value);
        Assert.AreEqual(playerStats.baseSpeed, playerStats.Speed.Value);
        Assert.AreEqual(playerStats.baseHealth, playerStats.Health.Value);
    }

    [Test]
    public void Increasable(){
        GameObject gameObject = new GameObject();
        PlayerStats playerStats = gameObject.AddComponent<PlayerStats>();

        playerStats.Awake();

        Assert.AreEqual(10, playerStats.Strength.Value);
        Assert.AreEqual(10, playerStats.Speed.Value);
        Assert.AreEqual(100, playerStats.Health.Value);

        playerStats.Strength.IncreaseStat(3);
        playerStats.Speed.IncreaseStat(1);
        playerStats.Health.IncreaseStat(5);

        Assert.AreEqual(13f, playerStats.Strength.Value);
        Assert.AreEqual(11f, playerStats.Speed.Value);
        Assert.AreEqual(105f, playerStats.Health.Value);

    }

}
