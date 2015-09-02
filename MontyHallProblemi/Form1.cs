using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MontyHallProblemi
{
    public partial class Form1 : Form
    {
        string[] resimList = new string[5];
        int[] rastgeleSecilenResimler = new int[3];
        Random rnd = new Random();
        int tiklamaSayisi1=0;
        int tiklamaSayisi2=0;
        int tiklamaSayisi3=0;

        public Form1()
        {
            InitializeComponent();
            resimList[0] = @"img\araba.jpg";
            resimList[1] = @"img\keci.jpg";
            resimList[2] = @"img\kapi.jpg";
            resimList[3] = @"img\Tick.jpg";
            resimList[4] = @"img\cross.jpg";
        }
        
        private void _pctrBoxTercih1_Click(object sender, EventArgs e)
        {
            tiklamaSayisi1++;
            // sayısal değerlerin hesaplanma kısmı
            if ((tiklamaSayisi1 == 1) && (tiklamaSayisi2 == 1 || tiklamaSayisi3 == 1)) // tercih değiştiyse
            {
                _lblDegistirildigiDurumlar.Text = (int.Parse(_lblDegistirildigiDurumlar.Text) + 1).ToString(); //değişiklik yapılan durumları 1 artır
                if (rastgeleSecilenResimler[0] ==2)
                {
                    _lblKazanmaSayisi2.Text = (int.Parse(_lblKazanmaSayisi2.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi2.Text ="%"+  YuzdeHesapla(int.Parse(_lblDegistirildigiDurumlar.Text),int.Parse(_lblKazanmaSayisi2.Text));
            }
            else if (tiklamaSayisi1 == 2) // 2 defa tercih1 seçildiyse (tercih değişmediyse)
            {
                _lblDegistirmegiDurumlar.Text = (int.Parse(_lblDegistirmegiDurumlar.Text) + 1).ToString();
                if (rastgeleSecilenResimler[0] == 2)
                {
                    _lblKazanmaSayisi1.Text = (int.Parse(_lblKazanmaSayisi1.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi1.Text = "%" + YuzdeHesapla(int.Parse(_lblDegistirmegiDurumlar.Text), int.Parse(_lblKazanmaSayisi1.Text));
            }



            if (_pctrBoxTercih2.ImageLocation != resimList[2] || _pctrBoxTercih3.ImageLocation != resimList[2]) // tercih1 tıklandığında diğerlerinden biri açılmış ise
            {
                _pctrBoxTercih1.ImageLocation = resimList[(rastgeleSecilenResimler[0] == 0 || rastgeleSecilenResimler[0] == 1) ? 1 : 0];
                _pctrBoxTercih2.ImageLocation = resimList[(rastgeleSecilenResimler[1] == 0 || rastgeleSecilenResimler[1] == 1) ? 1 : 0];
                _pctrBoxTercih3.ImageLocation = resimList[(rastgeleSecilenResimler[2] == 0 || rastgeleSecilenResimler[2] == 1) ? 1 : 0];
                return;
            }
            
            _pctrBoxTickCross1.Visible = true;
            // 0-> keçi 1-> keçi 2->araba
            if (rastgeleSecilenResimler[0]==0 || rastgeleSecilenResimler[0] == 1) //tercih1'de eşek varsa
            {
                if (rastgeleSecilenResimler[1] == 0 || rastgeleSecilenResimler[1] == 1) // tercih2'de eşek varsa tercih2'yi aç
                {
                    _pctrBoxTickCross2.ImageLocation = resimList[4];
                    _pctrBoxTercih2.ImageLocation = resimList[1];
                    _pctrBoxTickCross2.Visible = true;
                    _pctrBoxTercih2.Enabled = false;
                }
                else
                {
                    _pctrBoxTickCross3.ImageLocation = resimList[4];
                    _pctrBoxTercih3.ImageLocation = resimList[1];
                    _pctrBoxTickCross3.Visible = true;
                    _pctrBoxTercih3.Enabled = false;
                }
                
            }
            else //tercih1'de araba varsa tercih2 VEYA tercih3'ten birini rastgele aç
            {
                int rastgele = rnd.Next(0, 2);
                if (rastgele == 0)
                {
                    _pctrBoxTickCross2.ImageLocation = resimList[4];
                    _pctrBoxTercih2.ImageLocation = resimList[1];
                    _pctrBoxTickCross2.Visible = true;
                    _pctrBoxTercih2.Enabled = false;
                }
                else
                {
                    _pctrBoxTickCross3.ImageLocation = resimList[4];
                    _pctrBoxTercih3.ImageLocation = resimList[1];
                    _pctrBoxTickCross3.Visible = true;
                    _pctrBoxTercih3.Enabled = false;
                }
                
            }
        }

        private void _pctrBoxTercih2_Click(object sender, EventArgs e)
        {
            tiklamaSayisi2++;
            // sayısal değerlerin hesaplanma kısmı
            if ((tiklamaSayisi2 == 1) && (tiklamaSayisi1 == 1 || tiklamaSayisi3 == 1)) // tercih değiştiyse
            {
                _lblDegistirildigiDurumlar.Text = (int.Parse(_lblDegistirildigiDurumlar.Text) + 1).ToString(); //değişiklik yapılan durumları 1 artır
                if (rastgeleSecilenResimler[1] == 2)
                {
                    _lblKazanmaSayisi2.Text = (int.Parse(_lblKazanmaSayisi2.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi2.Text = "%" + YuzdeHesapla(int.Parse(_lblDegistirildigiDurumlar.Text), int.Parse(_lblKazanmaSayisi2.Text));
            }
            else if (tiklamaSayisi2 == 2) // 2 defa tercih2 seçildiyse (tercih değişmediyse)
            {
                _lblDegistirmegiDurumlar.Text = (int.Parse(_lblDegistirmegiDurumlar.Text) + 1).ToString();
                if (rastgeleSecilenResimler[1] == 2)
                {
                    _lblKazanmaSayisi1.Text = (int.Parse(_lblKazanmaSayisi1.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi1.Text = "%" + YuzdeHesapla(int.Parse(_lblDegistirmegiDurumlar.Text), int.Parse(_lblKazanmaSayisi1.Text));
            }

            
            if (_pctrBoxTercih1.ImageLocation != resimList[2] || _pctrBoxTercih3.ImageLocation != resimList[2]) // tercih2 tıklandığında diğerlerinden biri açılmış ise
            {
                _pctrBoxTercih1.ImageLocation = resimList[(rastgeleSecilenResimler[0] == 0 || rastgeleSecilenResimler[0] == 1) ? 1 : 0];
                _pctrBoxTercih2.ImageLocation = resimList[(rastgeleSecilenResimler[1] == 0 || rastgeleSecilenResimler[1] == 1) ? 1 : 0];
                _pctrBoxTercih3.ImageLocation = resimList[(rastgeleSecilenResimler[2] == 0 || rastgeleSecilenResimler[2] == 1) ? 1 : 0];
                return;
            }
            
            _pctrBoxTickCross2.Visible = true;
            // 0-> keçi 1-> keçi 2->araba
            if (rastgeleSecilenResimler[1] == 0 || rastgeleSecilenResimler[1] == 1) //tercih2'de eşek varsa
            {
                if (rastgeleSecilenResimler[0] == 0 || rastgeleSecilenResimler[0] == 1) // tercih1'de eşek varsa tercih1'yi aç
                {
                    _pctrBoxTickCross1.ImageLocation = resimList[4];
                    _pctrBoxTercih1.ImageLocation = resimList[1];
                    _pctrBoxTickCross1.Visible = true;
                    _pctrBoxTercih1.Enabled = false;
                }
                else
                {
                    _pctrBoxTickCross3.ImageLocation = resimList[4];
                    _pctrBoxTercih3.ImageLocation = resimList[1];
                    _pctrBoxTickCross3.Visible = true;
                    _pctrBoxTercih3.Enabled = false;
                }

            }
            else //tercih2'de araba varsa tercih1 VEYA tercih3'den birini rastgele aç
            {
                int rastgele = rnd.Next(0, 2);
                if (rastgele == 0)
                {
                    _pctrBoxTickCross1.ImageLocation = resimList[4];
                    _pctrBoxTercih1.ImageLocation = resimList[1];
                    _pctrBoxTickCross1.Visible = true;
                    _pctrBoxTercih1.Enabled = false;
                }
                else
                {
                    _pctrBoxTickCross3.ImageLocation = resimList[4];
                    _pctrBoxTercih3.ImageLocation = resimList[1];
                    _pctrBoxTickCross3.Visible = true;
                    _pctrBoxTercih3.Enabled = false;
                }
            }
        }

        private void _pctrBoxTercih3_Click(object sender, EventArgs e)
        {
            tiklamaSayisi3++;
            // sayısal değerlerin hesaplanma kısmı
            if ((tiklamaSayisi3 == 1) && (tiklamaSayisi1 == 1 || tiklamaSayisi2 == 1)) // tercih değiştiyse
            {
                _lblDegistirildigiDurumlar.Text = (int.Parse(_lblDegistirildigiDurumlar.Text) + 1).ToString(); //değişiklik yapılan durumları 1 artır
                if (rastgeleSecilenResimler[2] == 2)
                {
                    _lblKazanmaSayisi2.Text = (int.Parse(_lblKazanmaSayisi2.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi2.Text = "%" + YuzdeHesapla(int.Parse(_lblDegistirildigiDurumlar.Text), int.Parse(_lblKazanmaSayisi2.Text));
            }
            else if (tiklamaSayisi3 == 2) // 2 defa tercih3 seçildiyse (tercih değişmediyse)
            {
                _lblDegistirmegiDurumlar.Text = (int.Parse(_lblDegistirmegiDurumlar.Text) + 1).ToString();
                if (rastgeleSecilenResimler[2] == 2)
                {
                    _lblKazanmaSayisi1.Text = (int.Parse(_lblKazanmaSayisi1.Text) + 1).ToString();
                }
                _lblKazanmaYuzdesi1.Text = "%" + YuzdeHesapla(int.Parse(_lblDegistirmegiDurumlar.Text), int.Parse(_lblKazanmaSayisi1.Text));
            }
            

            if (_pctrBoxTercih1.ImageLocation != resimList[2] || _pctrBoxTercih2.ImageLocation != resimList[2]) // tercih3 tıklandığında diğerlerinden biri açılmış ise
            {
                _pctrBoxTercih1.ImageLocation = resimList[(rastgeleSecilenResimler[0] == 0 || rastgeleSecilenResimler[0] == 1) ? 1 : 0];
                _pctrBoxTercih2.ImageLocation = resimList[(rastgeleSecilenResimler[1] == 0 || rastgeleSecilenResimler[1] == 1) ? 1 : 0];
                _pctrBoxTercih3.ImageLocation = resimList[(rastgeleSecilenResimler[2] == 0 || rastgeleSecilenResimler[2] == 1) ? 1 : 0];
                return;
            }
            
            _pctrBoxTickCross3.Visible = true;
            // 0-> keçi 1-> keçi 2->araba
            if (rastgeleSecilenResimler[2] == 0 || rastgeleSecilenResimler[2] == 1) //tercih3'de keçi varsa
            {
                if (rastgeleSecilenResimler[0] == 0 || rastgeleSecilenResimler[0] == 1) // tercih1'de keçi varsa tercih1'yi aç
                {
                    _pctrBoxTickCross1.ImageLocation = resimList[4];
                    _pctrBoxTercih1.ImageLocation = resimList[1];
                    _pctrBoxTickCross1.Visible = true;
                    _pctrBoxTercih1.Enabled = false;
                }
                else 
                {
                    _pctrBoxTickCross2.ImageLocation = resimList[4];
                    _pctrBoxTercih2.ImageLocation = resimList[1];
                    _pctrBoxTickCross2.Visible = true;
                    _pctrBoxTercih2.Enabled = false;
                }

            }
            else //tercih3'de araba varsa tercih1 VEYA tercih2'den birini rastgele aç
            {
                int rastgele = rnd.Next(0, 2);
                if (rastgele == 0)
                {
                    _pctrBoxTickCross1.ImageLocation = resimList[4];
                    _pctrBoxTercih1.ImageLocation = resimList[1];
                    _pctrBoxTickCross1.Visible = true;
                    _pctrBoxTercih1.Enabled = false;
                }
                else
                {
                    _pctrBoxTickCross2.ImageLocation = resimList[4];
                    _pctrBoxTercih2.ImageLocation = resimList[1];
                    _pctrBoxTickCross2.Visible = true;
                    _pctrBoxTercih2.Enabled = false;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaslagicResimleriniYukle();
            Oyna();
        }
        void BaslagicResimleriniYukle()
        {
            // kapıların görüntülenmesi
            _pctrBoxTercih1.ImageLocation = resimList[2];
            _pctrBoxTercih2.ImageLocation = resimList[2];
            _pctrBoxTercih3.ImageLocation = resimList[2];

            //
            _pctrBoxTickCross1.ImageLocation = resimList[3];
            _pctrBoxTickCross2.ImageLocation = resimList[3];
            _pctrBoxTickCross3.ImageLocation = resimList[3];
        }
        void Oyna()
        {
            for (int i=0;i<3;i++)
            {
                rastgeleSecilenResimler[i] = i;
            }
            tiklamaSayisi1 = 0;
            tiklamaSayisi2 = 0;
            tiklamaSayisi3 = 0;
            Karistir();
        }
        void Karistir()
        {
           
            int rastgele; // 0-> keçi 1-> keçi 2->araba
            for (int i = 0; i < 3; i++)
            {
                rastgele = rnd.Next(0, 3);
                int gecici = rastgeleSecilenResimler[i];
                rastgeleSecilenResimler[i] = rastgeleSecilenResimler[rastgele];
                rastgeleSecilenResimler[rastgele] = gecici;
            }
        }

        void PictureBoxEnableTrueYap()
        {
            _pctrBoxTercih1.Enabled = true;
            _pctrBoxTercih2.Enabled = true;
            _pctrBoxTercih3.Enabled = true;
        }
        void TickCrossPictureBoxVisibleFalseYap()
        {
            _pctrBoxTickCross1.Visible = false;
            _pctrBoxTickCross2.Visible = false;
            _pctrBoxTickCross3.Visible = false;

        }
        private void _btnTekrar_Click(object sender, EventArgs e)
        {
            BaslagicResimleriniYukle();
            PictureBoxEnableTrueYap();
            TickCrossPictureBoxVisibleFalseYap();
            Oyna();
        }
        private float YuzdeHesapla(int toplam,int basariliSonuc)
        {
            return (float)basariliSonuc / toplam * 100;
        }

        private void _btnYenile_Click(object sender, EventArgs e)
        {
            _lblDegistirildigiDurumlar.Text = "0";
            _lblDegistirmegiDurumlar.Text = "0";
            _lblKazanmaSayisi1.Text = "0";
            _lblKazanmaSayisi2.Text = "0";
            _lblKazanmaYuzdesi1.Text = "%0";
            _lblKazanmaYuzdesi2.Text = "%0";

        }
    }
}