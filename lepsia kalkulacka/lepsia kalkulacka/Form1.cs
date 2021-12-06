using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lepsia_kalkulacka
{
    public partial class Form1 : Form
    {
        double medzi_vysledok;
        double specialny_medzi_vysledok;
        double operacie;
        bool displej = false; // ak je true tak displej=medzi vysledok || inak ukazuje zadanu hodnotu
        bool konecny_vysledok = false;
        bool chyba = false;
        bool sinus =false;
        bool cosinus = false;
        bool odmocnina = false;
        bool mocnina = false;
        bool tangens = false;
        bool exponent = false;
        string zadana_hodnota;
        string scitanec;
        string operacia;
        string specialny_medzi_vysledok_1 = "";
        string[] zadavany_exponent;
        string[] vystupy;
        string do_prikladu = "";
        int suctove_operacie = 0;
        int zaporna_hodnota = 0;
        public Form1()
        {
            InitializeComponent();
            zadana_hodnota = textBox1.Text;
        }
        static string [] funkcia_zadavanie_cisla(string cislo, bool konecny_vysledok ,string clear, string specialny_medzi_vysledok_1, string textBox1, string[] zadavany_exponent,string do_prikladu,bool displej, string label1, string scitanec, string zadana_hodnota, double medzi_vysledok, string operacia)
        {
            string displej1 = "";
            string[] vystupy = { specialny_medzi_vysledok_1, clear,zadana_hodnota,displej1,do_prikladu };
            if (konecny_vysledok == true)
            { }
            else
            {
                if (textBox1.IndexOf('e') != -1)
                {
                    zadavany_exponent = textBox1.Split('+', '-');
                    if (zadavany_exponent[1] == "0")
                    {
                        zadavany_exponent = textBox1.Split('+');
                        if (zadavany_exponent.Length == 1)
                        {
                            zadavany_exponent = textBox1.Split('-');
                            textBox1= zadavany_exponent[0] + "-" + cislo;
                        }
                        else
                        {
                            textBox1= zadavany_exponent[0] + "+" + cislo;
                        }
                    }
                    else
                    {
                        textBox1 = textBox1+ cislo;
                    }
                    do_prikladu = "(" + textBox1+ ")";
                    zadana_hodnota = textBox1;
                }
                else
                {
                    if (textBox1 == "0" || displej == true)
                    {
                        zadana_hodnota = cislo;
                    }
                    else
                    {
                        zadana_hodnota = textBox1+ cislo;
                    }
                }           
                clear= "CE";
                vystupy[3] = "false";   
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1, scitanec, zadana_hodnota, medzi_vysledok, operacia);
            vystupy[0] = specialny_medzi_vysledok_1;
            vystupy[1] = clear;
            vystupy[2] = zadana_hodnota;
            vystupy[4] = do_prikladu;
            return vystupy;
        }
        static string specialny_vysledok(string label1,string scitanec,string zadana_hodnota,double medzi_vysledok1,string operacia)
        {
            try
            {
                double medzi_vysledok = 0;
                if (label1[label1.Length-1]!='+'&& label1[label1.Length - 1] != '-' && label1[label1.Length - 1] != '*' && label1[label1.Length - 1] != '/')
                {
                    medzi_vysledok =Convert.ToDouble(zadana_hodnota);
                }
                else
                {
                    switch (label1[label1.Length - 1])
                    {
                        case '-':
                            medzi_vysledok = Convert.ToDouble(scitanec) - Convert.ToDouble(zadana_hodnota);
                            break;
                        case '+':
                            medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(zadana_hodnota);
                            break;
                        case '*':
                            if(operacia=="+")
                            {
                                medzi_vysledok1 = Convert.ToDouble(medzi_vysledok1)*Convert.ToDouble(zadana_hodnota);    
                                medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(medzi_vysledok1);
                            }
                            else if(operacia=="-")
                            {
                                medzi_vysledok1 = Convert.ToDouble(medzi_vysledok1) * Convert.ToDouble(zadana_hodnota);
                                medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(medzi_vysledok1);
                            }
                            else
                            {
                                medzi_vysledok = Convert.ToDouble(medzi_vysledok1) * Convert.ToDouble(zadana_hodnota);
                            }
                            break;
                        case '/':
                            if (operacia == "+")
                            {
                                medzi_vysledok1 = Convert.ToDouble(medzi_vysledok1) / Convert.ToDouble(zadana_hodnota);
                                medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(medzi_vysledok1);
                            }
                            else if (operacia == "-")
                            {
                                medzi_vysledok1 = Convert.ToDouble(medzi_vysledok1) / Convert.ToDouble(zadana_hodnota);
                                medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(medzi_vysledok1);
                            }
                            else
                            {
                                medzi_vysledok = Convert.ToDouble(medzi_vysledok1) / Convert.ToDouble(zadana_hodnota);
                            }
                            break;
                    }
                }
                return Convert.ToString(medzi_vysledok);
            }
            catch(FormatException)
            {
                return "0";
            }
        }
        static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        private void comma_Click(object sender, EventArgs e)
        {
            if (konecny_vysledok == true)
            { }
            else
            {
                if (textBox1.Text.IndexOf('e') != -1)
                {
                    //nic :D

                    do_prikladu = "(" + textBox1.Text + ")";
                }
                else
                {
                    if (textBox1.Text.IndexOf('.') == -1)
                    {
                        zadana_hodnota = textBox1.Text + ".";
                    }
                    textBox1.Text = zadana_hodnota;
                }
                displej = false;
                clear.Text = "CE";
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            if(konecny_vysledok==true)
            {}
            else
            {
                if (displej == true)
                {
                    string uprava = "";
                    if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/' || label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                    {
                        if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/')
                        {
                            if (Convert.ToString(medzi_vysledok) != textBox1.Text)
                            {
                                scitanec = Convert.ToString(specialny_medzi_vysledok);
                            }
                            else
                            {
                                scitanec = Convert.ToString(medzi_vysledok);
                            }
                        }
                        if (label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                        {
                            suctove_operacie = 1;
                        }
                        for (int i = 0; i < label1.Text.Length - 1; i++)
                        {
                            uprava = uprava + label1.Text[i];
                        }
                        label1.Text = uprava + "=";
                    }
                    else
                    {
                        label1.Text = label1.Text + textBox1.Text + "=";
                    }
                }
                else
                {
                    operacie++;
                    if (operacie == 1)
                    {
                        medzi_vysledok = Convert.ToDouble(zadana_hodnota);
                    }
                    else
                    {
                        switch (label1.Text[label1.Text.Length - 1])
                        {
                            case '/':
                                medzi_vysledok = medzi_vysledok / Convert.ToDouble(zadana_hodnota);
                                break;
                            case '*':
                                medzi_vysledok = medzi_vysledok * Convert.ToDouble(zadana_hodnota);
                                break;
                            case '-':
                                medzi_vysledok = Convert.ToDouble(scitanec) - Convert.ToDouble(zadana_hodnota);
                                displej = true;
                                break;
                            case '+':
                                medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(zadana_hodnota);
                                displej = true;
                                break;
                        }
                    }
                    if (displej == true)
                    {
                        textBox1.Text = Convert.ToString(medzi_vysledok);
                        scitanec = textBox1.Text;
                    }
                    if (sinus == true || cosinus == true || odmocnina == true || mocnina == true || tangens == true || exponent == true)
                    {
                        if (label1.Text == "0")
                        {
                            if (zaporna_hodnota == 1)
                            {
                                label1.Text = "(-" + do_prikladu + ")" + "=";
                            }
                            else
                            {
                                label1.Text = do_prikladu + "=";
                            }
                        }
                        else
                        {
                            if (zaporna_hodnota == 1)
                            {
                                label1.Text = label1.Text + "(-" + do_prikladu + ")" + "=";
                            }
                            else
                            {
                                label1.Text = label1.Text + do_prikladu + "=";
                            }
                        }
                        sinus = false;
                        cosinus = false;
                        mocnina = false;
                        odmocnina = false;
                        tangens = false;
                        exponent = false;
                        zaporna_hodnota = 0;
                    }
                    else
                    {
                        if (label1.Text == "0")
                        {
                            if (zaporna_hodnota == 1)
                            {
                                label1.Text = "(" + zadana_hodnota + ")" + "=";
                            }
                            else
                            {
                                label1.Text = zadana_hodnota + "=";
                            }
                        }
                        else
                        {
                            if (zaporna_hodnota == 1)
                            {
                                label1.Text = label1.Text + "(" + zadana_hodnota + ")" + "=";
                            }
                            else
                            {
                                label1.Text = label1.Text + zadana_hodnota + "=";
                            }
                        }
                        zaporna_hodnota = 0;
                    }
                }
                if (suctove_operacie == 0 && displej == false)
                {
                    scitanec = Convert.ToString(medzi_vysledok);
                    suctove_operacie = 1;
                }
                if (displej == false)
                {

                    switch (operacia)
                    {
                        case "+":
                            scitanec = Convert.ToString(Convert.ToDouble(scitanec) + medzi_vysledok);
                            break;
                        case "-":
                            scitanec = Convert.ToString(Convert.ToDouble(scitanec) - medzi_vysledok);
                            break;
                    }
                    suctove_operacie++;
                    textBox1.Text = scitanec;
                    displej = true;
                }

                listBox1.Items.Add(label1.Text + textBox1.Text);                       
                konecny_vysledok = true;
            }
        }
    
       
        private void butt0_Click(object sender, EventArgs e)
        {
            if(konecny_vysledok==true)
            {}
            else
            {
                if(textBox1.Text.IndexOf('e') != -1)
                {
                    zadavany_exponent = textBox1.Text.Split('+', '-');
                    if (zadavany_exponent[1]=="0")
                    {
                    }
                    else 
                    {
                        textBox1.Text = textBox1.Text + "0";
                    }
                    do_prikladu = "(" + textBox1.Text + ")";
                    zadana_hodnota = textBox1.Text;
                }
                else
                {
                    if (textBox1.Text == "0" || displej == true)
                    {
                        zadana_hodnota = "0";
                    }
                    else
                    {
                        zadana_hodnota = textBox1.Text + "0";
                    }
                }
                textBox1.Text = zadana_hodnota;
                displej = false;
            }
            specialny_medzi_vysledok_1=specialny_vysledok(label1.Text,scitanec, zadana_hodnota,medzi_vysledok,operacia);
        }

        private void butt1_Click(object sender, EventArgs e)
        {
            string cislo="1";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text,scitanec,zadana_hodnota,medzi_vysledok,operacia);
        }

        private void butt2_Click(object sender, EventArgs e)
        {
            string cislo = "2";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt3_Click(object sender, EventArgs e)
        {
            string cislo = "3";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt4_Click(object sender, EventArgs e)
        {
            string cislo = "4";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }
        private void butt5_Click(object sender, EventArgs e)
        {
            string cislo = "5";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt6_Click(object sender, EventArgs e)
        {
            string cislo = "6";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt7_Click(object sender, EventArgs e)
        {
            string cislo = "7";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt8_Click(object sender, EventArgs e)
        {
            string cislo = "8";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void butt9_Click(object sender, EventArgs e)
        {
            string cislo = "9";
            if (konecny_vysledok == true)
            { }
            else
            {
                vystupy = funkcia_zadavanie_cisla(cislo, konecny_vysledok, clear.Text, specialny_medzi_vysledok_1, textBox1.Text, zadavany_exponent, do_prikladu, displej, label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
                zadana_hodnota = vystupy[2];
                textBox1.Text = zadana_hodnota;
                displej = false;
                clear.Text = vystupy[1];
                do_prikladu = vystupy[4];
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void plus_Click(object sender, EventArgs e)
        {
            try
            {
                chyba = false;
                if (zadana_hodnota == "" && displej == true)
                {
                    zadana_hodnota = "0";
                }
                if (scitanec == textBox1.Text && displej == true)
                {
                    zadana_hodnota = "";
                    displej = true;
                }
                else
                {
                    if ((zadana_hodnota != textBox1.Text&&displej==true || zadana_hodnota != textBox1.Text && displej == false) || textBox1.Text == zadana_hodnota && displej == true)
                    {   
                        zadana_hodnota = textBox1.Text;
                        Convert.ToDouble(zadana_hodnota);
                        Convert.ToString(zadana_hodnota);
                        displej = false;
                        chyba = false;
                        clear.Text = "CE";
                    }
                }
            }
            catch(FormatException)
            {
                textBox1.Text = "0";
                chyba = true;
                displej = true;

            }
            if(konecny_vysledok==true)
            {
                label1.Text = "0";
                konecny_vysledok = false;
                medzi_vysledok =0;
                zadana_hodnota = textBox1.Text;
                displej = false;
            }
            if (displej == true&&chyba==false)
            {
                string uprava = "";
                if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/'||label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                {
                    if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/')
                    {
                        medzi_vysledok =Convert.ToDouble(specialny_medzi_vysledok_1);
                        scitanec = specialny_medzi_vysledok_1;
                        suctove_operacie = 1;
                    }
                    if (label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                    {
                        suctove_operacie=1;
                    }
                    for (int i = 0; i < label1.Text.Length - 1; i++)
                    {
                        uprava = uprava + label1.Text[i];
                    }
                    label1.Text = uprava + "+";
                }
                else
                {
                    label1.Text = label1.Text + textBox1.Text + "+";
                }
            }
            else if(chyba == false&&displej==false)
            {
                operacie++;
                if (operacie == 1)
                {
                    medzi_vysledok = Convert.ToDouble(zadana_hodnota);                        
                }
                else
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '/':
                            medzi_vysledok = medzi_vysledok / Convert.ToDouble(zadana_hodnota);
                            break;
                        case '*':
                            medzi_vysledok = medzi_vysledok * Convert.ToDouble(zadana_hodnota);
                            break;
                        case '-':
                            medzi_vysledok = Convert.ToDouble(scitanec) - Convert.ToDouble(zadana_hodnota);
                            displej=true;
                            break;
                        case '+':
                            medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(zadana_hodnota);
                            displej = true;
                            break;
                    }
                }
                if(displej==true)
                {
                    textBox1.Text =Convert.ToString(medzi_vysledok);
                    scitanec = textBox1.Text;
                }
                if (sinus== true || cosinus== true || odmocnina== true || mocnina== true || tangens== true || exponent== true)
                {
                    if (label1.Text == "0")
                    {
                        if (zaporna_hodnota==1)
                        {
                            label1.Text ="(-"+do_prikladu+ ")"+ "+";
                        }
                        else
                        {
                            label1.Text = do_prikladu + "+";
                        }
                    }
                    else
                    {
                        if (zaporna_hodnota==1)
                        {
                            label1.Text = label1.Text +"(-"+ do_prikladu+")"+ "+";
                        }
                        else
                        {
                            label1.Text = label1.Text + do_prikladu + "+";
                        }
                    }
                    sinus = false;
                    cosinus = false;
                    mocnina = false;
                    odmocnina = false;
                    tangens = false;
                    exponent = false;
                    zaporna_hodnota = 0;
                }
                else
                {
                    if (label1.Text == "0")
                    {
                        if (zaporna_hodnota==1)
                        {
                            label1.Text ="("+ zadana_hodnota +")"+ "+";
                        }
                        else
                        {
                            label1.Text = zadana_hodnota + "+";
                        }
                    }
                    else
                    {
                        if(zaporna_hodnota==1)
                        {
                            label1.Text = label1.Text +"("+zadana_hodnota+")"+ "+";
                        }
                        else
                        {
                            label1.Text = label1.Text + zadana_hodnota + "+";
                        }
                    }
                    zaporna_hodnota = 0;
                }
                chyba = false;
            }
            if (suctove_operacie == 0&&displej==false&&chyba==false)
            {
                scitanec =Convert.ToString(medzi_vysledok);
                suctove_operacie=1;
            }
            if (displej==false)
            {

                switch (operacia)
                {
                    case "+":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) + medzi_vysledok);
                        break;
                    case "-":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) - medzi_vysledok);
                        break;
                }
                suctove_operacie++;
                textBox1.Text = scitanec;
                displej = true;           
            }
            operacia = "+";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            try
            {
                chyba = false;
                if (zadana_hodnota == "" && displej == true)
                {
                    zadana_hodnota = "0";
                }
                if (scitanec == textBox1.Text && displej == true)
                {
                    zadana_hodnota = "";
                    displej = true;
                }
                else
                {
                    if ((zadana_hodnota != textBox1.Text && displej == true || zadana_hodnota != textBox1.Text && displej == false) || textBox1.Text == zadana_hodnota && displej == true)
                    {
                        zadana_hodnota = textBox1.Text;
                        Convert.ToDouble(zadana_hodnota);
                        Convert.ToString(zadana_hodnota);
                        displej = false;
                        chyba = false;
                        clear.Text = "CE";
                    }
                }
            }
            catch (FormatException)
            {
                textBox1.Text = "0";
                chyba = true;
                displej = true;

            }
            if (konecny_vysledok == true)
            {
                label1.Text = "0";
                konecny_vysledok = false;
                medzi_vysledok = 0;
                zadana_hodnota = textBox1.Text;
                displej = false;
            }
            if (displej == true && chyba == false)
            {
                string uprava = "";
                if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/' || label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                {
                    if(label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/')
                    {
                        medzi_vysledok = Convert.ToDouble(specialny_medzi_vysledok_1);
                        scitanec = specialny_medzi_vysledok_1;
                        suctove_operacie = 1;
                    }
                    if (label1.Text[label1.Text.Length - 1] == '-' || label1.Text[label1.Text.Length - 1] == '+')
                    {
                        suctove_operacie = 1;
                    }
                    for (int i = 0; i < label1.Text.Length - 1; i++)
                    {
                        uprava = uprava + label1.Text[i];
                    }
                    label1.Text = uprava + "-";
                }
                else
                {
                    label1.Text = label1.Text + textBox1.Text + "-";
                }
            }
            else
            {
                operacie++;
                if (operacie == 1)
                {
                    medzi_vysledok = Convert.ToDouble(zadana_hodnota);
                }
                else
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '/':
                            medzi_vysledok = medzi_vysledok / Convert.ToDouble(zadana_hodnota);
                            break;
                        case '*':
                            medzi_vysledok = medzi_vysledok * Convert.ToDouble(zadana_hodnota);
                            break;
                        case '-':
                            medzi_vysledok = Convert.ToDouble(scitanec) - Convert.ToDouble(zadana_hodnota);
                            displej = true;
                            break;
                        case '+':
                            medzi_vysledok = Convert.ToDouble(scitanec) + Convert.ToDouble(zadana_hodnota);
                            displej = true;
                            break;
                    }
                }
                if (displej == true)
                {
                    textBox1.Text = Convert.ToString(medzi_vysledok);
                    scitanec = textBox1.Text;
                }
                if (sinus == true || cosinus == true || odmocnina == true || mocnina == true || tangens == true || exponent == true)
                {
                    if (label1.Text == "0")
                    {
                        if (zaporna_hodnota == 1)
                        {
                            label1.Text = "(-" + do_prikladu + ")" + "-";
                        }
                        else
                        {
                            label1.Text = do_prikladu + "-";
                        }
                    }
                    else
                    {
                        if (zaporna_hodnota == 1)
                        {
                            label1.Text = label1.Text + "(-" + do_prikladu + ")" + "-";
                        }
                        else
                        {
                            label1.Text = label1.Text + do_prikladu + "-";
                        }
                    }
                    sinus = false;
                    cosinus = false;
                    mocnina = false;
                    odmocnina = false;
                    tangens = false;
                    exponent = false;
                    zaporna_hodnota = 0;
                }
                else
                {
                    if (label1.Text == "0")
                    {
                        if (zaporna_hodnota == 1)
                        {
                            label1.Text = "(" + zadana_hodnota + ")" + "-";
                        }
                        else
                        {
                            label1.Text = zadana_hodnota + "-";
                        }
                    }
                    else
                    {
                        if (zaporna_hodnota == 1)
                        {
                            label1.Text = label1.Text + "(" + zadana_hodnota + ")" + "-";
                        }
                        else
                        {
                            label1.Text = label1.Text + zadana_hodnota + "-";
                        }
                    }
                    zaporna_hodnota = 0;
                }
            }
            if (suctove_operacie == 0 && displej == false&&chyba==false)
            {
                scitanec = Convert.ToString(medzi_vysledok);
                suctove_operacie=1;
            }
            if (displej == false)
            {

                switch (operacia)
                {
                    case "*":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) * medzi_vysledok);
                        break;
                    case "/":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) / medzi_vysledok);
                        break;
                    case "+":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) + medzi_vysledok);
                        break;
                    case "-":
                        scitanec = Convert.ToString(Convert.ToDouble(scitanec) - medzi_vysledok);
                        break;
                }
                suctove_operacie++;
                textBox1.Text = scitanec;
                displej = true;
            }
            operacia = "-";
        }

        private void krat_Click(object sender, EventArgs e)
        {
            try
            {
                chyba = false;
                if (zadana_hodnota == "" && displej == true)
                {
                    zadana_hodnota = "0";
                }
                if (Convert.ToString(medzi_vysledok)== textBox1.Text && displej == true)
                {
                    zadana_hodnota = "0";
                    displej = true;
                }
                else
                {
                    if ((Convert.ToString(medzi_vysledok) != textBox1.Text && displej == true || zadana_hodnota != textBox1.Text && displej == false) || textBox1.Text == zadana_hodnota && displej == true)
                    {
                        zadana_hodnota = textBox1.Text;
                        Convert.ToDouble(zadana_hodnota);
                        Convert.ToString(zadana_hodnota);
                        displej = false;
                        chyba = false;
                        clear.Text = "CE";
                    }
                }
            }
            catch (FormatException)
            {
                zadana_hodnota = "1";
                textBox1.Text = "0";
                chyba = true;
                displej = true;

            }
            if (konecny_vysledok == true)
            {
                label1.Text = "0";
                konecny_vysledok = false;
                medzi_vysledok = Convert.ToDouble(textBox1.Text);
                operacia = "";
                operacie = 0;
                zadana_hodnota = textBox1.Text;
                displej = false;
            }
            if (displej == true && chyba == false)
            {
                string uprava = "";
                if (label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    if (suctove_operacie >= 1)
                    {
                        medzi_vysledok =Convert.ToDouble(specialny_medzi_vysledok_1);
                        //medzi_vysledok = Convert.ToDouble(scitanec);                  
                        for (int i = 0; i < label1.Text.Length - 1; i++)
                        {
                            uprava = uprava + label1.Text[i];
                        }
                        label1.Text = "(" + uprava + ")*";
                    }
                }

                if (label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/' || label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    uprava = "";
                    for (int i = 0; i < label1.Text.Length - 1; i++)
                    {
                        uprava = uprava + label1.Text[i];
                    }
                    label1.Text = uprava + "*";
                }
                else
                {
                    label1.Text = label1.Text + textBox1.Text + "*";
                }
                operacia = "";
                suctove_operacie=0;
            }         
            else
            {
                if (label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '-':
                            specialny_medzi_vysledok = medzi_vysledok - Convert.ToDouble(zadana_hodnota);
                            break;
                        case '+':
                            specialny_medzi_vysledok = medzi_vysledok + Convert.ToDouble(zadana_hodnota);
                            break;
                    }
                    operacie = 0;
                }
                operacie++;
                if (operacie == 1)
                {
                    medzi_vysledok = Convert.ToDouble(zadana_hodnota);
                }
                else
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '/':
                            medzi_vysledok = medzi_vysledok / Convert.ToDouble(zadana_hodnota);
                            break;
                        case '*':
                            medzi_vysledok = medzi_vysledok * Convert.ToDouble(zadana_hodnota);
                            break;
                        case '+':
                            medzi_vysledok = medzi_vysledok + Convert.ToDouble(zadana_hodnota);
                            textBox1.Text =Convert.ToString(medzi_vysledok);
                            break;
                        case '-':
                            medzi_vysledok = medzi_vysledok - Convert.ToDouble(zadana_hodnota);
                            textBox1.Text = Convert.ToString(medzi_vysledok);
                            break;
                    }
                }
                if (sinus == true || cosinus == true || odmocnina == true || mocnina == true || tangens == true || exponent == true)
                {
                    if (zaporna_hodnota==1)
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = "(-"+do_prikladu+")"+ "*";
                        }
                        else
                        {
                            label1.Text = label1.Text +"(-"+do_prikladu+")"+"*";
                        }
                        displej = true;
                    }
                    else
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = do_prikladu + "*";
                        }
                        else
                        {
                            label1.Text = label1.Text + do_prikladu + "*";
                        }

                    }
                    sinus = false;
                    cosinus = false;
                    mocnina = false;
                    odmocnina = false;
                    tangens = false;
                    exponent = false;
                    displej = true;
                    zaporna_hodnota = 0;
                }               
                else
                {
                    if (zaporna_hodnota==1)
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = "("+zadana_hodnota +")"+ "*";
                        }
                        else
                        {
                            label1.Text = label1.Text +"("+zadana_hodnota+")"+ "*";
                        }
                        textBox1.Text = Convert.ToString(medzi_vysledok);
                    }
                    else
                    {
                        if (label1.Text=="0")
                        {
                            label1.Text =zadana_hodnota + "*";
                        }
                        else 
                        {
                        label1.Text = label1.Text + zadana_hodnota + "*";
                        }
                        textBox1.Text = Convert.ToString(medzi_vysledok);
                    }
                    displej = true;
                    zaporna_hodnota = 0;
                }
            }
        }

        private void deleno_Click(object sender, EventArgs e)
        {
            try
            {
                chyba = false;
                if (zadana_hodnota == "" && displej == true)
                {
                    zadana_hodnota = "0";
                }
                if (Convert.ToString(medzi_vysledok) == textBox1.Text && displej == true)
                {
                    displej = true;
                }
                else
                {
                    if ((zadana_hodnota != textBox1.Text && displej == true || zadana_hodnota != textBox1.Text && displej == false) || textBox1.Text == zadana_hodnota && displej == true)
                    {
                        zadana_hodnota = textBox1.Text;
                        Convert.ToDouble(zadana_hodnota);
                        Convert.ToString(zadana_hodnota);
                        displej = false;
                        chyba = false;
                        clear.Text = "CE";
                    }
                }
            }
            catch (FormatException)
            {
                zadana_hodnota = "1";
                textBox1.Text = "0";
                chyba = true;
                displej = true;

            }
            if (konecny_vysledok == true)
            {
                label1.Text = "0";
                konecny_vysledok = false;
                Convert.ToDouble(textBox1.Text);
                operacia = "";
                operacie = 0;
                zadana_hodnota = textBox1.Text;
                displej = false;
            }
            if (displej == true && chyba == false)
            {
                string uprava = "";
                if (label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-'||label1.Text[label1.Text.Length - 1] == '*' || label1.Text[label1.Text.Length - 1] == '/' )
                {
                    if(suctove_operacie>=1)
                    {
                        medzi_vysledok = Convert.ToDouble(specialny_medzi_vysledok_1);
                        //medzi_vysledok = Convert.ToDouble(scitanec);                  
                        for (int i = 0; i < label1.Text.Length - 1; i++)
                        {
                            uprava = uprava + label1.Text[i];
                        }
                        label1.Text = "(" + uprava + ")*";
                    }
                   
                }
                if (label1.Text[label1.Text.Length - 1] == '/' || label1.Text[label1.Text.Length - 1] == '*'|| label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    uprava = "";
                    for (int i = 0; i < label1.Text.Length - 1; i++)
                    {
                        uprava = uprava + label1.Text[i];
                    }
                    label1.Text = uprava + "/";
                }
                else
                {
                    label1.Text = label1.Text + textBox1.Text + "/";
                }
                suctove_operacie=0;
                operacia = "";
            }
              
            else if(chyba == false && displej == false)
            {
                if (label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '*':
                            specialny_medzi_vysledok = Convert.ToDouble(scitanec) * medzi_vysledok;
                            break;
                        case '/':
                            specialny_medzi_vysledok = Convert.ToDouble(scitanec) / medzi_vysledok;
                            break;
                        case '-':
                            specialny_medzi_vysledok = medzi_vysledok - Convert.ToDouble(zadana_hodnota);
                            break;
                        case '+':
                            specialny_medzi_vysledok = medzi_vysledok + Convert.ToDouble(zadana_hodnota);
                            break;
                    }
                }
                if (label1.Text[label1.Text.Length - 1] == '+' || label1.Text[label1.Text.Length - 1] == '-')
                {
                    operacie = 0;
                }
                operacie++;
                if (operacie == 1)
                {
                    medzi_vysledok = Convert.ToDouble(zadana_hodnota);
                }
                else
                {
                    switch (label1.Text[label1.Text.Length - 1])
                    {
                        case '/':
                            medzi_vysledok = medzi_vysledok / Convert.ToDouble(zadana_hodnota);
                            break;
                        case '*':
                            medzi_vysledok = medzi_vysledok * Convert.ToDouble(zadana_hodnota);
                            break;
                        case '-':
                            medzi_vysledok = medzi_vysledok - Convert.ToDouble(zadana_hodnota);
                            textBox1.Text = Convert.ToString(medzi_vysledok);
                            break;
                        case '+':
                            medzi_vysledok = medzi_vysledok + Convert.ToDouble(zadana_hodnota);
                            textBox1.Text = Convert.ToString(medzi_vysledok);
                            break;
                    }
                }

                if (sinus == true || cosinus == true || odmocnina == true || mocnina == true || tangens == true || exponent == true)
                {
                    if (zaporna_hodnota == 1)
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = "(-" + do_prikladu + ")" + "/";
                        }
                        else
                        {
                            label1.Text = label1.Text + "(-" + do_prikladu + ")" + "/";
                        }
                        displej = true;
                    }
                    else
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = do_prikladu + "/";
                        }
                        else
                        {
                            label1.Text = label1.Text + do_prikladu + "/";
                        }

                    }
                    sinus = false;
                    cosinus = false;
                    mocnina = false;
                    odmocnina = false;
                    tangens = false;
                    exponent = false;
                    displej = true;
                    zaporna_hodnota = 0;
                }
                else
                {
                    if (zaporna_hodnota == 1)
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = "(" + zadana_hodnota + ")" + "/";
                        }
                        else
                        {
                            label1.Text = label1.Text + "(" + zadana_hodnota + ")" + "/";
                        }
                        textBox1.Text = Convert.ToString(medzi_vysledok);
                    }
                    else
                    {
                        if (label1.Text == "0")
                        {
                            label1.Text = zadana_hodnota + "/";
                        }
                        else
                        {
                            label1.Text = label1.Text + zadana_hodnota + "/";
                        }
                        textBox1.Text = Convert.ToString(medzi_vysledok);
                    }
                    displej = true;
                    zaporna_hodnota = 0;

                }
            }
        }
        //treba dorobit zadavanie uhlov pre cos,sin,tan  
        private void sin_Click(object sender, EventArgs e)
        {

            if (displej == false && exponent == false)
            {
                if (sinus==false)
                {
                    do_prikladu = textBox1.Text;
                }
                sinus=true;
                zadana_hodnota = textBox1.Text;
                if (zadana_hodnota != "0")
                {
                    zadana_hodnota = Convert.ToString(Math.Sin(ConvertToRadians(Convert.ToDouble(zadana_hodnota))));
                }
                else
                {
                    zadana_hodnota = "0";
                }
                textBox1.Text = zadana_hodnota; 
                
                do_prikladu = "sin(" + do_prikladu + ")";
                clear.Text = "CE";
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void cos_Click(object sender, EventArgs e)
        {

                if (displej == false && exponent==false)
                {
                    if (sinus == false)
                    {
                        do_prikladu = textBox1.Text;
                    }
                    cosinus =true;
                    zadana_hodnota = textBox1.Text;
                    if (zadana_hodnota != "90")
                    {
                        zadana_hodnota = Convert.ToString(Math.Cos(ConvertToRadians(Convert.ToDouble(zadana_hodnota))));
                    }
                    else
                    {
                        zadana_hodnota = "0";
                    }
                    clear.Text = "CE";
                    textBox1.Text = zadana_hodnota;
                    do_prikladu = "cos(" + do_prikladu + ")";
                }
                specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }
        
        private void tan_Click(object sender, EventArgs e)
        {
            if (displej == false && exponent == false && Convert.ToDouble(textBox1.Text) != 0)
            {
                if (tangens == false)
                {
                    do_prikladu = textBox1.Text;
                }
                tangens = true;
                zadana_hodnota = textBox1.Text;
                zadana_hodnota = Convert.ToString(Math.Tan(ConvertToRadians(Convert.ToDouble(zadana_hodnota))));
                textBox1.Text = zadana_hodnota;
                do_prikladu = "tan(" + do_prikladu + ")";
                clear.Text = "CE";
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }
 
        private void exp_Click(object sender, EventArgs e)
        {
            if (displej == false&&exponent==false&&Convert.ToDouble(textBox1.Text)!=0)
            {
                exponent =true;
                textBox1.Text = zadana_hodnota + "e+0";
                do_prikladu = zadana_hodnota;
                
            }            
        }

        private void power_Click(object sender, EventArgs e)
        {
            if (displej == false && exponent == false&&Convert.ToDouble(textBox1.Text)!=0)
            {
                if (mocnina== false)
                {
                    do_prikladu = textBox1.Text;
                }
                mocnina = true;
                zadana_hodnota = textBox1.Text;
                zadana_hodnota = Convert.ToString(Math.Pow(Convert.ToDouble(zadana_hodnota),2));
                textBox1.Text = zadana_hodnota;
                do_prikladu = "(" + do_prikladu + ")²";
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void square_Click(object sender, EventArgs e)
        {
            if (displej == false && exponent == false && Convert.ToDouble(textBox1.Text) != 0)
            {
                if (odmocnina == false)
                {
                    do_prikladu = textBox1.Text;
                }
                sinus = true;
                zadana_hodnota = textBox1.Text;
                zadana_hodnota = Convert.ToString(Math.Sqrt(Convert.ToDouble(zadana_hodnota)));
                textBox1.Text = zadana_hodnota;
                do_prikladu = "√(" + do_prikladu + ")";
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void sign_Click(object sender, EventArgs e)
        {

            if (displej == false && Convert.ToDouble(textBox1.Text) != 0)
            {
                if (textBox1.Text.IndexOf('e') != -1)
                {
                    zadavany_exponent = textBox1.Text.Split('+');
                    if (zadavany_exponent.Length==1)
                    {
                        zadavany_exponent = textBox1.Text.Split('-');
                        textBox1.Text = zadavany_exponent[0] + "+" + zadavany_exponent[1];
                    }
                    else
                    {
                        textBox1.Text = zadavany_exponent[0] + "-" + zadavany_exponent[1];
                    }
                    do_prikladu = "(" + textBox1.Text + ")";
                    zadana_hodnota = textBox1.Text;
                }
                else 
                {
                    zadana_hodnota = Convert.ToString(Convert.ToDouble(zadana_hodnota) * (-1));
                    textBox1.Text = zadana_hodnota;
                    if (zaporna_hodnota==0)
                    {
                        zaporna_hodnota = 1;
                    }
                    else
                    {
                        zaporna_hodnota = 0;
                    }
                }
            }
            zadana_hodnota = textBox1.Text;
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }

        private void back_Click(object sender, EventArgs e)
        {
            if(displej==false &&textBox1.Text != "0")
            {
                if(sinus == true || cosinus == true || odmocnina == true || mocnina == true || tangens == true)
                {
                    // back je nefunkcny ak sa vykonava funkcia
                }
                else
                {
                    string uprava = "";
                    if (textBox1.Text.IndexOf('e') != -1)
                    {
                        zadavany_exponent = textBox1.Text.Split('-','+');
                        if((textBox1.Text[textBox1.Text.Length-2]=='+'|| textBox1.Text[textBox1.Text.Length - 2] == '-')&&zadavany_exponent[1]=="0")
                        {
                            for (int i = 0; i < textBox1.Text.Length - 3; i++)
                            {
                                uprava = uprava + textBox1.Text[i];
                            }
                            zadana_hodnota = textBox1.Text;
                            exponent = false;
                        }
                        else
                        {
                            zadavany_exponent = textBox1.Text.Split('-', '+');
                            for (int i = 0; i < textBox1.Text.Length - 1; i++)
                            {
                                uprava = uprava + textBox1.Text[i];
                            }
                            if (zadavany_exponent[1].Length==1)
                            {
                                zadavany_exponent = textBox1.Text.Split('+');
                                if(zadavany_exponent.Length==1)
                                {
                                    uprava = zadavany_exponent[0] + "-0";
                                }
                                else
                                {
                                    uprava = zadavany_exponent[0] + "+0";
                                }
                            }
                        }
                        textBox1.Text = uprava;
                    }
                    else
                    {
                        for(int i=0;i<textBox1.Text.Length-1;i++)
                        {
                            uprava = uprava + textBox1.Text[i];
                        }
                        if(uprava.Length<1)
                        {
                            uprava = "0";
                            clear.Text = "C";
                        }
                        textBox1.Text = uprava;
                    }
                    zadana_hodnota = textBox1.Text;
                }
            }
            specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
        }
        private void clear_Click(object sender, EventArgs e)
        {
            if(clear.Text == "C")
            {
                label1.Text= "0";
                reset_premennych();
            }
            else
            {
                zadana_hodnota = "0";
                textBox1.Text = "0";
                clear.Text = "C";
                specialny_medzi_vysledok_1 = specialny_vysledok(label1.Text, scitanec, zadana_hodnota, medzi_vysledok, operacia);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void reset_premennych ()
        {
            medzi_vysledok = 0;
            specialny_medzi_vysledok = 0;
            operacie = 0;
            displej = false;
            konecny_vysledok = false;
            scitanec = "";
            operacia = "";
            suctove_operacie = 0;
            sinus = false;
            cosinus = false;
            odmocnina = false;
            mocnina = false;
            tangens = false;
            do_prikladu = "";
            exponent = false;
            zaporna_hodnota = 0;
            chyba = false;
        }

        private void M_save_Click(object sender, EventArgs e)
        {
            try
            {
                string hodnota_pamate = textBox1.Text;
                File.WriteAllText("save.txt", hodnota_pamate);
                label3.Text = "Memory value";
                label4.Text = File.ReadAllText("save.txt");
            }
            catch (FileNotFoundException) 
            {
                label4.Text="Nemôžem otvoriť súbor."; 
            }
            catch (IOException)
            {
                label4.Text = "chyba pri praci so suborom";
            }
        }

        private void MR_Click(object sender, EventArgs e)
        {
            try
            {
                string hodnota_pamate = File.ReadAllText("save.txt");
                textBox1.Text=hodnota_pamate;
                if (Convert.ToDouble(textBox1.Text)!=0)
                {
                    clear.Text = "CE";
                    zadana_hodnota = textBox1.Text;
                    displej = false;
                }
            }
            catch (FileNotFoundException)
            {
                label4.Text = "Neda sa najst pamat";
            }
            catch (IOException)
            {
                label4.Text = "chyba s pamatou";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }   
}
