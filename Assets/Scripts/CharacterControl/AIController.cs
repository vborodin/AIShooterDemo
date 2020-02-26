using UnityEngine;

namespace AIShooterDemo
{
    public class AIController : ControllerBase
    {
        ICharacter character;
        INode tree;

        private void Update()
        {
            if (character == null || character.IsDead)
            {
                Destroy(this);
            }
            NodeState state = tree.Process(Time.deltaTime, character);
            if (state != NodeState.Running)
            {
                tree.Init(character);
            }
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
                tree = new NullNode();
                Debug.LogWarning("Behaviour tree is not set. Use SetData method to set it right after creation.");
            }
        }

        public override void SetData<INode>(INode data)
        {
            tree = (AIShooterDemo.INode)data;
        }
    }
}