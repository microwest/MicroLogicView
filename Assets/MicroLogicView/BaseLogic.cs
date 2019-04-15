namespace microwest.LogicView
{
    /// <summary>
    /// Logic base class which just takes care of the logic.
    /// 只需要考虑逻辑相关的操作
    /// </summary>
    /// <typeparam name="T">Derived Logic class</typeparam>
    /// <typeparam name="V">Derived View class</typeparam>
    public abstract class BaseLogic<T> : BaseInvoke where T : class, new() 
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
}