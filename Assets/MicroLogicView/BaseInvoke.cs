using System;


namespace microwest.LogicView
{
    public class BaseInvoke
    {
        /// <summary>
        /// Invoke the view's action for updating
        /// 调用视图函数，进行UI更新
        /// </summary>
        /// <param name="action">被调用的委托</param>
        protected void InvokeView(Action action)
        {
            action?.Invoke();
        }
        /// <summary>
        /// Invoke the view's action for updating by passing 1 paramter.
        /// 调用视图函数、传一个参数，进行UI更新
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="action">被调委托</param>
        /// <param name="param">传入参数</param>
        protected void InvokeView<T>(Action<T> action, T param)
        {
            action?.Invoke(param);
        }

        /// <summary>
        /// Invoke the view's action for updating by passing 2 paramter.
        /// 调用视图函数、传两个参数，进行UI更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <param name="action"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        protected void InvokeView<T, M>(Action<T, M> action, T param1, M param2)
        {
            action?.Invoke(param1, param2);
        }
    }
}