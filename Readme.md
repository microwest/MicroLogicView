MicroLogicView：
     类似于MVC或MVVM模式，目的是把Logic和Gui分开，中间多一个View视图层。

Feature：
1. 极简设计--无反射，无事件；
2. 最小框架--Logic层+View层+任何一种GUI；
3. 松耦合----GUI与Logic无须知道对方的存在，View负责绑定二者；
4. 高效调用--只有delegate，确定的函数调用实现绑定；
5. 硬核编码--View通过硬编码实现绑定，极少Editor操作，适合程序员使用。

对比参考：
1. Asset Store “MVVM插件”；
2. Asset Store “Data Binding插件”。