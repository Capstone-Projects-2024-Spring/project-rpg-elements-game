using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Mirror;


namespace Tests
{
    public class NewTestScript
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            //This will look for the scence
            yield return SceneManager.LoadSceneAsync("LevelGenerator");

            //Find LevelSpawner Object in Scence
            LevelSpawner levelSpawner = GameObject.FindObjectOfType<LevelSpawner>();

            //This will allow rooms to spawn
            yield return new WaitForSeconds(5f);

            //Esnure that the correct number of rooms are spawned
            Assert.AreEqual(levelSpawner.getNumRows() * levelSpawner.getNumCols(), levelSpawner.getSpawnCounter(), "Wrong amount spawned");
        }
    }
}
