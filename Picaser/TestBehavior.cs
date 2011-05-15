using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Text;

namespace Picaser
{
    public class TestBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            //this.AssociatedObject.MouseLeftButtonDown += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (o, args) =>
            {
                StartUITest();
                timer.Stop();
            };
            timer.Start();



        }

        void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ////StartUITest();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("sender: {0}\n", sender.ToString());
            //sb.AppendFormat("e.OriginalSource: {0}\n", e.OriginalSource.ToString());

            //MessageBox.Show(sb.ToString());
        }

        public void StartUITest()
        {
            //(sender as FrameworkElement).
            var obj = this.AssociatedObject as DependencyObject;
            //int count = VisualTreeHelper.GetChildrenCount( obj );
            //MessageBox.Show(count.ToString());

         

            var allObjects = GetElements(obj);
            foreach (var item in allObjects)
            {
                if (item is TextBlock)
                {

                    AutomationPeer peer =
                        FrameworkElementAutomationPeer.CreatePeerForElement(item as UIElement);
                    //TextBlockAutomationPeer peer 
                    //    = FrameworkElementAutomationPeer.FromElement(item as UIElement) as TextBlockAutomationPeer;

                    //MessageBox.Show(peer.Owner.ToString());
                    peer.RaiseAutomationEvent(AutomationEvents.AutomationFocusChanged);
                    

                    //TextBlockAutomationPeer textBlockPeer = new TextBlockAutomationPeer(txt);
                    //invokeProvider.Invoke();

                    //MessageBox.Show(cccccc.ToString());
                    //var prop = item.GetValue(ContentControl.ContentProperty);
                }
            }
        }


        public List<DependencyObject> GetElements(DependencyObject obj)
        {
            int count = VisualTreeHelper.GetChildrenCount(obj);
            List<DependencyObject> result = new List<DependencyObject>();

            for (int i = 0; i < count; i++)
            {
                var childObj = VisualTreeHelper.GetChild(obj, i);
                result.Add(childObj);
                result.AddRange(GetElements(childObj));
            }

            return result;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            //this.AssociatedObject.MouseLeftButtonDown -= new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);
            //this.AssociatedObject.Loaded -= new RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
