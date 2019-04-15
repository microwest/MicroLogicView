using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace microwest.LogicView
{
    /// <summary>
    /// Just perform the ui related functions.
    /// 只做UI相关的操作
    /// </summary>
    public abstract class BaseMonoView : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            BindingStart();
        }
        protected virtual void OnDisable()
        {
            BindingDispose();
        }

        /// <summary>
        /// Functions that must be implemented for LogicView binding and View initialize.
        /// 视图中必须实现的函数，用以绑定逻辑和初始化。
        /// </summary>
        protected abstract void BindingStart();
        /// <summary>
        /// Functions that must be implemented for LogicView binding and View Dispose.
        /// 视图中必须实现的函数，用以解除绑定。
        /// </summary>
        protected abstract void BindingDispose();
    }
}
