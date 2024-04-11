using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Mirror;
using UnityEngine.UI;
using System.Runtime.CompilerServices;


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

            yield return new WaitForSeconds(5f);

            /*GameObject levelSpawnerObject = GameObject.FindObjectOfType("LevelSpawner");
            if(levelSpawnerObject == null)
                Debug.LogError("LevelSpawner Object not found.");
            levelSpawnerObject.SetActive(true);
            LevelSpawner levelSpawner = levelSpawnerObject.GetComponent<LevelSpawner>();*/

            //Find LevelSpawner Object in Scence
            LevelSpawner levelSpawner = GameObject.FindObjectOfType<LevelSpawner>(true);
            levelSpawner.gameObject.SetActive(true);
            
            //This will allow rooms to spawn
            yield return new WaitForSeconds(5f);

            //Esnure that the correct number of rooms are spawned
            Assert.AreEqual(levelSpawner.getNumRows() * levelSpawner.getNumCols(), levelSpawner.getSpawnCounter(), "Wrong amount spawned");
        }
    }
}
