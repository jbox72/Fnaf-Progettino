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

namespace fnaf_demo
{
    public partial class MainWindow : Window
    {
        GameEngine gameEngine = new GameEngine();

        public MainWindow()
        {
            InitializeComponent();

            gameEngine.Tick += Tick_gioco;
        }

        private void Tick_gioco(object sender, EventArgs e)
        {
            float Ba = gameEngine.ufficio.getBatteria();
            int iBa = (int)Ba;
            float Or = gameEngine.ufficio.getOrario();
            int iOR = (int)Or;

            Batteria_text.Text = iBa.ToString() + "%";

            Orario.Text = iOR.ToString()+ ":00";

            if (iBa <= 0)
            {
                Batteria_text.Text = "0%";
                MessageBox.Show("Hai perso! La batteria è finita!");
                Application.Current.Shutdown();
            }
        } 
    }
}