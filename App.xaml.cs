
namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Define uma página em branco ou de Loading primeiro
            MainPage = new ContentPage { Content = new ActivityIndicator { IsRunning = true } };

            // Executa a verificação de forma segura
            InicializarApp();
        }

        private async void InicializarApp()
        {
            try
            {
                // Busca o usuário logado com segurança
                string? usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                // Garante que a troca de tela ocorra na Thread Principal (UI)
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (usuario_logado == null)
                    {
                        MainPage = new Login();
                    }
                    else
                    {
                        MainPage = new Protegida();
                    }
                });
            }
            catch (Exception ex)
            {
                // Trate possíveis erros de leitura do SecureStorage aqui
                MainThread.BeginInvokeOnMainThread(() => MainPage = new Login());
            }
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
