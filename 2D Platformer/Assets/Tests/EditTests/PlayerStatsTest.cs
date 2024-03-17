using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStatsTest
{
    [Test]
    public void CheckBaseStats()
    {
        
        // Arrange
        StatsConfig statsConfig = UnityEditor.AssetDatabase.LoadAssetAtPath<StatsConfig>("Assets/ScriptableObjects/GaryStats.asset");

        GameObject gameObject = new GameObject();
        PlayerStats playerStats = gameObject.AddComponent<PlayerStats>();

        playerStats.statsConfig = statsConfig;



        playerStats.Awake();
        // Act & Assert
        Assert.IsNotNull(statsConfig, "Failed to load GaryStats prefab from Resources.");
        Assert.AreEqual(statsConfig.baseStrength, playerStats.Strength.Value);
        Assert.AreEqual(statsConfig.baseSpeed, playerStats.Speed.Value);
        Assert.AreEqual(statsConfig.baseHealth, playerStats.Health.Value);
    }

    [Test]
    public void Increasable(){
        StatsConfig statsConfig = UnityEditor.AssetDatabase.LoadAssetAtPath<StatsConfig>("Assets/ScriptableObjects/GaryStats.asset");

        GameObject gameObject = new GameObject();
        PlayerStats playerStats = gameObject.AddComponent<PlayerStats>();

        playerStats.statsConfig = statsConfig;

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
