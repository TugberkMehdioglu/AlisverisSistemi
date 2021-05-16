using KargoWinUI.DTOClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargoWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CargoDTO cDTO = new CargoDTO //Object initializer ile girilen değerleri atadık
            {
                ID = Convert.ToInt32(txtID.Text),
                Status = cmbStatus.SelectedItem as string
            };

            HttpClient client = new HttpClient(); //API ile haberleşmek için değişken oluşturup instance aldık

            client.BaseAddress = new Uri("https://localhost:44351/api/"); //API adresini tanımladık

            Task<HttpResponseMessage> postTask = client.PutAsJsonAsync("Home/UpdateStatus", cDTO); //Post yöntemiyle Json tipinde veri yolladık

            HttpResponseMessage sonuc;

            try
            {
                sonuc = postTask.Result; //API'dan dönen mesajları yakaladık
            }
            catch (Exception)
            {

                MessageBox.Show("Sistemden kaynaklı sorun oluştu");
                return; //API'dan kaynaklı sorun olduğunda mesajı kullanıcıya göster
            }

            bool result;

            if (sonuc.IsSuccessStatusCode) result = true;
            else result = false;

            if (result) //Başarılı status kodu dönerse
            {
                MessageBox.Show("İşlem başarılı");
                return;
            }
            else MessageBox.Show("İstenilen bilgiler eksik/hatalı");
        }
    }
}
