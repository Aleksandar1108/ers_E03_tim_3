using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumHeroji
{
    public class RepozitorijumHeroji : IHerojiRepozitorijum
    {
        public static List<Heroj> heroji = [];

        static RepozitorijumHeroji()
        {
            heroji = [
                new Heroj("Zeus",700, 200, 0),
                new Heroj("Pudge",900, 210, 0),
                new Heroj("Faraon",600, 190,  0),
                new Heroj("Mega knight",800, 220,  0),
                new Heroj("Silencer",700, 180,  0),
                new Heroj("Dragon",500, 200,  0),
                new Heroj("Hog rider",700, 190,  0),
                new Heroj("Phantom Assasin",900, 210,  0),
                new Heroj("Bear",800, 170,  0),
                new Heroj("Wolf",800, 200,  0),
                new Heroj("Dracula",700, 170,  0),

                ];
        }
        public bool DodajHeroja(Heroj hero)
        {
            foreach(Heroj her in heroji)
            {
                if(her.NazivHeroja == hero.NazivHeroja)
                {
                    //Console.WriteLine("Heroj sa tim nazivom vec postoji!\n");
                    return false;
                }

            }
            heroji.Add(hero);
            //Console.WriteLine("Heroj je uspesno dodat u listu!\n");
            return true;

        }  

        public Heroj PronadjiHeroja(string naziv)
        {
            foreach(Heroj her in heroji)
            {
                if(her.NazivHeroja == naziv)
                {
                    Console.WriteLine("Heroj pronadjen!\n");
                    return her;
                }
              
            }
           // Console.WriteLine("Nismo uspeli da pronadjemo heroja sa datim imenom!\n");
            return null;
        }

        public void IspisiHeroje()
        {
            Console.WriteLine("==========================LISTA SVIH HEROJA========================\n");
            foreach(Heroj her in heroji)
            {
                Console.WriteLine(her);

                Console.WriteLine("================================================================\n");
            }
        }
    }
}
