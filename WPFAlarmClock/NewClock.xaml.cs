using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAlarmClock
{
    /// <summary>
    /// NewClock.xaml 的交互逻辑
    /// </summary>
    public partial class NewClock : UserControl
    {
        public NewClock()
        {
            InitializeComponent();
        }

        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name | string.IsNullOrEmpty(name)))
                {
                    
                    return (T)parent;
                }
                
                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }


        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            //DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)sender);

            //测试
            string str = GetParentObject<ListBox>((DependencyObject)sender, "lbxClock").ToString();

            string str1 = GetParentObject<NewClock>((DependencyObject)sender, "user1").ToString();
            MessageBox.Show(str1);

        }
    }
}
