
namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400; // Defina a largura desejada da janela
            window.Height = 600; // Defina a altura desejada da janela;

            return window;
        }
    } // Fechar Class App
} // Fechar Namespace MauiAppLogin
