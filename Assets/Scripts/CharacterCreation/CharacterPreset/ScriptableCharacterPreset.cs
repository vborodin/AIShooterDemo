using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class ScriptableCharacterPreset : ScriptableObject, ICharacterPreset
    {
        [SerializeField] string characterData = "MockupCharacter";
        public string CharacterData => characterData;

        [SerializeField] string behaviourType = "AI";
        public string BehaviourType => behaviourType;

        [SerializeField] string behaviourTemplate = "Zombie";
        public string BehaviourTemplate => behaviourTemplate;
    }
}