using UnityEngine;

namespace AIShooterDemo
{
    public class AITest : MonoBehaviour
    {
        ICharacter character;
        INode tree;
        private void Start()
        {
            character = GetComponent<ICharacter>();
            tree = CreateTree(character.Destination);
            tree.Init(character);
        }

        private void Update()
        {
            NodeState state = tree.Process(Time.deltaTime, character);
            Debug.Log(state);
        }

        private INode CreateTree(Vector3 destination)
        {
#warning const values
            INode root = new RepeaterNode(new MoveNode(destination, 1.5f, 2), 10);
            return root;
        }
    }
}