using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_subnet_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uprava();
        }
        private void uprava()
        {
            if (rbA.Checked)
            {
                tbBitMap1.Text = "0nnnnnnn";
                tbBitMap2.Text = "hhhhhhhh";
                tbBitMap3.Text = "hhhhhhhh";
                tbBitMap4.Text = "hhhhhhhh";
                int pocetBitov = 24;
                nuID1.Minimum = 1;
                nuID1.Maximum = 126;
                vyplnenieCB("klienti", cbPocKlientov, pocetBitov);
                vyplnenieCB("subsiete", cbPocSieti, pocetBitov-1);
            }
            else if (rbB.Checked)
            {
                tbBitMap1.Text = "10nnnnnn";
                tbBitMap2.Text = "nnnnnnnn";
                tbBitMap3.Text = "hhhhhhhh";
                tbBitMap4.Text = "hhhhhhhh";
                int pocetBitov = 16;
                nuID1.Minimum = 128;
                nuID1.Maximum = 191;
                vyplnenieCB("klienti", cbPocKlientov, pocetBitov);
                vyplnenieCB("subsiete", cbPocSieti, pocetBitov - 1);
            }
            else
            {
                tbBitMap1.Text = "110nnnnn";
                tbBitMap2.Text = "nnnnnnn";
                tbBitMap3.Text = "nnnnnnn";
                tbBitMap4.Text = "hhhhhhhh";
                int pocetBitov = 8;
                nuID1.Minimum = 192;
                nuID1.Maximum = 254;
                vyplnenieCB("klienti", cbPocKlientov, pocetBitov);
                vyplnenieCB("subsiete", cbPocSieti, pocetBitov - 1);
            }
        }
        private void vyplnenieCB(string typ,ComboBox cb,int pocetBitov) {
            cb.Items.Clear();
            switch (typ)
            {
                case "klienti":
                    for (int i = pocetBitov; i > 0; i--)
                    {
                        int hodnota = Convert.ToInt32(Math.Pow(2, i));

                        hodnota -= 2;
                        if (hodnota != 0)
                        {
                            cb.Items.Add(hodnota.ToString());
                        }
                    } 
                    break;
                case "subsiete":
                    for (int i = 0; i < pocetBitov; i++)
                    {
                        int hodnota = Convert.ToInt32(Math.Pow(2, i));
                        cb.Items.Add(hodnota.ToString());
                    }
                    cb.SelectedIndex = 0;
                    break;
            }
            
        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            uprava();
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            uprava();
            
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            uprava();

        }
        private void upravaBitMapy(ComboBox cb)
        {
            if (rbA.Checked)
            {
                string [] bitmap =new string [3];

                for (int i = 0; i < 24; i++)
                {
                    if (i < 8)
                    {
                        if (cb.SelectedIndex > i)
                        {
                            bitmap[0] += 's';
                        }
                        else
                        {
                            bitmap[0] += 'h';
                        }
                    }
                    else if (i < 16)
                    {

                        if (cb.SelectedIndex > i)
                        {
                            bitmap[1] += 's';
                        }
                        else
                        {
                            bitmap[1] += 'h';
                        }

                    }
                    else
                    {
                        if (cb.SelectedIndex > i)
                        {
                            bitmap[2] += 's';
                        }
                        else
                        {
                            bitmap[2] += 'h';
                        }
                    }
                }
                tbBitMap2.Text = bitmap[0];
                tbBitMap3.Text = bitmap[1];
                tbBitMap4.Text = bitmap[2];
            }
            else if (rbB.Checked)
            {
                string[] bitmap = new string[2];

                for (int i = 0; i < 16; i++)
                {
                    if (i < 8)
                    {
                        if (cb.SelectedIndex > i)
                        {
                            bitmap[0] += 's';
                        }
                        else
                        {
                            bitmap[0] += 'h';
                        }
                    }
                    else
                    {

                        if (cb.SelectedIndex > i)
                        {
                            bitmap[1] += 's';
                        }
                        else
                        {
                            bitmap[1] += 'h';
                        }

                    }

                }
                tbBitMap3.Text = bitmap[0];
                tbBitMap4.Text = bitmap[1];
            }
            else
            {
                string bitmap="";

                for(int i = 0; i < 8; i++)
                {
                    if (cb.SelectedIndex> i) {
                        bitmap += 's';
                    }
                    else
                    {
                        bitmap += 'h';
                    }
                }
                tbBitMap4.Text = bitmap;
            }
        }
        private string upravaMasky(string typ)
        {
            switch (typ)
            {
                case "subnet":
                    if (rbA.Checked)
                    { 
                        return vypocetSubMasky(3);
                    }
                    else if (rbB.Checked)
                    {
                        return vypocetSubMasky(2);
                    }
                    else
                    {
                        return vypocetSubMasky(1);
                    }
                    
                case "wild":
                    if (rbA.Checked)
                    {
                        return vypocetWildMasky(3);
                    }
                    else if (rbB.Checked)
                    {
                        return vypocetWildMasky(2);
                    }
                    else
                    {
                        return vypocetWildMasky(1);
                    }
            }
            return "ups";
        }
        
        private string vypocetSubMasky(int trieda)
        {
            int pocetBitov = cbPocSieti.SelectedIndex;
            int bajt = 0;
            string Submaska = "";
            for (int i = 0; i < trieda; i++)
            {
                if (pocetBitov > 8)
                {
                    pocetBitov -= 8;
                    bajt++;
                }
                else
                {
                    break;
                }
            }
            int[] maska = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (i < bajt + (4- trieda))
                {
                    maska[i] = 255;
                }
                else if (i == (bajt + (4 - trieda)))
                {
                    int hodnota = 0;
                    for (int z = 0; z < pocetBitov; z++)
                    {
                        hodnota += Convert.ToInt32(Math.Pow(2, 7 - z));
                    }
                    maska[i] = hodnota;
                }
                else if (i > (bajt + (4 - trieda)))
                {
                    maska[i] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Submaska += maska[i];
                }
                else
                {
                    Submaska += "." + maska[i];
                }
            }
            return Submaska;
        }
        private string vypocetWildMasky(int trieda)
        {
            int pocetBitov = cbPocSieti.SelectedIndex;
            int bajt = 0;
            string Wildmaska = "";
            for (int i = 0; i < trieda; i++)
            {
                if (pocetBitov > 8)
                {
                    pocetBitov -= 8;
                    bajt++;
                }
                else
                {
                    break;
                }
            }
            int[] maska = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (i < bajt + (4 - trieda))
                {
                    maska[i] = 0;
                }
                else if (i == (bajt + (4 - trieda)))
                {
                    int hodnota = 0;
                    for (int z = 0; z < (8-pocetBitov); z++)
                    {
                        hodnota += Convert.ToInt32(Math.Pow(2,z));
                    }
                    maska[i] = hodnota;
                }
                else if (i > (bajt + (4 - trieda)))
                {
                    maska[i] = 255;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Wildmaska += maska[i];
                }
                else
                {
                    Wildmaska += "." + maska[i];
                }
            }
            return Wildmaska;
        }
        private string rozmedzie()
        {
            if (rbA.Checked)
            {

                return vypocet_rozmedzia(3);
            }
            else if (rbB.Checked)
            {
                return vypocet_rozmedzia(2);
            }
            else
            {
                return vypocet_rozmedzia(1);
            }
        } 
        private string vypocet_rozmedzia(int trieda)
        {
            int pocetBitov = cbPocSieti.SelectedIndex;
            int bajt = 0;
            string dM = "";
            string hM = "";

            for (int i = 0; i < trieda; i++)
            {
                if (pocetBitov > 8)
                {
                    pocetBitov -= 8;
                    bajt++;
                }
                else
                {
                    break;
                }
            }

            int[] dolnaMedza = new int[4];
            int[] hornaMedza = new int[4];

            for (int i = 0; i < 4; i++)
            {
                if (i < bajt + (4 - trieda))
                {
                    dolnaMedza[i] = vyber_hodnoty(i);
                    hornaMedza[i] = vyber_hodnoty(i);
                }
                else if (i == (bajt + (4 - trieda)))
                { 
                    int hodnota = 0;
                    for (int z = 0; z < (8 - pocetBitov); z++)
                    {
                        //hodnota intervalu kde su umiestneny klienti
                        hodnota += Convert.ToInt32(Math.Pow(2, z));
                    }
                    int zadana_hodnota = vyber_hodnoty(bajt + (4 - trieda));
                    
                    
                    
                    for(int z = 1; z <256; z++)
                    {
                        if ((z * (hodnota+1))>zadana_hodnota)
                        {
                            if (i != 3)
                            {
                                dolnaMedza[i] = (z - 1) * (hodnota) + (z - 1);
                                hornaMedza[i]= (z) * (hodnota) + (z - 1);
                            }
                            else
                            {
                                dolnaMedza[i] = (z - 1) * (hodnota) + (z);
                                hornaMedza[i] = (z) * (hodnota) + (z-2);
                            }
            
                            break;
                        }
                    }
                }
                else if (i > (bajt + (4 - trieda))&&3!=i)
                {
                    dolnaMedza[i] = 0;
                    hornaMedza[i] = 255;
                }
                else
                {
                    dolnaMedza[i] = 1;
                    hornaMedza[i] = 254;
    
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    dM += dolnaMedza[i];
                    hM += hornaMedza[i];
                }
                else
                {
                    dM += "." + dolnaMedza[i];
                    hM += "." + hornaMedza[i];
                }
            }
            return dM+" - "+hM;
        }
        private int vyber_hodnoty(int index)
        {
            switch (index)
            {
                case 0:
                    return Convert.ToInt32(nuID1.Value);
                case 1:
                    return Convert.ToInt32(nuID2.Value);
                case 2:
                    return Convert.ToInt32(nuID3.Value);
                case 3:
                    return Convert.ToInt32(nuID4.Value);
                default:
                    return -1;
            }
        }
        private void cbPocSieti_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPocKlientov.SelectedIndex = cbPocSieti.SelectedIndex;
            upravaBitMapy(cbPocSieti);
            tbSubMaska.Text = upravaMasky("subnet");
            tbWildMaska.Text = upravaMasky("wild");
            tbRozsah.Text = rozmedzie();
        }
        private void cbPocKlientov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPocSieti.SelectedIndex = cbPocKlientov.SelectedIndex;
            upravaBitMapy(cbPocKlientov);
            tbSubMaska.Text = upravaMasky("subnet");
            tbWildMaska.Text = upravaMasky("wild");
            tbRozsah.Text = rozmedzie();
        }

        private void nuID2_ValueChanged(object sender, EventArgs e)
        {
            tbRozsah.Text = rozmedzie();
        }

        private void nuID3_ValueChanged(object sender, EventArgs e)
        {
            tbRozsah.Text = rozmedzie();
        }

        private void nuID4_ValueChanged(object sender, EventArgs e)
        {
            tbRozsah.Text = rozmedzie();
        }

        private void nuID1_ValueChanged(object sender, EventArgs e)
        {
            tbRozsah.Text = rozmedzie();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Peter Dendiš AIA\n 4.18.2021 ","Informácie");
        }
    }
}
