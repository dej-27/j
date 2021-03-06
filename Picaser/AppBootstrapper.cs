namespace Picaser
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using Microsoft.Phone.Controls;
    using Caliburn.Micro;
    using Picaser.Data;
    using Picaser.Common;
    using Picasa.Api;
    using System.Windows;

    public class AppBootstrapper : PhoneBootstrapper
    {
        PhoneContainer container;

        protected override void Configure()
        {
            container = new PhoneContainer(RootFrame);

            container.RegisterPhoneServices();
            container.RegisterAllViewModelsForPages();
            //container.PerRequest<TabViewModel, TabViewModel>();


            container.RegisterSingleton<IAccountRepository, AccountRepository>();
            container.RegisterSingleton<IPhotoService<PicasaAlbum, PicasaMediaGroup>, GooglePicasaService>();

            container.RegisterSingleton<IStorage<PicasaAccount>, AccountStorage>();


            container.RegisterSingleton<IPhoneService<PhoneAlbum>, Phone.Api.PhoneService>();

            AddCustomConventions();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            //(new TestBehavior()).Attach(RootFrame);
        }

        protected override PhoneApplicationFrame CreatePhoneApplicationFrame()
        {
            //return base.CreatePhoneApplicationFrame();
            return new Microsoft.Phone.Controls.TransitionFrame();
        }

        static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<Pivot>(Pivot.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Pivot.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Pivot.HeaderTemplateProperty, viewModelType);
                        return true;
                    }

                    return false;
                };

            ConventionManager.AddElementConvention<Panorama>(Panorama.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Panorama.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Panorama.HeaderTemplateProperty, viewModelType);
                        return true;
                    }

                    return false;
                };
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }



        #region OldBootstrapper
        /*
         PhoneContainer container;  
          
        protected override void Configure()
        {
            container = new PhoneContainer(this);

			container.RegisterPhoneServices();
            container.RegisterAllViewModelsForPages();
            
            container.RegisterSingleton<IAccountRepository, AccountRepository>();
            container.RegisterSingleton<IPhotoService<PicasaAlbum, PicasaMediaGroup>, GooglePicasaService>();

            container.RegisterSingleton<IPhoneService<PhoneAlbum>, Phone.Api.PhoneService>();
           
            
            //container.InstallChooser<PhoneNumberChooserTask, PhoneNumberResult>();
            //container.InstallLauncher<EmailComposeTask>();

            AddCustomConventions();           
            
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            //var r = RootFrame;
            //RootFrame = new Microsoft.Phone.Controls.TransitionFrame(); 
            //RootFrame.Style = (Style)Application.Resources["mainFrameStyle"];
        }

      

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnUnhandledException(object sender, System.Windows.ApplicationUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.Message);
            base.OnUnhandledException(sender, e);
        }

        static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<Pivot>(Pivot.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) => {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Pivot.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Pivot.HeaderTemplateProperty, viewModelType);
                        return true;
                    }

                    return false;
                };

            ConventionManager.AddElementConvention<Panorama>(Panorama.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) => {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Panorama.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Panorama.HeaderTemplateProperty, viewModelType);
                        return true;
                    }

                    return false;
                };
                        
            //ConventionManager.AddElementConvention<MenuItem>(MenuItem.ItemsSourceProperty, "DataContext", "Click");
        }
         */
        #endregion

    }
}
