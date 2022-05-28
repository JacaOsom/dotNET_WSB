using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PESELWalidator
    {
        protected int[] wagi =  { 1,3,7,9,1,3,7,9,1,3};
        protected int[] pesel = new int[11];
        private bool czyPrawidlowy = false;
        string pattern = @"^[0-9]{11}$";


    //string input = @"";
    //RegexOptions options = RegexOptions.Multiline;

    //^[0-9]{11}$
    public PESELWalidator(String pesel) //konstruktor
        {
            WczytajPesel(pesel);
        }

        public int[] WczytajPesel(String pesel)
        {
            var list = pesel.ToList();
            if (SprawdzPesel(pesel) == true)
            {
                for (int i = 0; i < pesel.Length; i++)
                {
                    this.pesel[i] = Convert.ToInt32(list[i].ToString());
                }
            }

            return this.pesel;
        }

        public int SumaKontrolna(String pesel) //        public int SumaKontrolna(String pesel, int[] wagi)
    {
            int sumaKontrolnaPESEL = 0;
            if (SprawdzPesel(pesel) == true) 
            { 
                for (int i = 0; i < pesel.Length - 1; i++)
                {
                    sumaKontrolnaPESEL += wagi[i] * int.Parse(pesel[i].ToString());
                }
                sumaKontrolnaPESEL %= 10;
                sumaKontrolnaPESEL = 10 - sumaKontrolnaPESEL;
                sumaKontrolnaPESEL %= 10;

                return sumaKontrolnaPESEL;
            }
            else
            {
                czyPrawidlowy = false;
                return sumaKontrolnaPESEL;
            }
            //prawidlowy = true;
            //return sumaKontrolnaPESEL;
        }

        public String DataUrodzenia()
        {
            int rok = 0;
            int miesiac = 0;
            int dzien = Convert.ToInt32(pesel[4].ToString()) * 10 + Convert.ToInt32(pesel[5].ToString());
            String data = null;

            if (pesel[2] == 0 || pesel[2] == 1)
            {
                rok = 1900;
                miesiac += Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString());
            }
            else if (pesel[2] == 2 || pesel[2] == 3)
            {
                rok = 2000;
                miesiac += (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 20);
            }
            else if (pesel[2] == 4 || pesel[2] == 5)
            {
                rok = 2100;
                miesiac += (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 40);
            }
            else if (pesel[2] == 6 || pesel[2] == 7)
            {
                rok = 2200;
                miesiac += (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 60);
            }
            else if (pesel[2] == 8 || pesel[2] == 9)
            {
                rok = 1800;
                miesiac += (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 80);
            }
            else
            {
                return null;
            }
            rok = rok + int.Parse(pesel[0].ToString()) * 10 + int.Parse(pesel[1].ToString());
            data = (dzien < 10 ? "0" + dzien.ToString() : dzien.ToString()) + "." + (miesiac < 10 ? "0" + miesiac.ToString() : miesiac.ToString()) + "." + rok.ToString();
            return data;
        }

        public String Plec()
        {
            if (pesel[9] % 2 == 1)
            {
                return "Mê¿czyzna";
            }
            else
            {
                return "Kobieta";
            }

        }

        public Boolean SprawdzPesel(string pesel)
        {
            Regex regex = new Regex(pattern);
            return czyPrawidlowy = regex.IsMatch(pesel);
        }   

    }