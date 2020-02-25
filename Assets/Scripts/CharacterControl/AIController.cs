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
                tree = new AttackNode();
                Debug.LogWarning("Behaviour tree is not set. Use SetData method to set it right after creation.");
            }
        }

        public override void SetData<INode>(INode data)
        {
            tree = (AIShooterDemo.INode)data;
        }
    }
}