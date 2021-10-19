using System;


namespace Autokolcsonzo
{

    public class KolcsonozhetoAuto
    {

        /*
  		 * tagváltozók
         */
        private string rendszam;            //RO - csak olvasható nem változik
        private string gyarto;              //RO
        private int gyartasEve;             //RO
        private int utasSzam;               //RO
        private int tartalyMeret;           //RO
        private double uzemanyagMennyiseg;  //RW - újra írható tud változni
        private double fogyasztas;          //RO
        private int megtettKm;              //RW
        private bool berelheto;             //RW
        private char kategoria;             //RW


        /*
         * Konstruktorok
         */
        public KolcsonozhetoAuto() { }

        //új autó
        public KolcsonozhetoAuto(string rszam, string marka, int ev, int utasok, int tartaly, double lpkm,char kat)
        {

            rendszam = rszam;
            gyarto = marka;
            gyartasEve = ev;
            utasSzam = utasok;
            tartalyMeret = tartaly;
            uzemanyagMennyiseg = 0.0;
            fogyasztas = lpkm;
            megtettKm = 0;
            berelheto = true;
            kategoria = kat;
        }


        /*
         * Getter-setter metódusok
         */
        public string getRendszam() { return rendszam; }

        public string getGyarto() { return gyarto; }

        public int getGyartasEve() { return gyartasEve; }

        public int getUtasSzam() { return utasSzam; }

        public double getuzemanyagMennyiseg() { return uzemanyagMennyiseg; }

        public double getFogyasztas() { return fogyasztas; }

        public int getMegtettKm() { return megtettKm; }

        public bool getBerelheto() { return berelheto; }

        public char getKategoria() { return kategoria; }



        public void setRendszam(string rszam) { rendszam = rszam; }

        public void setuzemanyagMennyiseg(double mennyiseg) { uzemanyagMennyiseg = mennyiseg; }

        public void setMegtettKm(int km) { megtettKm = km; }

        public void setBerelheto(bool szabad) { berelheto = szabad; }

        public void setGyartasiIdo(int ev) { gyartasEve = ev; }



        /*
         * tagfüggvények
         */

        //KATEGÓRIA beállítás
        public void kategoriaBeallitas()
        {
            int datum = DateTime.Now.Year;
            int eletkor = datum - gyartasEve;
            if (eletkor<3)
            {
                kategoria = 'A';
            }
            else if(eletkor<=10)
            {
                kategoria = 'B';
            }
            else
            {
                kategoria = 'C';
            }
        }


        //public teleTankolas() {}




    }
}