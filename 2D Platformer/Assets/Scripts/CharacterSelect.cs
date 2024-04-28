using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WildLife.Mirror.CharacterSelection
{
    public class CharacterSelect : NetworkBehaviour
    {
        [SerializeField] private GameObject characterSelectDisplay = default;
        [SerializeField] private Transform characterPreviewParent = default;
        [SerializeField] private TMP_Text characterNameText = default;
        [SerializeField] private TMP_InputField playerNameInput = default;
        [SerializeField] private Character[] characters = default;

        private int currentCharacterIndex = 0;
        private List<GameObject> characterInstances = new List<GameObject>();

        public override void OnStartClient()
        {
            foreach (var character in characters)
            {
                GameObject characterInstance = Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);
                characterInstance.SetActive(false);
                characterInstances.Add(characterInstance);
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;

            characterSelectDisplay.SetActive(true);
        }

        public void Select()
        {
            CmdSelect(currentCharacterIndex, playerNameInput.text);
            characterSelectDisplay.SetActive(false);
        }

        [Command(requiresAuthority = false)]
        public void CmdSelect(int characterIndex, string playerName, NetworkConnectionToClient sender = null)
        {
            GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);

            CharacterName characterNameScript = characterInstance.GetComponent<CharacterName>();
            characterNameScript.SetPlayerName(playerName);
            NetworkServer.Spawn(characterInstance, sender);
        }

        public void Right()
        {
            characterInstances[currentCharacterIndex].SetActive(false);
            currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;
            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }

        public void Left()
        {
            characterInstances[currentCharacterIndex].SetActive(false);
            currentCharacterIndex--;
            if (currentCharacterIndex < 0)
            {
                currentCharacterIndex += characterInstances.Count;
            }
            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }
    }
}