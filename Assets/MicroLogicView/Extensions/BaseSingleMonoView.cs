using UnityEngine;

namespace microwest.LogicView
{
    [DisallowMultipleComponent]
    public abstract class BaseSingleMonoView<T> : MonoBehaviour where T : BaseSingleMonoView<T>
    {
        protected static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogError(typeof(T).Name + " More than 1!");
                        return instance;
                    }

                    if (instance == null)
                    {
                        Debug.LogError("There is no " + typeof(T).Name+" in the scene");
                    }
                }
                return instance;
            }
        }

        void Start()
        {
            BindingStart();
        }
        /// <summary>
        /// Functions that must be implemented for LogicView binding and View initialize.
        /// 视图中必须实现的函数，用以绑定逻辑和初始化。
        /// </summary>
        protected abstract void BindingStart();

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}
