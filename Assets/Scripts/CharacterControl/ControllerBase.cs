using UnityEngine;

namespace AIShooterDemo
{
    public abstract class ControllerBase : MonoBehaviour
    {
        protected virtual void Start()
        {
            Init();
        }
        protected abstract void Init();
        public abstract void SetData<T>(T data);

        public static ControllerBase AddComponent(GameObject target, LevelDataBase levelData, string controllerType, string template)
        {
            ControllerBase controller;
            switch (controllerType)
            {
                case "AI":
                    controller = target.AddComponent<AIController>();
                    controller.SetData(TreeHelper.CreateBehaviourTemplate(template, levelData.Destination));
                    break;
                default:
                    Debug.LogWarning($"Unknown controller type: {controllerType}");
                    controller = target.AddComponent<NullController>();
                    break;
            }
            return controller;
        }
    }
}