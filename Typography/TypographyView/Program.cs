using TypographyDatabaseImplement.Implements;
using TypographyBusinessLogic.BusinessLogics;
using TypographyBusinessLogic.OfficePackage;
using TypographyBusinessLogic.OfficePackage.Implements;
using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace TypographyView
{
    static class Program
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrintedStorage, PrintedsStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerStorage, ImplementerStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrintedLogic, PrintedLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkProcess, WorkModeling>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }

}
