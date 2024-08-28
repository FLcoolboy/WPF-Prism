using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleA.ViewModels
{
    //INavigationAware传输接口  IConfirmNavigationRequest继承了该接口
    public class ViewAViewModel : BindableBase,IConfirmNavigationRequest
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
          
        }
        /// <summary>
        /// 接收参数
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("MsgA")) 
            {
                //Message = navigationContext.Parameters["Msga"].ToString();
                Message = navigationContext.Parameters.GetValue<string>("MsgA");
               
            }

        }
        /// <summary>
        /// 是否重用实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 拦截
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
          
        }
        /// <summary>
        /// 确认导航请求(离开)
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result=true;
           if( MessageBox.Show("确认切换吗","温馨提示",MessageBoxButton.YesNo)==MessageBoxResult.No)
            {
                result = false;
            }
            continuationCallback(result);
        }
    }
}
