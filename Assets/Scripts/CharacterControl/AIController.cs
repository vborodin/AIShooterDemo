using UnityEngine;

namespace AIShooterDemo
{
    public class AIController : ControllerBase
    {
        ICharacter character;
        INode tree;

        private void Update()
        {
            NodeState state = tree.Process(Time.deltaTime, character);
            Debug.Log(state);
        }

        protected override void Init()
        {
            character = GetComponent<ICharacter>();
            if (tree != null)
            {
                tree.Init(character);
            }
            else
            {
                tree = new MoveNode(character.Position, float.PositiveInfinity, 0f);
                Debug.LogWarning("Behaviour tree is not set. Use SetData method to set it right after creation.");
            }
        }

        public override void SetData<INode>(INode data)
        {
            tree = (AIShooterDemo.INode)data;
        }
    }
}