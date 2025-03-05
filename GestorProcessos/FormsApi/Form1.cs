using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SeuApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarListView(); // Configura o ListView ao inicializar o formulário
        }

        // Evento de clique do botão para listar todos os processos
        private async void ListarTodosBt_Click(object sender, EventArgs e)
        {
            await CarregarProcessos();  // Chama o método assíncrono para carregar processos
        }

        // Método assíncrono para carregar os processos da API
        private async Task CarregarProcessos()
        {
            try
            {
                // Substitua com o endereço correto da sua API
                string url = "https://seuservidor.com/api/processos";

                using (var client = new HttpClient())
                {
                    // Fazendo a requisição GET assíncrona
                    var processosJson = await client.GetStringAsync(url);

                    // Deserializando o JSON para lista de objetos Processo
                    var processos = JsonConvert.DeserializeObject<List<Processo>>(processosJson);

                    // Limpa a lista anterior do ListView
                    ListViewGeral.Items.Clear();

                    // Preenche o ListView com os processos recebidos
                    foreach (var processo in processos)
                    {
                        var item = new ListViewItem(processo.Id.ToString());
                        item.SubItems.Add(processo.Nome);
                        item.SubItems.Add(processo.Descricao);
                        ListViewGeral.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe erro caso haja algum problema ao carregar os dados
                MessageBox.Show($"Erro ao carregar processos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Configuração do ListView
        private void ConfigurarListView()
        {
            ListViewGeral.View = View.Details;  // Define a visualização do ListView como 'Detalhes'
            ListViewGeral.Columns.Add("Id", -2, HorizontalAlignment.Left);
            ListViewGeral.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            ListViewGeral.Columns.Add("Descricao", -2, HorizontalAlignment.Left);
        }

        // Classe Processo (modelo)
        public class Processo
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
        }
    }
}
