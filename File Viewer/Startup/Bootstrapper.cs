using Autofac;
using FileViewer.UI.ViewModel;

namespace FileViewer.UI.Startup
{
    public class Bootstrapper
    {
        /// <summary>
        /// Uppstartshantering
        /// </summary>
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<FileViewerViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
