using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewDialogViewModel : IDialogAware
    {
        public string Title { get; set; } = "这是对话框标题";
        public string Parameter1 { get; set; }

        public DelegateCommand ConfirmCmm {  get; set; }
        public DelegateCommand CancleCmm { get; set; }

        public event Action<IDialogResult> RequestClose;
        /// <summary>
        /// 是否能够关闭对话框
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanCloseDialog()
        {
            return true;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogClosed()
        {
            DialogParameters paras= new DialogParameters();
            paras.Add("result", "张三");
            RequestClose?.Invoke(new DialogResult(ButtonResult.Yes,paras));
        }
        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Title"))
            {
                Title = parameters.GetValue<string>("Title");
            }
            if (parameters.ContainsKey("Para1"))
            {
                Parameter1 = parameters.GetValue<string>("Para1");
            }
            if (parameters.ContainsKey("Para2"))
            {
                parameters.GetValue<string>("Para2");
            }
        }
        public ViewDialogViewModel()
        {
            ConfirmCmm = new DelegateCommand(Confirm);
            CancleCmm = new DelegateCommand(Cancle);
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        private void Confirm()
        {
           DialogParameters paras=new DialogParameters();
            paras.Add("result1", "张三");
            paras.Add("result2", "李四");
            RequestClose?.Invoke(new DialogResult(ButtonResult.Yes, paras));
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        private void Cancle()
        {
           RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
    }
}
