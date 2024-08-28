using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA,ViewAViewModel>();
           // containerRegistry.RegisterForNavigation<ViewDialog, ViewDialogViewModel>();
           //注册对话框服务
           containerRegistry.RegisterDialog<ViewDialog, ViewDialogViewModel>();
        }
    }
}