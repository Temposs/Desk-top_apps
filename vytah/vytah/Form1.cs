using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace vytah
{
    public partial class Form1 : Form
    { 
        string VytahRozkaz = ""; //prvorada priorita
        string PoschRozkaz = "";
        string VytahRozkaz2 =""; // druhorada priorita
        string PolohaVyt = "0"; // poloha vytahu
        bool StartStop = false;
        string rozkaz="0";
        string pseudoRozkaz = "";
        bool medziZastavka=false;
        bool dvere=false;
        
        private void StartAndStop(object sender, EventArgs e)
        {
            if (StartStop == false)
            {
                if (dvere == true)
                {
                    timer1.Enabled = false;
                    dvere = false;
                    StartStop = false;
                    button7.BackColor = Color.Green;
                    button8.BackColor = Color.Silver;
                    button7.Text = "Zapnut";
                    Vysvietenie("vymazat");
                    VytahRozkaz2 = "";
                    VytahRozkaz = "";
                    PoschRozkaz = "";
                    VysvietenieTlacidiel("", "vypnut");
                }
                else
                {
                    button7.BackColor = Color.Red;
                    button7.Text = "Vypnut";
                    StartStop = true;
                    timer1.Enabled = true;
                }
            }
        }

        private void ZavrietDvere(object sender, EventArgs e)
        {
            if (StartStop == false&&dvere==true)
            {
                int lenght = VytahRozkaz.Length + PoschRozkaz.Length;
                StartStop = true;
                button8.BackColor = Color.Silver;
                button8.Enabled = false;
                if (medziZastavka==false||lenght>0)
                {
                    if (medziZastavka == false&& lenght == 0)
                    {
                        if (VytahRozkaz2!= ""&&medziZastavka==false)
                        {
                            VytahRozkaz = VytahRozkaz2;
                            VytahRozkaz2 = "";
                            rozkaz = VytvorenieRozkazu(VytahRozkaz, PoschRozkaz);
                            label7.Text = VytahRozkaz;
                            label8.Text = PoschRozkaz;
                        }
                    }
                    else if(lenght>0)
                    {
                        rozkaz = VytvorenieRozkazu(VytahRozkaz, PoschRozkaz);
                    }
                    timer1.Enabled = true;
                    if (Convert.ToInt32(rozkaz) > Convert.ToInt32(PolohaVyt)&& lenght > 0)
                    {
                        panel9.BackColor = Color.Green;
                    }
                    else if(lenght > 0)
                    {
                        panel10.BackColor = Color.Green;
                    }
                }
                else
                {
                    timer1.Enabled = true;
                }
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (StartStop == false)
            {
                timer1.Enabled = false;
            }
            else
            {
                // ak je vytah zapnuty tak sa zacnu vykonavat prikazi
                if (rozkaz != PolohaVyt)
                {
                    button8.BackColor = Color.Silver;
                    button8.Enabled = false;
                    //vytah ide hore
                    if (Convert.ToInt32(rozkaz) > Convert.ToInt32(PolohaVyt))
                    {
                        PolohaVyt = Convert.ToString(Convert.ToInt32(PolohaVyt) + 1);

                    }
                    //vytah ide dole
                    else
                    {
                        PolohaVyt = Convert.ToString(Convert.ToInt32(PolohaVyt) - 1);
                    }
                    if (PolohaVyt==rozkaz)
                    {
                        button8.BackColor = Color.Yellow;
                        dvere = true;
                        medziZastavka = true;
                        button8.Enabled = true;
                        StartStop = false;
                        if (VytahRozkaz.IndexOf(PolohaVyt) != -1)
                        {
                            int vymazat = VytahRozkaz.IndexOf(PolohaVyt);
                            string firstHalf = "";
                            string secondHalf = "";
                            VysvietenieTlacidiel(PolohaVyt,"vytah");
                            for (int i = 0; i < VytahRozkaz.Length; i++)
                            {
                                if (i < vymazat)
                                {
                                    firstHalf += VytahRozkaz[i];
                                }
                                else if (i > vymazat)
                                {
                                    secondHalf += VytahRozkaz[i];
                                }
                            }
                            VytahRozkaz = firstHalf + secondHalf;

                        }

                        if (PoschRozkaz.IndexOf(PolohaVyt) != -1)
                        {
                            int vymazat = PoschRozkaz.IndexOf(PolohaVyt);
                            string firstHalf = "";
                            string secondHalf = "";
                            VysvietenieTlacidiel(PolohaVyt,"poschodie");
                            for (int i = 0; i < PoschRozkaz.Length; i++)
                            {
                                if (i < vymazat)
                                {
                                    firstHalf += PoschRozkaz[i];

                                }
                                else if (i > vymazat)
                                {
                                    secondHalf += PoschRozkaz[i];
                                }
                            }
                            PoschRozkaz = firstHalf + secondHalf;

                        }
                        
                        label7.Text = VytahRozkaz;
                        label8.Text = PoschRozkaz;
                        timer1.Enabled = false;
                        panel9.BackColor = Color.Red;
                        panel10.BackColor = Color.Red;

                    }
                }                          
                else
                {
                    button8.BackColor = Color.Yellow;
                    dvere = true;
                    StartStop = false;
                    timer1.Enabled = false;
                    medziZastavka = false;
                    button8.Enabled = true;
                    
                }

                if (VytahRozkaz.Length == 0)
                {
                    if (VytahRozkaz2 != "")
                    {
                        VytahRozkaz = VytahRozkaz2;
                        VytahRozkaz2 = "";
                        string rozkaz1= VytvorenieRozkazu(VytahRozkaz, PoschRozkaz);
                        if (Convert.ToInt32(rozkaz1) > Convert.ToInt32(PolohaVyt))
                        {
                            pseudoRozkaz="hore";
                        }
                        else
                        {
                            pseudoRozkaz = "dole";
                        }
                        medziZastavka = true;
                    }
                    else
                    {
                        medziZastavka = false;
                    }
                }
                //VYTVORENIE ROZKAZU
                Vysvietenie(PolohaVyt);
                int lenght = VytahRozkaz.Length + PoschRozkaz.Length;
                if (lenght > 0&&StartStop==false&& medziZastavka != false&&pseudoRozkaz=="")
                {
                    
                    if (rozkaz == PolohaVyt)
                    {
                        button8.Enabled = true;                       
                        button8.BackColor = Color.Yellow;
                        if (VytahRozkaz.IndexOf(PolohaVyt) != -1)
                        {
                            int vymazat = VytahRozkaz.IndexOf(PolohaVyt);
                            string firstHalf = "";
                            string secondHalf = "";
                            VysvietenieTlacidiel(PolohaVyt,"vytah");

                            for (int i = 0; i < VytahRozkaz.Length; i++)
                            {
                                if (i < vymazat)
                                {
                                    firstHalf += VytahRozkaz[i];
                                }
                                else if (i > vymazat)
                                {
                                    secondHalf += VytahRozkaz[i];
                                }
                            }
                            VytahRozkaz = firstHalf + secondHalf;

                        }

                        if (PoschRozkaz.IndexOf(PolohaVyt) != -1)
                        {
                            int vymazat = PoschRozkaz.IndexOf(PolohaVyt);
                            string firstHalf = "";
                            string secondHalf = "";
                            VysvietenieTlacidiel(PolohaVyt,"poschodie");

                            for (int i = 0; i < PoschRozkaz.Length; i++)
                            {
                                if (i < vymazat)
                                {
                                    firstHalf += PoschRozkaz[i];

                                }
                                else if (i > vymazat)
                                {
                                    secondHalf += PoschRozkaz[i];
                                }
                            }
                            PoschRozkaz = firstHalf + secondHalf;

                        }
                        
                        lenght = VytahRozkaz.Length + PoschRozkaz.Length;
                        if (lenght > 0)
                        {

                            rozkaz = VytvorenieRozkazu(VytahRozkaz, PoschRozkaz);
                        }
                    }
                }
                label14.Text = PolohaVyt;
                label7.Text = VytahRozkaz;
                label8.Text = PoschRozkaz;
            }
        }
        // vytah= true ; poschodie=false

        public void zadanie_prikazu(string zadany_rozkaz, bool vyt_posch)
        {
            
            //ak sa zadany rozkaz rovna sucastnej polohe vytahu tak sa nic neudeje
            if (zadany_rozkaz == PolohaVyt)
            {
                // nic sa neudeje
            }   
            
            else if (zadany_rozkaz != PolohaVyt)
            {
                if (vyt_posch == true)
                {
                    if (medziZastavka== false)
                    {
                        if (VytahRozkaz.IndexOf(Convert.ToChar(zadany_rozkaz)) == -1)
                        {
                            VytahRozkaz += zadany_rozkaz;
                        }
                    }
                    else if(VytahRozkaz2.IndexOf(zadany_rozkaz)==-1)
                    {
                        int[] VytahR = new int[VytahRozkaz.Length];
                        int rozkaz = Convert.ToInt32(zadany_rozkaz);
                        if (VytahRozkaz.IndexOf(Convert.ToChar(zadany_rozkaz)) == -1)
                        {
                            for (int i = 0; i < VytahRozkaz.Length; i++)
                            {
                                VytahR[i] = Convert.ToInt32(VytahRozkaz[i]) - 48;
                            }
                            Array.Sort(VytahR);
                            if ((Convert.ToInt32(PolohaVyt))<rozkaz&&rozkaz<VytahR[VytahR.Length-1])
                            {

                                VytahRozkaz += zadany_rozkaz;
                            }
                            else if((Convert.ToInt32(PolohaVyt)) > rozkaz && rozkaz > VytahR[0])
                            {
                                VytahRozkaz += zadany_rozkaz;
                            }
                            else 
                            {
                                VytahRozkaz2 += zadany_rozkaz;
                            }
                        }
                    }
                }
                else
                {
                    if (PoschRozkaz.IndexOf(Convert.ToChar(zadany_rozkaz)) == -1)
                    {
                        PoschRozkaz += zadany_rozkaz;
                    }
                }
                label7.Text = VytahRozkaz;
                label8.Text = PoschRozkaz;           
            }
        }

        /*funkcia ktora rozpoznava ci je aspon jedno cislo na poschodi
         stlacene a je cestou v smere vytahu*/
        public string vysledok(int NajblizsieVyt,string smer)
        {
            string vys="";           
            int[] PoschodieR = new int[PoschRozkaz.Length];
            if (PoschodieR.Length == 0)
            {                               
                return Convert.ToString(NajblizsieVyt);
            }
            else
            {
                for (int i = 0; i < PoschRozkaz.Length; i++)
                {
                    PoschodieR[i] = Convert.ToInt32(PoschRozkaz[i])-48;                  
                }
                Array.Sort(PoschodieR);
                //smer hore
                if (smer == "hore")
                {
                    foreach (int i in PoschodieR)
                    {
                        if (i <NajblizsieVyt&& i>Convert.ToInt32(PolohaVyt)) 
                        {
                            vys =Convert.ToString(i);                      
                            break;
                        }
                    }
                    // neexistuje ziadna zastavka po ceste
                    if (vys == "")
                    {
                        return Convert.ToString(NajblizsieVyt);
                    }
                    return vys;
                }
                // smer dole
                else
                {
                    string konecna = "";
                    foreach (int i in PoschodieR)
                    {
                        if (i > NajblizsieVyt && i< Convert.ToInt32(PolohaVyt))
                        {
                            konecna += Convert.ToString(i);                      
                        }
                    }
                    // neexistuje ziadna zastavka po ceste
                    if (konecna == "")
                    {
                        return Convert.ToString(NajblizsieVyt);
                    }
                    else
                    {
                        vys = Convert.ToString(konecna[konecna.Length-1]);
                        return vys;
                    }
                }
            }
        }

        // algoritmus na vydanie rozkazu
        // vytah = rozkazy z vytahu 
        //poschodie= rozkazy z poschodia
        public string VytvorenieRozkazu(string vytah,string poschodie)
        {  
            
            int[] VytahR = new int[vytah.Length];
            int[] PoschodieR = new int[poschodie.Length];
            string rozkaz = "";
            
            for (int i = 0; i < vytah.Length; i++)
            {
                VytahR[i] = Convert.ToInt32(vytah[i])-48;
            }

            for (int y = 0; y < poschodie.Length; y++)
            {
                PoschodieR[y] = Convert.ToInt32(poschodie[y])-48;
            }
            
            Array.Sort(VytahR);
            Array.Sort(PoschodieR);           
            
            // slacene su iba tlacidla z poschodia
            if (vytah.Length == 0&&poschodie.Length!=0)
            {

                int hore = 0;
                int dole = 0;
                foreach (int j in PoschodieR)
                {
                    if (j < Convert.ToInt32(PolohaVyt[0])-48)
                    {
                        dole += 1;
                    }
                    else if (j > Convert.ToInt32(PolohaVyt[0])-48)
                    {
                        hore += 1;
                    }
                }
          
                if (hore == 0&& dole != 0)
                {
                    rozkaz = vysledok(PoschodieR[dole-1], "dole");                  
                }
                else if (dole == 0&& hore != 0)
                {
                    rozkaz = vysledok(PoschodieR[0], "hore");        
                }
                //vytah ide hore
                else if (PoschodieR[dole] - (Convert.ToInt32(PolohaVyt[0])-48) < (Convert.ToInt32(PolohaVyt[0])-48) - PoschodieR[dole - 1])
                {
                    rozkaz = vysledok(PoschodieR[dole], "hore");
                }
                //vytah ide dole
                else if (PoschodieR[dole] - (Convert.ToInt32(PolohaVyt[0]) - 48) > (Convert.ToInt32(PolohaVyt[0]) - 48) - PoschodieR[dole - 1])
                {
                    rozkaz = vysledok(PoschodieR[dole - 1], "dole");
                }
                // obidve cislice maju rovnaku vzialenost kde pojde vytah sa necha na nahodu
                else
                {
                    /*vstupy pre hore aj dole sa rovnaju
                     pocitat zvoli smer nahodne*/
                    if (hore == dole)
                    {
                        
                        Random rnd = new Random();
                        int number = rnd.Next(1, 3);
                        //vytah ide hore
                        if (number == 1)
                        {
                            rozkaz = vysledok(PoschodieR[dole], "hore");
                        }
                        //vytah ide dole
                        else
                        {
                            rozkaz = vysledok(PoschodieR[dole - 1], "dole");
                        }
                    }
                    // vytah ide smerom hore
                    else if (hore > dole)
                    {
                        rozkaz = vysledok(PoschodieR[dole], "hore");
                    }
                    //vytah ide smerom dole
                    else if (hore < dole)
                    {
                        rozkaz = vysledok(PoschodieR[dole - 1], "dole");
                    }

                }
                return rozkaz;
            }

            //stlacene su aj tlacidla vo vytahu
            else
            {
                // rozhodnutie ci ide vytah hore alebo dole 
                int hore = 0;
                int dole = 0;
                /* pocitanie zadanych cisiel z vytahu smerom dole 
                 ale aj hore */
                foreach (int j in VytahR)
                {
                    if (j < Convert.ToInt32(PolohaVyt[0])-48)
                    {
                        dole += 1;
                    }
                    else if (j > Convert.ToInt32(PolohaVyt[0])-48)
                    {
                        hore += 1;
                    }
                }
                if (pseudoRozkaz != "")
                {
                    if (pseudoRozkaz == "hore")
                    {
                        rozkaz = vysledok(VytahR[dole], "hore");
                        pseudoRozkaz = "";
                    }
                    else if (pseudoRozkaz == "dole")
                    {
                        rozkaz = vysledok(VytahR[dole - 1], "dole");
                        pseudoRozkaz = "";
                    }
                }
                else
                {
                    if (dole == 0)
                    {
                        rozkaz = vysledok(VytahR[0], "hore");
                    
                    }
                    else if (hore == 0)
                    {
                        rozkaz = vysledok(VytahR[VytahR.Length - 1], "dole");
                    }
                    //vytah ide hore
                    else if (VytahR[dole] - (Convert.ToInt32(PolohaVyt[0]) - 48) < (Convert.ToInt32(PolohaVyt[0]) - 48) - VytahR[dole-1])
                    {
                        rozkaz = vysledok(VytahR[dole], "hore");                 
                    }
                    //vytah ide dole
                    else if (VytahR[dole] - (Convert.ToInt32(PolohaVyt[0]) - 48) > (Convert.ToInt32(PolohaVyt[0]) - 48) - VytahR[dole - 1])
                    {
                        rozkaz = vysledok(VytahR[dole-1], "dole");                    
                    }
                    // obidve cislice maju rovnaku vzialenost kde pojde vytah sa necha na nahodu
                    else
                    {
                        /*vstupy pre hore aj dole sa rovnaju
                         pocitat zvoli smer nahodne*/
                        if (hore == dole) 
                        {                       
                            Random rnd = new Random();
                            int number = rnd.Next(1,3);
                            //vytah ide hore
                            if (number == 1)
                            {
                                rozkaz = vysledok(VytahR[dole], "hore");
                            
                            }
                            //vytah ide dole
                            else
                            {
                                rozkaz = vysledok(VytahR[dole-1], "dole");
                            
                            }
                        }
                        // vytah ide smerom hore
                        else if (hore > dole)
                        {
                            rozkaz = vysledok(VytahR[dole], "hore");
                        }
                        //vytah ide smerom dole
                        else if(hore<dole)
                        {
                            rozkaz = vysledok(VytahR[dole-1], "dole");
                        }
                        if (pseudoRozkaz == "hore")
                        {
                            rozkaz = vysledok(VytahR[dole], "hore");
                            pseudoRozkaz = "";
                        }
                        else if (pseudoRozkaz == "dole")
                        {
                            rozkaz = vysledok(VytahR[dole - 1], "dole");
                            pseudoRozkaz = "";
                        }
                    }
                }
                return rozkaz;
            }   
        }

        public void Vysvietenie(string poloha)
        {
            switch (poloha)
            {
                case "0":
                    panel2.BackColor = Color.Yellow;
                    panel4.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel8.BackColor = Color.DimGray;
                    break;
                case "1":
                    panel4.BackColor = Color.Yellow;
                    panel2.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel8.BackColor = Color.DimGray;
                    break;
                case "2":
                    panel5.BackColor = Color.Yellow;
                    panel2.BackColor = Color.DimGray;
                    panel4.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel8.BackColor = Color.DimGray;
                    break;
                case "3":
                    panel6.BackColor = Color.Yellow;
                    panel2.BackColor = Color.DimGray;
                    panel4.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel8.BackColor = Color.DimGray;
                    break;
                case "4":
                    panel7.BackColor = Color.Yellow;
                    panel2.BackColor = Color.DimGray;
                    panel4.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    panel8.BackColor = Color.DimGray;
                    break;
                case "5":
                    panel8.BackColor = Color.Yellow;
                    panel2.BackColor = Color.DimGray;
                    panel4.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    break;
                case "vymazat":
                    panel8.BackColor = Color.DimGray;
                    panel2.BackColor = Color.DimGray;
                    panel4.BackColor = Color.DimGray;
                    panel6.BackColor = Color.DimGray;
                    panel7.BackColor = Color.DimGray;
                    panel5.BackColor = Color.DimGray;
                    break;
            }
        }
        
        public void VysvietenieTlacidiel(string poloha,string VytPosch)
        {
            switch (VytPosch)
            {
                case "vytah":
                    switch (poloha)
                    {
                        case "0":
                            button1.BackColor = Color.Gray;
                            break;
                        case "1":
                            button2.BackColor = Color.Gray;
                            break;
                        case "2":
                            button3.BackColor = Color.Gray;
                            break;
                        case "3":
                            button11.BackColor = Color.Gray;
                            break;
                        case "4":
                            button10.BackColor = Color.Gray;
                            break;
                        case "5":
                            button9.BackColor = Color.Gray;
                            break;
                    }                       
                    break;
                case "poschodie":
                    switch (poloha)
                    {
                        case "0":
                            button6.BackColor = Color.Gray;
                            break;
                        case "1":
                            button5.BackColor = Color.Gray;
                            break;
                        case "2":
                            button4.BackColor = Color.Gray;
                            break;
                        case "3":
                            button14.BackColor = Color.Gray;
                            break;
                        case "4":
                            button13.BackColor = Color.Gray;
                            break;
                        case "5":
                            button12.BackColor = Color.Gray;
                            break;
                    }
                    break;
                case "vypnut":
                    button6.BackColor = Color.Gray;
                    button5.BackColor = Color.Gray;
                    button4.BackColor = Color.Gray;
                    button14.BackColor = Color.Gray;
                    button13.BackColor = Color.Gray;
                    button12.BackColor = Color.Gray;
                    button1.BackColor = Color.Gray;
                    button2.BackColor = Color.Gray;
                    button3.BackColor = Color.Gray;
                    button11.BackColor = Color.Gray;
                    button10.BackColor = Color.Gray;
                    button9.BackColor = Color.Gray;
                    break;
            }
        }
        
















        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("0",true);
            if (PolohaVyt != "0")
            {
                button1.BackColor = Color.Red;
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("1", true);
            if (PolohaVyt != "1")
            {
             button2.BackColor = Color.Red;                
            }
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            zadanie_prikazu("2", true);
            if (PolohaVyt != "2")
            {
            button3.BackColor = Color.Red;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("0", false);
            if (PolohaVyt != "0")
            {
            button6.BackColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("1", false);
            if (PolohaVyt != "1")
            {
                button5.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("2", false);
            if (PolohaVyt != "2")
            {
            button4.BackColor = Color.Red;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("3", true);
            if (PolohaVyt != "3")
            {
            button11.BackColor = Color.Red;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("4", true);
            if (PolohaVyt != "4")
            {
            button10.BackColor = Color.Red;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("5", true);
            if (PolohaVyt != "5")
            {
            button9.BackColor = Color.Red;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("3", false);
            if (PolohaVyt != "3")
            {
            button14.BackColor = Color.Red;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("4", false);
            if (PolohaVyt != "4")
            {
            button13.BackColor = Color.Red;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            zadanie_prikazu("5", false);
            if (PolohaVyt != "5")
            {
            button12.BackColor = Color.Red;
            }
        }
    }
}
