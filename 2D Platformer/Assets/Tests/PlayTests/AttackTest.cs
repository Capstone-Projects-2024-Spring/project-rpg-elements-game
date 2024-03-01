using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace Tests
{
    public class AttackTest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CheckAttackNames()
        {
            //This will look for the scence
            yield return SceneManager.LoadSceneAsync("Level1");

            //Find Gary in the scene and get his attacks
            GameObject gary = GameObject.Find("Gary");
            PlayerAttack[] attackList = gary.GetComponents<PlayerAttack>();
            //For each attack Gary has, make sure it's given a name that isn't the default name.
            foreach (PlayerAttack attack in attackList){
                Assert.AreNotEqual(attack.attackName, null, "Attackname isn't set!");
                Assert.AreNotEqual(attack.attackName, "strike", "Attackname is still the default name!");
            }

        }
    }
}
